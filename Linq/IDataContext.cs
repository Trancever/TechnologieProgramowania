using System.Linq;

namespace Linq
{
    public interface IDataContext
    {
        IQueryable<T> Repository<T>() where T : class;

        void Insert<T>(T item) where T : class;

        void Delete<T>(T item) where T : class;

        void SubmitChanges();
    }
}