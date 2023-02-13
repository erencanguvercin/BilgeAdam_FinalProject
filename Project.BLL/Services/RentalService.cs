using Project.BLL.Repository;
using Project.Entity.Abstract;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRepository<Rental> rentalRepository;
        public RentalService(IRepository<Rental> rentalrepository)
        {
            this.rentalRepository = rentalrepository;
        }

        public void CreateRental(Rental rental)
        {
            rentalRepository.Insert(rental);
        }

        public Rental Get(int id)
        {
            return rentalRepository.Get(id);
        }

        public IEnumerable<Rental> GetAllRentals()
        {
            return rentalRepository.GetAll();

        }

        

        public void RemoveRental(Rental rental)
        {
            rentalRepository.Remove(rental);
        }

        public void UpdateRental(Rental rental)
        {
            rentalRepository.Update(rental);
        }
    }
}