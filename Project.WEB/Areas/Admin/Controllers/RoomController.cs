using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Project.BLL.Services;
using Project.DAL.Context;
using Project.Entity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly ProjectContext projectContext;

        public RoomController(IRoomService roomService, ProjectContext projectContext)
        {
            this.roomService = roomService;
            this.projectContext = projectContext;
        }

        public IActionResult Index()
        {
            TempData["Title"] = "Odalar";
            var rooms = roomService.GetAll().ToList();
            return View(rooms);
        }
    }
}
