using Microsoft.EntityFrameworkCore;
using PrudentProcessActionsAPI.Models;
using System.Xml;

namespace PrudentProcessActionsAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderCancellation> CancelledOrders { get; set; }
        public DbSet<RequestData> RequestDataSet{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the database connection here
            optionsBuilder.UseSqlServer("data source=NAGISDELL\\NNMSSQLSERVER;Initial Catalog=Prudentv1;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");
        }
    }
}
