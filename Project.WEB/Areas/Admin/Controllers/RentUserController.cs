using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services;
using Project.DAL.Context;
using Project.Entity.Models;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RentUserController : Controller
    {
        
        private readonly IRentUserService rentUserService;
        public RentUserController(IRentUserService rentUserService)
        {
            this.rentUserService = rentUserService;
        }

        public IActionResult Index()
        {
            TempData["Title"] = "Müşteriler";
            var rentUsers = rentUserService.GetAll().ToList();
            return View(rentUsers);
        }
        public IActionResult CreateUser()
        {
            TempData["Title"] = "Müşteri Oluştur";
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(RentUser rentUser)
        {

            rentUserService.CreateRentUser(rentUser);
            return RedirectToAction("Index");
        }
        
    }
}
