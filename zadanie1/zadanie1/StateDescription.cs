using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class StateDescription
    {
        public StateDescription(long id, string bookDescription, DateTime purchaseDate)
        {
            Id = id;
            BookDescription = bookDescription;
            PurchaseDate = purchaseDate;
        }

        public long Id { get; }
        private string BookDescription { get; }
        private DateTime PurchaseDate { get; }
    }
}
