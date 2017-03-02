using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
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
}
