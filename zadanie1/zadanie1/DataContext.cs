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
        public List<Reader> ReadersCatalog;
        public Dictionary<long, Book> BookCatalog;
        public ObservableCollection<Rental> RentalCatalog;
        public Dictionary<long, StateDescription> StateCatalog;
    }
}
