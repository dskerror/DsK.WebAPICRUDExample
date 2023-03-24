using DsK.Application.Interfaces.Repositories;
using DsK.Domain.Entities;

namespace DsK.DAL.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IRepositoryAsync<Brand, int> _repository;

        public BrandRepository(IRepositoryAsync<Brand, int> repository)
        {
            _repository = repository;
        }
    }
}
