using CQRS_Prototype.Domain.Interfaces;
using CQRS_Prototype.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CQRS_Prototype.Persistence.EntityFramework.Repository
{
    public abstract class EntityFrameworkRepository<TContext, TEntity, TKey> : IRepository<TEntity, TKey> where TContext : DbContext where TEntity : class
    {
        protected readonly TContext DataContext;
        protected readonly DbSet<TEntity> DbSet;

        public EntityFrameworkRepository(TContext context)
        {
            DataContext = context;
            DbSet = DataContext.Set<TEntity>();
        }

        public IActionResponse<TEntity> Create(TEntity entity)
        {
            var returnValue = new ActionResponse<TEntity> { Success = true };
            DbSet.Add(entity);
            returnValue.Data = entity;
            return returnValue;
        }

        public IActionResponse<TEntity> Delete(TKey entityId)
        {
            var returnValue = new ActionResponse<TEntity> { Success = true };
            var entity = DbSet.Find(entityId);
            DbSet.Remove(entity);
            returnValue.Data = entity;
            return returnValue;
        }

        public IActionResponse<IQueryable<TEntity>> GetAll()
        {
            return new ActionResponse<IQueryable<TEntity>> { Success = true, Data = DbSet };
        }

        public IActionResponse<TEntity> GetById(TKey entityId)
        {
            return new ActionResponse<TEntity> { Success = true, Data = DbSet.Find(entityId) };
        }

        public IActionResponse<TEntity> Update(TEntity entity)
        {
            var returnValue = new ActionResponse<TEntity> { Success = true };
            DbSet.Update(entity);
            returnValue.Data = entity;
            return returnValue;
        }

        public IActionResponse<int> SaveChanges()
        {
            var returnValue = new ActionResponse<int> { Success = true };
            returnValue.Data = DataContext.SaveChanges();
            return returnValue;
        }
    }
}
