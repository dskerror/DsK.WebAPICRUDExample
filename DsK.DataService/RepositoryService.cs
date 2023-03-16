using DsK.DataService.Models;
using DsK.DataService.Repositories;

namespace DsK.DataService
{
    public class RepositoryService
    {
        public GenericRepository<Client> ClientRepository { get; set; }

        public RepositoryService()
        {
            ClientRepository = new GenericRepository<Client>();
        }

    }
}