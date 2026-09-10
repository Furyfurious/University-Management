using System;
using System.Collections.Generic;
using System.Diagnostics; // added
using System.Linq;
using System.Text;

namespace LINQ
{
    internal class UniversityManager
    {
        public List<University> Universities = new List<University>
        {
            new University { ID = 1, Name = "University of the Philippines" },
            new University { ID = 2, Name = "Ateneo de Manila University" },
            new University { ID = 3, Name = "De La Salle University" },
            new University { ID = 4, Name = "University of Santo Tomas" }
        };
        public List<Students> Students = new List<Students>
        {
            new Students { ID = 1, Name = "Juan Dela Cruz", Gender = "Male", Age = 20, UniversityId = 1 },
            new Students { ID = 2, Name = "Maria Santos", Gender = "Female", Age = 19, UniversityId = 1 },
            new Students { ID = 3, Name = "Jose Rizal", Gender = "Male", Age = 21, UniversityId = 2 },
            new Students { ID = 4, Name = "Ana Reyes", Gender = "Female", Age = 22, UniversityId = 3 },
            new Students { ID = 5, Name = "Pedro Garcia", Gender = "Male", Age = 20, UniversityId = 4 },
            new Students { ID = 6, Name = "Liza Cruz", Gender = "Female", Age = 23, UniversityId = 2 }
        };
        private DataHandling Data;
        private UniversityDisplay DisplayMenu;
        public UniversityManager()
        {
            Data = new DataHandling(Universities, Students);
            DisplayMenu = new UniversityDisplay(Data);
        }

        public void Show()
        {
            DisplayMenu.Menu();
        }
    }
  
}
