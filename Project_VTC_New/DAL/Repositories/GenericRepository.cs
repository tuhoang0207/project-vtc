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
        public virtual void AttchTEntity(TEntity entity)
        {
             entities.Add(entity);
           
        }

        //public void AttchTEntity(TEntity entity)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual  IEnumerable<TEntity> GetAll()
        {
            return entities.ToList();
        }

        //public Task<IEnumerable<TEntity>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<TEntity> GetAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual void Update (TEntity entity)
        {
             entities.Attach(entity);
             this.context.Entry(entity).State = EntityState.Modified;
        }

        //TEntity IGenericRepository<TEntity>.Get (int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
