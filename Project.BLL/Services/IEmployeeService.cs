using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAll();
        double ExtraHourSalary(Employee employee);
        void SalaryCalculator(Employee employee);
    }
}
