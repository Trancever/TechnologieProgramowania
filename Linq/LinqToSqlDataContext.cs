using System.Data.Linq;
using System.Linq;

namespace Linq
{
    public class LinqToSqlDataContext : IDataContext
    {
        private readonly DataClasses1DataContext DataCtx;

        public LinqToSqlDataContext(DataClasses1DataContext context)
        {
            DataCtx = context;
        }

        public IQueryable<T> Repository<T>() where T : class
        {
            Table<T> table = DataCtx.GetTable<T>();
            return table;
        }

        public void Insert<T>(T item) where T : class
        {
            Table<T> table = DataCtx.GetTable<T>();

            table.InsertOnSubmit(item);
        }

        public void Delete<T>(T item) where T : class
        {
            Table<T> table = DataCtx.GetTable<T>();

            table.DeleteOnSubmit(item);
        }

        public void SubmitChanges()
        {
            DataCtx.SubmitChanges();
        }
    }
}