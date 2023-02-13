using Project.Entity.Abstract;
using Project.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Discontinued = true;
            CreatedDate = DateTime.Now;
            Status = DataStatus.Created;
        }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public string Description { get; set; }
        public Amount? amount { get; set; }
        public Portion? portion { get; set; }
    }
}
