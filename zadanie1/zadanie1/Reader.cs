﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class Reader
    {
        private static long NumberOfInstances = 0;

        public Reader(string firstName, string lastName, int age)
        {
            Id = NumberOfInstances++;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string description()
        {
            return "Book name is " + FirstName + ". It's author name is " + LastName + "\n";
        }

        private long Id { get; }
        private string FirstName { get; }
        private string LastName { get; }
        private int Age { get; }
    }
}
