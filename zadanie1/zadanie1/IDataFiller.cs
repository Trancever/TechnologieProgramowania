using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public interface IDataFiller
    {
        List<Reader> getReadersList();
        Dictionary<long, Book> getBookList();
        ObservableCollection<Rental> getRentalsList();
        Dictionary<long, StateDescription> getStatesList();
    }
}
