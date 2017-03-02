using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class DataRepository
    {
        public DataRepository(IDataFiller dataFiller)
        {
            DataFiller = dataFiller;
        }

        private IDataFiller DataFiller;
        private DataContext DataCtx;
    }
}
