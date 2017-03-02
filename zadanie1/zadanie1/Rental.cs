using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Rental
    {
        public Rental(long readerId, long bookId, DateTime hireDate)
        {
            ReaderId = readerId;
            BookId = bookId;
            HireDate = hireDate;
            ReturnDate = null;
        }

        private long ReaderId { get; }
        private long BookId { get; }
        private DateTime HireDate { get; }
        private DateTime? ReturnDate { get; set; }
    }
}
