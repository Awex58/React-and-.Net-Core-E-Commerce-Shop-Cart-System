﻿using Case1.Core.Entities.Abstract;
using Case1.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Case1.Data.Respository
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRespository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : dbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addEntity = context.Entry(entity);
                addEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {

            using (var context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }


        }

        public void Delete(TEntity entity)
        {


            using (var context = new TContext())
            {
                var delEntity = context.Entry(entity);
                delEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
