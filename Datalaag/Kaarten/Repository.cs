using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalaag.Kaarten
{
    public class Repository<T> where T : class
    {
        protected KaartenEntities Context;
        protected DbSet<T> DbSet { get; set; }

        public Repository()
        {
            Context = new KaartenEntities();
            DbSet = Context.Set<T>();
        }

        public Repository(KaartenEntities context)
        {
            Context = context;
        }

        public List<T> Get()
        {
            return DbSet.ToList();
        }

        public T Get(long id)
        {
            return DbSet.Find(id);
        }

        public void AddOrUpdate(T entity)
        {
            DbSet.AddOrUpdate(entity);
            Context.SaveChanges();
        }

        public void Save(T entity)
        {
            AddOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
            Context.SaveChanges();
        }
        public void Delete(long id)
        {
            DbSet.Remove(DbSet.Find(id));
            Context.SaveChanges();
        }
    }
}