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
    public class Employee : BaseEntity
    {
        public Employee()
        {
            Discontinued = true;
            CreatedDate = DateTime.Now;
            Status = DataStatus.Created;
            WorkHours = 8;
            
        }
        public AppUser User { get; set; }
        public AppUserRole UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
        public int WorkHours { get; set; }
        public int ExtraHours { get; set; }
        public double ExtraHourSalary { get; set; }
        public double SalaryPerHour { get; set; }
        public int DayCounter { get; set; }
        public DateTime Day { get; set; }
        public double MonthSalary { get; set; }
        public Shift Shift { get; set; }
    }
}
