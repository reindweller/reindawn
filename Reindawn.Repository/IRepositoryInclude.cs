using System;
using System.Linq.Expressions;

namespace Reindawn.Repository
{
    public interface IRepositoryInclude<T>
    {
        IRepositoryQuery<T> Include(Expression<Func<T, object>>[] expression);
        IRepositoryQuery<T> Include(Expression<Func<T, object>> expression);
    }
}
