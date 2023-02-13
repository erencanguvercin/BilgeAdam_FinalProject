using Project.Entity.Abstract;
using Project.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Models
{
    public class Order:BaseEntity
    {
        public Order()
        {
            Discontinued = true;
            CreatedDate = DateTime.Now;
            Status = DataStatus.Created;
        }
        public List<OrderDetail> OrderDetail { get; set; }
        public double TotalPrice { get; set; }
    }
}
