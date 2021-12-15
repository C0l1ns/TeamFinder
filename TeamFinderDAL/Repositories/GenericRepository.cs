using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamFinderDAL.Interfaces;
namespace TeamFinderDAL.Repositories
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private readonly TeamFinderDbContext _teamFinderDbContext;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(TeamFinderDbContext teamFinderDbContext)
        {
            _teamFinderDbContext = teamFinderDbContext;
            _dbSet = teamFinderDbContext.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Create(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}