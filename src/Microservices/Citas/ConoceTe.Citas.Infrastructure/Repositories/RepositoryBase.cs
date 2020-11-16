using ConoceTe.Citas.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConoceTe.Citas.Infrastructure.Repositories
{
    public class RepositoryBase<T>  where T : class
    {
        protected readonly CitasContext Context;
        protected readonly DbSet<T> DbSet;

        public IUnitOfWork UnitOfWork => Context;

        public RepositoryBase(CitasContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        public virtual T Add(T obj)
        {
           return DbSet.Add(obj).Entity;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(T obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(GetById(id));
        }
    }
}
