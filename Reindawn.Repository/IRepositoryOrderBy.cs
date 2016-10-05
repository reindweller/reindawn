using System;
using System.Linq;

namespace Reindawn.Repository
{
    public interface IRepositoryOrderBy<T>
    {
        IRepositoryQuery<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
    }
}
