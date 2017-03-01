using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Reader
    {
        public Reader(string firstName, string lastName)
        {
            Firstname = firstName;
            LastName = lastName;
        }

        private string Firstname { get; }
        private string LastName { get; }
    }
}
