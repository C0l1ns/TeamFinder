using System.Collections.Generic;
using System.Threading.Tasks;
using TeamFinderDAL.Entities;

namespace TeamFinderBL.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class, IEntity
    {
        public int Create(TEntity entity);
        public Task<IEnumerable<TEntity>> GetAll();
        public Task<int> Delete(int id);
        public void Update(TEntity entity);
        public Task<TEntity> GetById(int id);
    }
}