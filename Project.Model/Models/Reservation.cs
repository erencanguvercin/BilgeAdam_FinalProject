using Microsoft.AspNetCore.Identity;
using Project.Entity.Abstract;
using Project.Entity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Models
{
    public class Reservation:BaseEntity
    {
        public Reservation()
        {
            Discontinued = true;
            CreatedDate = DateTime.Now;
            Status = DataStatus.Created;
            ReservationDate = DateTime.Now;
            ReservationStatus = Enum.ReservationStatus.Made;
        }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public UserQuantity UserQuantity { get; set; }
        public int ReservationOwnerId { get; set; }
        public AppUser ReservationOwner { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}
