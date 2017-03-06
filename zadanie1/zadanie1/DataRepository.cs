using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class DataRepository
    {
        public DataRepository(IDataFiller dataFiller)
        {
            DataFiller = dataFiller;
            DataCtx = new DataContext();
        }

        public class DataContext
        {
            public DataContext()
            {
                ReadersCatalog = new List<Reader>();
                BookCatalog = new Dictionary<long, Book>();
                RentalCatalog = new ObservableCollection<Rental>();
                StateCatalog = new Dictionary<long, StateDescription>();
            }

            public List<Reader> ReadersCatalog;
            public Dictionary<long, Book> BookCatalog;
            public ObservableCollection<Rental> RentalCatalog;
            public Dictionary<long, StateDescription> StateCatalog;
        }

        private void setDataContext()
        {
            DataCtx.BookCatalog = DataFiller.getBookList();
            DataCtx.ReadersCatalog = DataFiller.getReadersList();
            DataCtx.RentalCatalog = DataFiller.getRentalsList();
            DataCtx.StateCatalog = DataFiller.getStatesList();
        }

        private IDataFiller DataFiller;
        public DataContext DataCtx { get; }

        /*********************************
         *       C.R.U.D. methods        *
         ********************************/
        public void AddBook(Book book)
        {
            DataCtx.BookCatalog.Add(book.Id, book);
        }

        public Book getBook(int id)
        {
            Book book;
            if(!DataCtx.BookCatalog.TryGetValue(id, out book))
            {
                throw new KeyNotFoundException("BookCatalog does not contain such key - \"" +  id + "\"");
            }
            return book;
        }

        public List<Book> getAllBooks()
        {
            Console.WriteLine("Here");
            return DataCtx.BookCatalog.Values.ToList<Book>();
        }

        public void updateBook(int id, Book book)
        {
            try
            {
                DataCtx.BookCatalog[id] = book;
            }
            catch (KeyNotFoundException exception)
            {
                throw exception;
            }
        }

        public void removeBook(int id)
        {
            if(!DataCtx.BookCatalog.Remove(id))
            {
                throw new KeyNotFoundException("BookCatalog does not contain such key - \"" + id + "\"");
            }
        }
    }
}
