using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    interface IDataFiller
    {
        List<Reader> getReadersList();
        Dictionary<long, Book> getBookList();
        List<Rental> getRentalsList();
        Dictionary<long, StateDescription> getStatesList();
    }
}
