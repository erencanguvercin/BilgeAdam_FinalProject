using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services;
using Project.DAL.Context;
using Project.Entity.Enum;
using Project.Entity.Models;
using Project.WEB.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentalController : Controller
    {
        private readonly IRentalService rentalService;
        private readonly IRoomService roomService;
        private readonly IRentUserService rentUserService;
        private readonly IOrderService orderService;
        private readonly IReservationService reservationService;
        private readonly IOrderDetailService orderDetailService;

        public RentalController(IRentalService rentalService, IRoomService roomService, IRentUserService rentUserService, IOrderService orderService, IReservationService reservationService, IOrderDetailService orderDetailService)
        {
            this.rentalService = rentalService;
            this.roomService = roomService;
            this.rentUserService = rentUserService;
            this.orderService = orderService;
            this.reservationService = reservationService;
            this.orderDetailService = orderDetailService;
        }

        public IActionResult Index()
        {   
            var rentals = rentalService.GetAllRentals().ToList();
            return View(rentals);
        }
        public IActionResult CreateRental()
        {
            ViewBag.Rooms = roomService.GetAll().Where(x=>x.EmptyOrNot == false).Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.RoomNumber.ToString(), Value = x.Id.ToString() });
            ViewBag.Reservations = reservationService.GetAll().Select(x=>new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.Id.ToString(), Value = x.Id.ToString() });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental(Rental rental,Order order)
        {
            if (rental.ReservationId != 0)
            {
                var res = reservationService.Get(rental.ReservationId);
                rental.Reservation = res;
                res.ReservationStatus = ReservationStatus.Finished;
                res.Discontinued = true;
                DateTime date1 = DateTime.Now;
                DateTime date2 = rental.Reservation.ReservationDate;
                TimeSpan monthDifference = date1 - date2;
                if (monthDifference.TotalDays >= 90)
                {
                    rental.TotalRentPrice -= rental.TotalRentPrice * 0.23;
                    rental.Reservation.ReservationStatus = ReservationStatus.Finished;
                    rental.Reservation.Discontinued = true;
                }
                else if (monthDifference.TotalDays >= 30 && rental.package == Package.FullPansion)
                {
                    rental.TotalRentPrice -= rental.TotalRentPrice * 0.16;
                    rental.Reservation.ReservationStatus = ReservationStatus.Finished;
                    rental.Reservation.Discontinued = true;
                }
                else if (monthDifference.TotalDays >= 10 && rental.package == Package.AllIncluded)
                {
                    rental.TotalRentPrice -= rental.TotalRentPrice * 0.18;
                    rental.Reservation.ReservationStatus = ReservationStatus.Finished;
                    rental.Reservation.Discontinued = true;
                }
            }


            var room = roomService.GetRoom(rental.RoomId1);
            rental.Room = room;
            room.EmptyOrNot = true;
            rental.TotalRentPrice += rental.Room.Price;


            if (rental.package == Package.StandartPack)
            {
                rental.TotalRentPrice = rental.TotalRentPrice;
            }
            else if (rental.package == Package.FullPansion)
            {
                rental.TotalRentPrice = rental.TotalRentPrice * 1.5;
            }
            else if (rental.package == Package.AllIncluded)
            {
                rental.TotalRentPrice = rental.TotalRentPrice * 2;
            }
            rental.Order = order;
            rental.OrderId = order.Id;
            orderService.CreateOrder(order);
            rentalService.CreateRental(rental);
            
            return RedirectToAction("Index");
        } 
        public IActionResult CheckOut(int Id)
        {
            var rental = rentalService.Get(Id);
            TimeSpan fark = rental.EndDate - rental.StartDate;
            double days = fark.TotalDays;
            rental.TotalRentPrice = days * rental.TotalRentPrice;
            var order = orderService.Get(rental.OrderId);
            rental.TotalRentPrice += order.TotalPrice;
            TempData["TotalPrice"] = $"Toplamda ödenecek tutar : {rental.TotalRentPrice} TL'dir";
            rental.Discontinued = false;
            if(order.OrderDetail!=null)
            {
                foreach (var item in order.OrderDetail)
                {
                    orderDetailService.RemoveOrderDetail(item);
                }
            }
            orderService.RemoveOrder(order);
            
            return RedirectToAction("End");
        }

        public IActionResult End()
        {
            return View();
        }
    }
}
