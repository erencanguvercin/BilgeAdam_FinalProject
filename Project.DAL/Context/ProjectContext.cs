using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    public class ProjectContext : IdentityDbContext<AppUser, AppUserRole, int>
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {
        }

        //todo : Eğer ki dbcontext options ile ilgili bir sorun çıkarsa buraya bak !!

        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }
        DbSet<Rental> Rentals { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<RentUser> RentUsers { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<Employee> Employees { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("server=DESKTOP-HTD9AH7;database=BilgeOtel;uid=sa;pwd=123;");
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}
        
    }
}
