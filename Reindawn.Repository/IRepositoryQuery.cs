using System;
using System.Linq;
using System.Linq.Expressions;

namespace Reindawn.Repository
{
    public interface IRepositoryQuery<T> : IRepositoryInclude<T>, IRepositoryOrderBy<T>
    {
        IRepositoryQuery<T> Filter(Expression<Func<T, bool>> filter);
        //IRepositoryQuery<T> FilterActive();
        IQueryable<T> GetResult();
        //IQueryable<T> GetPage(int skip, int take, out int totalCount);
    }
}
