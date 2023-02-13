using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services;
using System.Linq;

namespace Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {   
        private readonly IReservationService reservationService;
        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var reservations = reservationService.GetAll().Where(x=>x.ReservationStatus == Entity.Enum.ReservationStatus.Made).ToList();
            return View(reservations);
        }
    }
}
