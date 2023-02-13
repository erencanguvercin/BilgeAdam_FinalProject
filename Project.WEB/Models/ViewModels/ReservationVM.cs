using Project.Entity.Enum;
using Project.Entity.Models;
using System;

namespace Project.WEB.Models.ViewModels
{
    public class ReservationVM
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public UserQuantity UserQuantity { get; set; }
        public Room Room { get; set; }
    }
}
