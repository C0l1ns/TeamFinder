using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamFinderDAL.Entities;
using TeamFinderDAL.Interfaces;

namespace TeamFinderDAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, IEntity
    {
        private readonly TeamFinderDbContext _context;
        
        private readonly DbSet<T> _dbSet;

        protected GenericRepository(TeamFinderDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public Task<List<T>> GetAll()
        {
            return _dbSet.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _dbSet.SingleOrDefaultAsync(x => x.Id == id);
        }
        
        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }
        
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}