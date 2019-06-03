using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Online_Store__React_ASPX_.Models
{
    public class AppDbContext : DbContext 

    {
        public AppDbContext() : base("DefaultConnection")
        {



        }

        public DbSet<Customer> Customers { get; set;  }
        public DbSet<FoodItems> FoodItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}