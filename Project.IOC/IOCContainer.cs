using Microsoft.Extensions.DependencyInjection;
using Project.BLL.Repository;
using Project.BLL.Services;
using System;

namespace Project.IOC
{
    public class IOCContainer
    {
        public static void ConfigureIoc(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>),typeof(BaseRepository<>));

            services.AddScoped<IOrderDetailService,OrderDetailService>();
            services.AddScoped<IOrderService,OrderService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IRentalService, RentalService>();
            services.AddScoped<IRentUserService, RentUserService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
