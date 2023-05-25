using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected CoffeeShopDbContext context;
        protected DbSet<TEntity> entities;
        public GenericRepository(CoffeeShopDbContext context)
        {
            this.context = context;
            entities = this.context.Set<TEntity>();
        }
        public virtual async Task AttchTEntity(TEntity entity)
        {
            await entities.AddAsync(entity);
           
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await entities.FindAsync(id);
        }

        public virtual void Update (TEntity entity)
        {
             entities.Attach(entity);
             this.context.Entry(entity).State = EntityState.Modified;
        }
    }
}
