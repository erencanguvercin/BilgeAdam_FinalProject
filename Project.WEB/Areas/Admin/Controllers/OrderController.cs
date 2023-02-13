using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services;
using Project.DAL.Context;
using Project.Entity.Models;
using Project.WEB.Areas.Admin.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {   
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderdetailService;
        private readonly IRentalService _rentalService;
        private readonly IProductService productservice;
        private readonly UserManager<AppUser> userManager;
        private readonly ProjectContext projectContext;

        public OrderController(IOrderDetailService orderDetailService, IOrderService orderService, IRentalService rentalService, IProductService productservice, UserManager<AppUser> userManager, ProjectContext projectContext)
        {
            this._orderService = orderService;
            this._orderdetailService = orderDetailService;
            this._rentalService= rentalService;
            this.productservice = productservice;
            this.userManager = userManager;
            this.projectContext = projectContext;
        }
        public IActionResult CreateOd()
        {
            ViewBag.Orders = _orderService.GetAllOrders().ToList().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.Id.ToString(), Value = x.Id.ToString() });
            ViewBag.Products = productservice.GetAll().ToList().Select(x => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.ProductName, Value = x.Id.ToString() });
            return View();
        }
        [HttpPost]
        public IActionResult CreateOd(OrderDetailVM orderDetailvm,OrderDetail orderDetail)
        {   
            var od = _orderService.Get(orderDetailvm.OrderId);
            var prd = productservice.GetProduct(orderDetailvm.ProductId);
            orderDetail.product = prd;
            orderDetail.Order = od;
            orderDetail.Quantity = orderDetailvm.Quantity;
            double price = orderDetail.product.UnitPrice * orderDetail.Quantity;
            orderDetail.TotalPrice = price;
            _orderdetailService.CreateOrderDetail(orderDetail);
            var order = _orderService.Get(orderDetail.Order.Id);
            order.TotalPrice += orderDetail.TotalPrice;
            projectContext.SaveChanges();
            return View();
        }
        public IActionResult CreateOrder()
        {   
            ViewBag.Rentals = _rentalService.GetAllRentals().ToList().Select(x=> new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = x.RoomId1.ToString(), Value = x.Id.ToString() });
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder(Order order,OrderVM orderVM)
        {
            var rental = _rentalService.Get(orderVM.RentalId);
            rental.Order=order;
            _orderService.CreateOrder(order);
            return View();
        }
    }
}
