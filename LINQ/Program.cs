using System.Collections.Generic;
namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UniversityManager Manager = new UniversityManager();
            DataHandling Data = new();

            Data.StudentAndUniversityCollection();


        }
    }
}
