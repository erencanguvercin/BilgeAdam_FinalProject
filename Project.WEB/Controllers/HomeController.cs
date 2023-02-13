using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Project.BLL.Services;
using Project.Common;
using Project.Entity.Models;
using Project.WEB.Models;
using Project.WEB.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.WEB.Controllers
{
    public class HomeController : Controller
    {   
        private readonly IRoomService roomService;
        private readonly IReservationService reservationService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SignInManager<AppUser> signInManager,UserManager<AppUser> userManager, IRoomService roomService,IReservationService reservationService)
        {
            this._logger = logger;
            this.signInManager = signInManager;
            this.roomService = roomService;
            this.reservationService = reservationService;
            this.userManager = userManager; 
            
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerUser)
        {
            if (ModelState.IsValid)
            {   
                AppUser newUser = new AppUser()
                {   
                    FirstName = registerUser.FirstName,
                    LastName = registerUser.LastName,
                    BirthDate= registerUser.BirthDate,
                    UserName = registerUser.Username,
                    Email = registerUser.Email
                };

                var result = await userManager.CreateAsync(newUser, registerUser.Password);



                var registerToken = "";
                if (result.Succeeded)
                {

                    while (true)
                    {
                        registerToken = userManager.GenerateEmailConfirmationTokenAsync(newUser).Result;
                        if (!registerToken.Contains("/"))
                        {
                            break;
                        }
                    }



                    MailSend.SendEmail(registerUser.Email, "Register", $"Hoşgeldin {registerUser.Username}! Kaydını başarıyla oluşturduk! Üyeliğini tamamlamak için linke tıkla! https://localhost:5001/home/confirmation/" + newUser.Id + "/" + registerToken);

                    TempData["result"] = $"{newUser.Email} adresine aktivasyon maili gönderdik. Üyeliğinizi aktif hale getirmek için ilgili linki tıklayın.";

                    //return RedirectToAction("Confirmation", new { id = newUser.Id, registerCode = registerToken.Result });
                    return View(registerUser);
                }
                else
                {
                    return View(registerUser);
                }

            }
            return View(registerUser);
        }
        public async Task<IActionResult> Confirmation(string id,string registerCode)
        {
            if (id != null && registerCode != null)
            {
                var user = await userManager.FindByIdAsync(id);
                var confirm = await userManager.ConfirmEmailAsync(user, registerCode);
                if (confirm.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                
            }
            return View();
        }
       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user =await userManager.FindByNameAsync(loginVM.Username);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                       
                        return RedirectToAction("Index");
                    }
                }
                return View();

            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateReservation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(ReservationVM reservation, Reservation reservation2)
        {   
            short Ok = 0;
            Room room1=null;
            List<Reservation> reservations = reservationService.GetAll().ToList();
            var oneperson = roomService.GetAll().Where(x => x.UserQuantity == Entity.Enum.UserQuantity.One);
            var twoperson = roomService.GetAll().Where(x => x.UserQuantity == Entity.Enum.UserQuantity.Two);
            var threeperson = roomService.GetAll().Where(x => x.UserQuantity == Entity.Enum.UserQuantity.Three);
            var fourperson = roomService.GetAll().Where(x => x.UserQuantity == Entity.Enum.UserQuantity.Four);

            while (Ok == 0)
            {
                foreach (Reservation reservation1 in reservations)
                {
                    switch (reservation.UserQuantity)
                    {
                        case Entity.Enum.UserQuantity.One:
                            {
                                foreach (var room in oneperson)
                                {
                                    if (reservation.StartDate >= reservation1.StartDate && reservation.StartDate < reservation1.EndDate)
                                    {
                                        if (reservation1.Room == room)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Ok = 1;
                                            room1 = room;
                                            break;
                                        }
                                    }
                                    else if(reservation1.Room != room)
                                    {
                                        Ok = 1;
                                        room1 = room;
                                        break;
                                    }
                                }
                            }
                            break;
                        case Entity.Enum.UserQuantity.Two:
                            {
                                foreach (var room in twoperson)
                                {
                                    if (reservation.StartDate >= reservation1.StartDate && reservation.StartDate < reservation1.EndDate)
                                    {
                                        if (reservation1.Room == room)
                                        {
                                            continue;
                                        }
                                        else if(reservation1.Room==room)
                                        {
                                            Ok = 1;
                                            room1= room;
                                            break;
                                        }
                                    }
                                    else if (reservation1.Room != room)
                                    {
                                        Ok = 1;
                                        room1 = room;
                                        break;
                                    }
                                }
                            }
                            break;
                        case Entity.Enum.UserQuantity.Three:
                            {
                                foreach (var room in threeperson)
                                {
                                    if (reservation.StartDate >= reservation1.StartDate && reservation.StartDate < reservation1.EndDate)
                                    {
                                        if (reservation1.Room == room)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Ok = 1;
                                            room1 = room;
                                            break;
                                        }
                                    }
                                    else if (reservation1.Room != room)
                                    {
                                        Ok = 1;
                                        room1 = room;
                                        break;
                                    }
                                }
                            }
                            break;
                        case Entity.Enum.UserQuantity.Four:
                            {
                                foreach (var room in fourperson)
                                {
                                    if (reservation.StartDate >= reservation1.StartDate && reservation.StartDate < reservation1.EndDate)
                                    {
                                        if (reservation1.Room == room)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Ok = 1;
                                            room1 = room;
                                            break;
                                        }
                                    }
                                    else if (reservation1.Room != room)
                                    {
                                        Ok = 1;
                                        room1 = room;
                                        break;
                                    }
                                }
                            }
                            break;
                    }
                }
                TempData["info"] = "Aradığınız Şartlarda Oda Bulunamadı";
            }
            reservation.StartDate = reservation2.StartDate;
            reservation.EndDate = reservation2.EndDate;
            reservation.UserQuantity = reservation2.UserQuantity;
            reservation2.Room = room1;
            var user = await userManager.GetUserAsync(User);
            reservation2.ReservationOwner = user;
            reservationService.CreateReservation(reservation2);
            TempData["info"] = "Rezervasyon Oluşturuldu !";
            return View();
        }
    }
}
//todo:Room ID Almıyor
//todo:Quantity Almıyor
