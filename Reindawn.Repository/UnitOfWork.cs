using System;
using System.Collections.Concurrent;
using Reindawn.Domain.Models;
using Reindawn.Repository.Context;

namespace Reindawn.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReindawnContext _context = new ReindawnContext();
        private bool _disposed;
        private ConcurrentDictionary<object, object> _repositories;
        private readonly object _lockedObject = new object();
        

        public void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new ConcurrentDictionary<object, object>();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), _context);

                lock (_lockedObject)
                {
                    _repositories.AddOrUpdate(type, repositoryInstance, (key, value) => repositoryInstance);
                }
            }

            return (IRepository<T>)_repositories[type];
        }

    }
}
