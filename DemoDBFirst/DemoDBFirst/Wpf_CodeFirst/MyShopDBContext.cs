using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_CodeFirst
{
    public class Category
    {
        public Category() { }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }
        public String CategoryName { get; set; }
    }

    class MyShopDBContext : DbContext
    {
        public MyShopDBContext() { }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", true, true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyShop"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Category>()
                .HasData(
                new Category { CategoryID = 1, CategoryName = "Beverages" },
                new Category { CategoryID = 2, CategoryName = "Condiments" },
                new Category { CategoryID = 3, CategoryName = "Confections" }
                );
        }

    }
}