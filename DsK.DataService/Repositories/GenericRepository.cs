using DsK.DataService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsK.DataService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MyDbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            Seed();
            this._context = new MyDbContext();
            table = _context.Set<T>();
        }
        public GenericRepository(MyDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Seed()
        {
            using (var context = new MyDbContext())
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
}
