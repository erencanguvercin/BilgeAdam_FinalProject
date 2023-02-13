using Project.BLL.Repository;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> reservationService;

        public ReservationService(IRepository<Reservation> reservationservice)
        {

            this.reservationService = reservationservice;
        }

        public void CreateReservation(Reservation reservation)
        {
            reservationService.Insert(reservation);
        }

        public Reservation Get(int id)
        {
            return reservationService.Get(id);
        }

        public IEnumerable<Reservation> GetAll()
        {
            return reservationService.GetAll();
        }

        public void RemoveReservation(Reservation reservation)
        {
            reservationService.Remove(reservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            reservationService.Update(reservation);
        }
    }
}