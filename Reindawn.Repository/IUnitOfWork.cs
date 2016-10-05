namespace Reindawn.Repository
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose(bool disposing);
        IRepository<T> Repository<T>() where T : class;
    }
}
