using Project.Entity.Abstract;
using Project.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Models
{
    //todo: Database'de OrderDetail table ında ProductId isminde bir property var sorun çıkarırsa ilgilen !!
    public class OrderDetail:BaseEntity
    {
        public OrderDetail()
        {
            Discontinued = true;
            CreatedDate = DateTime.Now;
            Status = DataStatus.Created;
            Quantity= 1;
        }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public Product product { get; set; }
    }
}
