using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services;
using Project.Entity.Models;
using Project.WEB.Areas.Admin.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = employeeService.GetAll().ToList();
            return View(employees);
        }

        public IActionResult CreateEmployee()
        {   
            return View();
        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            employeeService.CreateEmployee(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Salary(SalaryVM salary)
        {

            ViewBag.Employees = employeeService.GetAll().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.FirstName, Value = x.Id.ToString() });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Salary(Employee employee,SalaryVM salary)
        {
            var employee1 = employeeService.GetEmployee(salary.EmployeeId);
            employee1.WorkHours = salary.WorkHour;
            employeeService.SalaryCalculator(employee1);
            return View();
        }
    }
}
