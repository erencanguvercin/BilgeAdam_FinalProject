using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entity.Abstract
{
    public abstract class Employee
    {
        public IdentityUser User { get; set; }
        public IdentityRole UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


    }
}
