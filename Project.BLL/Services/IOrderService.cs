using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public interface IOrderService
    {
        //Create
        void CreateOrder(Order Order);

        //Delete
        void RemoveOrder(Order Order);

        //Update
        void UpdateOrder(Order Order);

        //Get
        Order Get(int id);
        IEnumerable<Order> GetAllOrders();
    }
}
