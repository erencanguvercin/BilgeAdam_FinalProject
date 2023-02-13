using Project.Entity.Models;
using System.Collections.Generic;

namespace Project.WEB.Models.ViewModels
{
    public class ReseptionVM
    {
        public IEnumerable<Rental> Rentals { get; set; }
        public IEnumerable<RentUser> Users { get; set; }

    }
}
