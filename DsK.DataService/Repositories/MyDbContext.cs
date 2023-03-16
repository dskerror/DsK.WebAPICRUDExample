using DsK.DataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsK.DataService.Repositories
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MyDb");
        }
        
        public DbSet<Client> Clients { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
    }
}
