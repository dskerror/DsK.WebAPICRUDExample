using DsK.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DsK.DAL.Models;
public class DsKDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "MyDb");
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    modelBuilder.Entity<Brand>().HasData(
    //        new Brand
    //        {
    //            Id = 1,
    //            Name = "Brand1",
    //            Description = "Brand 1 Desc",
    //            CreatedBy = "DsK",
    //            CreatedOn = DateTime.Now,
    //            LastModifiedBy = "DsK",
    //            LastModifiedOn = DateTime.Now
    //        }
    //    );
    //}
    public DbSet<Brand> Brands { get; set; }
}
