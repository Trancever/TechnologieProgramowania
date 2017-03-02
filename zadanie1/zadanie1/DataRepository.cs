using System;
using System.Collections.Generic;
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

            DataCtx.BookCatalog = DataFiller.getBookList();
            DataCtx.ReadersCatalog = DataFiller.getReadersList();
            DataCtx.RentalCatalog = DataFiller.getRentalsList();
            DataCtx.StateCatalog = DataFiller.getStatesList();
        }

        private IDataFiller DataFiller;
        private DataContext DataCtx;

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
                throw new Exception("BookCatalog does not contain such key - \"" +  id + "\"");
            }
            return book;
        }

        public List<Book> getAllBooks()
        {
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
                throw new Exception("BookCatalog does not contain such key - \"" + id + "\"");
            }
        }
    }
}
