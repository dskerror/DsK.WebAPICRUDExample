using Microsoft.EntityFrameworkCore;

namespace DsK.DAL.Models;
public class DsKDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "MyDb");
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }
}
