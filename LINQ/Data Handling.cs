using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LINQ
{
    internal class DataHandling
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

        private int ReadInt(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.Write("Invalid input, please enter a number: ");
            }
            return result;
        }



        private string ReadNonEmptyString(string prompt)
        {
            string result;
            Console.Write(prompt);
            string input = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(result = input))
            {
                Console.Write("Input cannot be empty, try again: ");
            }
            return result;
        }



        // ---------- Add methods ----------
        public void AddUniversity()
        {
            int id = ReadInt("Enter University ID: ");

            if (Universities.Any(u => u.ID == id))
            {
                var exist = Universities.First(u => u.ID == id);
                throw new DuplicateIdException($"University with ID {id} already exists. {exist.Name}");
            }

            string name = ReadNonEmptyString("Enter University Name: ");

            Universities.Add(new University { ID = id, Name = name });
            Console.WriteLine("University added successfully.");

        }


        public void AddStudent()
        {

            int id = ReadInt("Enter student ID: ");

            if (Students.Any(s => s.ID == id))
            {
                throw new DuplicateIdException($"Student with ID {id} already exists.");
            }

            string name = ReadNonEmptyString("Enter student name: ");
            string Gender = ReadNonEmptyString("Enter student gender: ");
            int Age = ReadInt("Enter student age: ");
            int uniID = ReadInt("Enter student University ID: ");

            if (!Universities.Any(s => s.ID == id))
            {
                throw new UniversityNotFoundException($"No university found with ID {uniID}.");
            }

            Students.Add(new Students { ID = id, Name = name, Gender = Gender, Age = Age, UniversityId = uniID });
        }

        //Delete Students

        public void deleteUniversity()
        {
            int deleteUniversity = ReadInt("Enter University ID to delete: ");

            if(!Universities.Any(u => u.ID == deleteUniversity))
            {
                throw new NotFoundException("University ID cannot be found");
            }

            Universities.RemoveAll(u => u.ID == deleteUniversity);
            Students.RemoveAll(s => s.UniversityId == deleteUniversity);

            Console.WriteLine("Deleted Succesfully");
        }

        public void DeleteStudent()
        {
            int deletestudent = ReadInt("Enter student ID to delete: ");

            if(!Students.Any(s => s.ID == deletestudent))
            {
                throw new NotFoundException("You can't delete student that does not exist");
            }

            Students.RemoveAll(s => s.ID == deletestudent);

            Console.WriteLine("Student Successfully deleted");
        }

        //Find Students
        public void MaleStudents()
        {
            Console.WriteLine();

            IEnumerable<Students> MaleStudents = from student in Students
                                                 where student.Gender == "Male" || student.Gender == "male"
                                                 select student;

            Console.WriteLine("Male - Students: ");

            foreach (var student in MaleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudent()
        {
            Console.WriteLine();

            IEnumerable<Students> femaleStudents = from student in Students
                                                   where student.Gender == "Female" || student.Gender == "female"
                                                   select student;

            foreach (var student in femaleStudents)
            {
                student.Print();
            }
        }

        public void SortStudentbyAge()
        {
            IEnumerable<Students> SortedAge = from student in Students
                                              orderby student.Age
                                              select student;

            Console.WriteLine("Sorted student");
            foreach (Students student in SortedAge)
            {
                student.Print();
            }
        }

        public void ShowallStudents()
        {
            Console.WriteLine();
            foreach (var student in Students)
            {
                student.Print();
            }
        }

        public void ShowUniversities()
        {
            Console.WriteLine();
            foreach (var uni in Universities)
            {
                uni.Print();
            }
        }

        public void AllUPstudents()
        {
            IEnumerable<Students> UPstudents = from student in Students
                                               join University in Universities on student.UniversityId equals University.ID
                                               where University.Name == "University of the Philippines"
                                               select student;

            foreach (var student in UPstudents)
            {
                student.Print();
            }
        }

        public void AllFromthatuni()
        {

            int find_id = DisplayRead.ReadInt("Enter id to see all student from that uni: ");

            if(!Universities.Any(u => u.ID == find_id))
            {
                throw new NotFoundException("The value you enter cannot be found");
            }

            var Allstudent = from student in Students
                               join university in Universities on student.UniversityId equals university.ID
                               where university.ID == find_id
                               select student;

            foreach (var student in Allstudent)
            {
                student.Print();
            }
        }

        public void StudentAndUniversityCollection()
        {
            var newCollection = from student in Students
                                join university in Universities on student.UniversityId equals university.ID
                                orderby student.Name
                                select new { studentName = student.Name, UniversityName = university.Name };


            foreach(var coll in newCollection)
            {
                Console.WriteLine($"Student {coll.studentName} from {coll.UniversityName}");
            }
        }
    }
}
