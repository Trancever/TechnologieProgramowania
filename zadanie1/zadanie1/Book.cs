using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Book
    {
        public Book(string name, string author)
        {
            Name = name;
            Author = author;
        }

        public string description()
        {
            return "Book name is " + Name + ". It's author name is " + Author + "\n";
        }

        private string Name { get; }
        private string Author { get; }
    }
}
