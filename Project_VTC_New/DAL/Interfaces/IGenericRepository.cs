using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> GetAllAsync();
        TEntity GetAsync(int id);
        void AttchTEntity(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity); 
    }
}
