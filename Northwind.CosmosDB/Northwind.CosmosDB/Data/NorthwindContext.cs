using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;
using Northwind.CosmosDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.CosmosDB.Data
{
    public class NorthwindContext : DbContext
    {
        
        public DbSet<Employee>? Employees { get;set; }
        public DbSet<Customer>? Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos("https://northwind-db-test.documents.azure.com:443/", 
                "zTFqrlSOzDhTHm1L7kEAKVLZI1hpehNKouHBNXTMT7WA1qBFwomA1DFeGhpq0bFK6Xfx0MLFk0GzACDbYkWy8w==",
                "northwind-db");

            // accountEndpoint , accountKey , databasename
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToContainer("Employees") // To Container
                .HasPartitionKey(e=>e.Id); // Partition Key
            
            modelBuilder.Entity<Customer>()
                .ToContainer("Customers") // To Container
                .HasPartitionKey(e => e.Id) // Partition Key
                .OwnsMany(e=>e.Orders); 
        }
    }
}
