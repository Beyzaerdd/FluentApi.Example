using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Entity.Concrete;
using System.Reflection;

namespace Ecommerce.Data.Concrete.Context
{
    public class SampleDb :DbContext
        {
        public SampleDb(DbContextOptions<SampleDb> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices", isActive = true },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and accessories", isActive = true },
                new Category { Id = 3, Name = "Books", Description = "Books and stationery", isActive = true }
);
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", UnitPrice = 1500.00m, UnitsInStock = 50, isActive = true },
                new Product { Id = 2, Name = "Smartphone", UnitPrice = 800.00m, UnitsInStock = 100, isActive = true },
                new Product { Id = 3, Name = "T-Shirt", UnitPrice = 20.00m, UnitsInStock = 200, isActive = true }
);
            modelBuilder.Entity<ProductCategory>().HasData(

               new ProductCategory { ProductId = 1, CategoryId = 1 },
               new ProductCategory { ProductId = 2, CategoryId = 1 },
               new ProductCategory { ProductId = 3, CategoryId = 2 }


               );
           base.OnModelCreating(modelBuilder);

        }
    }
    
}
