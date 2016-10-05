using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Reindawn.Service
{
    public interface IEntityService<T>
    {
        T Find(Guid id);
        //IPagingQueryResult<T> GetPageResult(int skip, int take, Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetAll();
        IEnumerable<T> Filter(Expression<Func<T, bool>> filter);
        //IEnumerable<T> FilterActive();
        //IFluentEntityFilter<T> FilterBuilder();
        void Insert(T domainModel);
        void Update(T domainModel);
        void Delete(Guid id);
        //void ToogleStatus(Guid[] ids);
        void Save();
    }
}
