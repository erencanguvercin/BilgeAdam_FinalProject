using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public interface IRoomService
    {
        void UpdateRoom(Room room);
        IEnumerable<Room> GetAll();
        Room GetRoom(int id);
        
    }
}