using Project.BLL.Repository;
using Project.DAL.Context;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> repository;
        private readonly ProjectContext projectContext;

        public EmployeeService(IRepository<Employee> _repository, ProjectContext projectContext)
        {
            this.repository = _repository;
            this.projectContext = projectContext;
        }
        public void CreateEmployee(Employee employee)
        {
            repository.Insert(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            repository.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return repository.GetAll();
        }

        public Employee GetEmployee(int id)
        {
            return repository.Get(id);
        }

        public void UpdateEmployee(Employee employee)
        {
            repository.Update(employee);
        }
        public double ExtraHourSalary(Employee employee)
        {
            if(employee.WorkHours > 8)
            {
                employee.ExtraHours = employee.WorkHours - 8;
                employee.ExtraHourSalary = employee.ExtraHours * employee.SalaryPerHour * 1.5;
                employee.WorkHours = employee.WorkHours - employee.ExtraHours;
                return employee.ExtraHourSalary;
            }
            else
            {
                employee.ExtraHourSalary = 0;
                return employee.ExtraHourSalary;
            }
        }

        public void SalaryCalculator(Employee employee)
        {
            if (employee.DayCounter > 30)
            {
                employee.DayCounter = 0;
                employee.MonthSalary = 0;
                projectContext.SaveChanges();
            }
            if (employee.Day.Day != DateTime.Now.Day)
            {
                double maaş = ExtraHourSalary(employee) + (employee.SalaryPerHour * employee.WorkHours);
                employee.MonthSalary += maaş;
                employee.Day = DateTime.Now;
                employee.DayCounter++;
                projectContext.SaveChanges();
            }
            
        }
    }
}
