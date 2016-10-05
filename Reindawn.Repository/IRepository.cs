using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Reindawn.Repository
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll { get; }
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(object id);
        //T Find<TKey>(TKey id);
        IQueryable<T> Find(Expression<Func<T, bool>> filter);
        void Insert(T domainModel);
        void InsertRange(IEnumerable<T> items);
        void Update(T domainModel);
        void Delete(object id);
        void DeleteRange(IEnumerable<T> items);
        //void Delete<TKey>(TKey id);
        IRepositoryQuery<T> Query();


    }
}
