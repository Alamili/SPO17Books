using SPO17Books.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPO17Books.Services
{
    public class SqlService : ISqlService
    {
        public ApplicationDbContext _db { get; set; }
        public SqlService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add<TEntity>(TEntity item) where TEntity : class
        {
            _db.Add(item);
            _db.SaveChanges();
        }

        public void Delete<TEntity>(TEntity item) where TEntity : class
        {
            _db.Remove(item);
            _db.SaveChanges();
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : class
        {
            return _db.Set<TEntity>();
        }

        public void Update<TEntity>(TEntity item) where TEntity : class
        {
            _db.Update(item);
            _db.SaveChanges();

        }

        public TEntity Get<TEntity>(int id) where TEntity : class
        {
            return _db.Set<TEntity>().Find(id);
        }

        //public IQueryable<TEntity> Get<TEntity>(string id) where TEntity : class
        //{
        //    return _db.Set<TEntity>().Find(id);
        //}
    }
}
