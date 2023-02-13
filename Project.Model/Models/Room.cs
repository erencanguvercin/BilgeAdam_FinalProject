using Project.Entity.Abstract;
using Project.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Models
{    
    public class Room:BaseEntity
    {
        public Room()
        {
            Discontinued= true;
            CreatedDate= DateTime.Now;
            Status = DataStatus.Created;
        }
        public int RoomNumber { get; set; }
        public bool EmptyOrNot { get; set; }
        public Floor Floor { get; set; }
        public UserQuantity UserQuantity { get; set; }
        public BedType BedType { get; set; }
        public double Price { get; set; }
        public List<Reservation> Reservation { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
