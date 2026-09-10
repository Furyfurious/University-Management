using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LINQ
{
    internal class DataHandling
    {

        private List<University> Universities;
        private List<Students> Students;

        public DataHandling(List<University> university, List<Students> students)
        {
            this.Universities = university;
            this.Students = students;
        }

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
                                                   where student.Gender == "Female"
                                                   select student;

            foreach (var student in femaleStudents)
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
    }
}
