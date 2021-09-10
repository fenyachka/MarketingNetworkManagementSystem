using Domain.Entities.Distributors;
using Domain.Entities.Mapping;
using Domain.Entities.Orders;
using Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<AddressInfo> AddressInfos { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<DocumentInfo> DocumentInfos { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Referals> Referals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}