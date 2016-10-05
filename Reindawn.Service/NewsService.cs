using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Reindawn.Domain.Models;
using Reindawn.Repository;

namespace Reindawn.Service
{

    public class NewsService : AbstractEntityService<News>
    {
        public NewsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected override Expression<Func<News, bool>> FindEntityPrimaryById(Guid id)
        {
            return o => o.Id == id;
        }

        protected override Expression<Func<News, object>>[] Include()
        {
            return null;
        }

        protected override IOrderedQueryable<News> OrderBy(IQueryable<News> arg)
        {
            return arg.OrderByDescending(o => o.DatePosted);
        }

    }
}
