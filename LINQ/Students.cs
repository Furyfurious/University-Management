using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public class Students
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Student {Name} with id {ID} and {Gender} and Age {Age} from university with id {UniversityId}");
        }
    }

    
}
