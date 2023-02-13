using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services;
using Project.Entity.Models;
using Project.IOC;
using Project.WEB.Models.ViewModels;
using System.Linq;

namespace Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
    
}
