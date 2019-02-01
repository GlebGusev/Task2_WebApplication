using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Business.Repositories
{
    public class EFRepository<T> : Controller, IRepository<T> where T : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public EFRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            else
            {
                DbContext = dbContext;
                DbSet = DbContext.Set<T>();
            }
        }

        public IList<T> GetList(int max = 0)
        {

            var list = max > 0 ? DbSet.Take(max).ToList() : DbSet.ToList();
            return list;
        }

        public T Get(int? id)
        {
            var record = DbSet.Find(id); ;
            return record;
        }

        public void Remove(int? id)
        {
            var record = Get(id);
            DbSet.Remove(record);
        }

        public bool Edit(T record)
        {
            if (ModelState.IsValid)
            {
                DbContext.Entry(record).State = EntityState.Modified;
                return true;
            }
            return false;
        }

        public void Edit(int? id)
        {
            var record = Get(id);
            DbContext.Entry(record).State = EntityState.Modified;
        }

        public bool AddRecord(T record)
        {
            if (ModelState.IsValid)
            {
                DbSet.Add(record);
                return true;
            }
            return false;
        }
    }
}