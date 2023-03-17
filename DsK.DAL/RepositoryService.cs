using DsK.DAL.Models;
using DsK.DAL.Repositories;

namespace DsK.DAL;
public class RepositoryService
{
    public GenericRepository<Client> ClientRepository { get; set; }

    public RepositoryService()
    {
        Seed();
        ClientRepository = new GenericRepository<Client>();        
    }

    private void Seed()
    {
        using (var context = new DsKDbContext())
        {
            var clients = new List<Client>
        {
            new Client
            {
                Id = 1,
                Name ="DsKErrOr",
                Age = 69,
                IsAstronaut = true,
                Hobbies
                = new List<Hobby>()
                {
                    new Hobby { Name = "Gaming"},
                    new Hobby { Name = "Music"}

                }
            },
            new Client
            {
                Id = 2,
                Name ="Paz",
                Age = 21,
                IsAstronaut = false,
                Hobbies
                = new List<Hobby>()
                {
                    new Hobby { Name = "Cooking"},
                    new Hobby { Name = "Cleaning"}

                }
            }
        };
            context.Clients.AddRange(clients);
            context.SaveChanges();
        }
    }
}