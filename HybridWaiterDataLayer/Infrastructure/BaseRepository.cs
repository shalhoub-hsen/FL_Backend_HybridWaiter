using HybridWaiterDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace HybridWaiterDataLayer.Infrastructure
{

    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Save(TEntity entity, bool isNew);
        Task<bool> Delete(int id);
    }
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        protected HybridWaiterModel dbContext;
        private readonly DbSet<TEntity> dbset;
        protected readonly string ConnectionString;
        
        public BaseRepository(HybridWaiterModel applicationDbContext)
        {
            dbContext = applicationDbContext;
            dbset = dbContext.Set<TEntity>();
            ConnectionString = dbContext.Database.GetDbConnection().ConnectionString;
        }
        public async virtual Task<TEntity> Get(int id)
        {
            try
            {
                var obj = await this.dbset.FindAsync(id);
                return obj;
            }
            catch (Exception) { throw; }
        }
        public async Task<IEnumerable<TEntity>> Get()
        {
            try
            {
                var isDeletedProperty = typeof(TEntity).GetProperty("IsDeleted");
                //if (isDeletedProperty != null)
                //{
                //    return await this.dbset.Where(entity => !(bool)isDeletedProperty.GetValue(entity)).ToListAsync();
                //}
                //else
                //{
                    return await this.dbset.ToListAsync();
                //}
            }
            catch (Exception) { throw; }
        }

        public virtual async Task<TEntity> Save(TEntity entity, bool isNew)
        {
            try
            {
                if (!isNew)
                {
                    dbContext.Update(entity);
                }
                else
                {
                    var pe = typeof(TEntity).GetProperty("CreationDate");
                    if (pe != null)
                    {
                        pe.SetValue(entity, DateTime.Now);
                    }
                    dbset.Add(entity);
                }

                dbContext.SaveChanges();
                return entity;
            }
            catch (Exception) { throw; }
        }
        public async Task<bool> Delete(int id) 
        {
            try
            {
                var entity = dbContext.Set<TEntity>().Find(id);
               if(entity != null)
                {
                    dbContext.Remove(entity);
                    dbContext.SaveChanges();
                    return true;
                }
               else
                    return false;
                //dbContext.Attach(entity);
                //dbContext.Remove(entity);
                //dbContext.SaveChanges();

            }
            catch (Exception) { throw; }
        }

    }
}
