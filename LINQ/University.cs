using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class University
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"University {Name} with id {ID}");
        }
    }
}
