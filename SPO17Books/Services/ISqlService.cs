using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPO17Books.Services
{
    public interface ISqlService
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : class;
        TEntity Get<TEntity>(int id) where TEntity : class;
        //IQueryable<TEntity> Get<TEntity>(string id) where TEntity : class;
        void Add<TEntity>(TEntity item) where TEntity : class;
        void Update<TEntity>(TEntity item) where TEntity : class;
        void Delete<TEntity>(TEntity item) where TEntity : class;
    }
}
