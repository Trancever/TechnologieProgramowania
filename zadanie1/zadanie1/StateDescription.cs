using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class StateDescription
    {
        public StateDescription(long id, string bookDescription, DateTime purchaseDate)
        {
            Id = id;
            BookDescription = bookDescription;
            PurchaseDate = purchaseDate;
        }

        private long Id { get; }
        private string BookDescription { get; }
        private DateTime PurchaseDate { get; }
    }
}
