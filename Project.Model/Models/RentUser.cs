using Microsoft.AspNetCore.Identity;
using Project.Entity.Abstract;
using Project.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Models
{
    public class RentUser:BaseEntity
    {
        public RentUser()
        {
            Discontinued = true;
            CreatedDate = DateTime.Now;
            Status = DataStatus.Created;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        
        public List<Rental> Rentals { get; set; }
    }
}
