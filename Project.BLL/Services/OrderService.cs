using Project.BLL.Repository;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> OrderRepository;

        public OrderService(IRepository<Order> OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }
        //Create
        public void CreateOrder(Order Order)
        {
            OrderRepository.Insert(Order);
        }
        //Get
        public Order Get(int id)
        {
            return OrderRepository.Get(id);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return OrderRepository.GetAll().ToList();
        }
        //Delete
        public void RemoveOrder(Order Order)
        {
            OrderRepository.Remove(Order);
        }
        //Update
        public void UpdateOrder(Order Order)
        {
            OrderRepository.Update(Order);
        }
    }
}