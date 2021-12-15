using System.Collections.Generic;
using System.Threading.Tasks;

namespace TeamFinderDAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}