using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CoffeeShopDbContext : DbContext
    {
        public DbSet<AccountAdmin> AccountAdmins { get; set; }
        public DbSet<AccountEmployee> AccountEmployees { get; set; }
        public DbSet<Employee> Employeees { get; set; }
        public DbSet<Salary> salaries { get; set; }
        public DbSet<Customer> Customeres { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }





        string strConnect = "server=localhost; user id=root;password=123456;port=3306;database=CoffeeShop";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(strConnect);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>().HasKey(key => new
            {
                key.Order_no,
                key.Prod_no
            });
        }
    }
}
