using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public interface IRentUserService
    {
        void CreateRentUser(RentUser rentUser);
        void UpdateRentUser(RentUser rentUser);
        void DeleteRentUser(RentUser rentUser);
        RentUser Get(int id);
        IEnumerable<RentUser> GetAll();
    }
}