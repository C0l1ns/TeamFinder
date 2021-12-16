using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamFinderDAL.Interfaces;

namespace TeamFinderDAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TeamFinderDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(TeamFinderDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        // TODO
        public Task<T> GetById(int id)
        {
            throw new System.NotImplementedException();
        }
        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }
        // TODO
        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
        // TODO    
        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}