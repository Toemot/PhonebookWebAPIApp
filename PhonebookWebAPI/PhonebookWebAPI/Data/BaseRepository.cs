﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PhonebookWebAPI.Data
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class
    {
        protected Context Context { get; private set; }

        public BaseRepository(Context context)
        {
            Context = context;
        }

        public abstract IList<TEntity> GetList();

        public abstract TEntity Get(int id);

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var set = Context.Set<TEntity>();
            var entity = set.Find(id);
            set.Remove(entity);
            Context.SaveChanges();
        }
    }
}