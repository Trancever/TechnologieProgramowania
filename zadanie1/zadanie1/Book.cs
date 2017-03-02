using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Book
    {
        private static long numberOfInstances = 0;

        public Book(string name, string author)
        {
            Id = ++numberOfInstances;
            Name = name;
            Author = author;
        }

        public long Id { get; }
        private string Name { get; }
        private string Author { get; }
    }
}
