using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RemoteController.Data.Context;
using RemoteController.Domain.Interfaces;

namespace RemoteController.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly RemoteControllerContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(RemoteControllerContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<TEntity>();
        }

        public void Dispose()
        {
            DbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(Guid id)
        {
            DbContext.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
    }
}
