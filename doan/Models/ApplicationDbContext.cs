using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace doan.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }  // ✅ Đúng
        public DbSet<Bai01Model> Bai01 { get; set; }
        public object Bai01Model { get; internal set; }
        public DbSet<Bai02Model> Bai02 { get; set; }
       
        public object Bai02Model { get; internal set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }


}
