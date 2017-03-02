using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Book
    {
        public Book(long id, string name, string author)
        {
            Id = id;
            Name = name;
            Author = author;
        }

        private long Id { get; }
        private string Name { get; }
        private string Author { get; }
    }
}
