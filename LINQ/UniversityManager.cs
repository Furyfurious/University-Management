using System;
using System.Collections.Generic;
using System.Diagnostics; // added
using System.Linq;
using System.Text;

namespace LINQ
{
    public class UniversityManager
    {
        public List<University> Universities = new List<University>();
        public List<Students> Students = new List<Students>();

        public UniversityManager()
        {
            DefaultData();
        }


        private void DefaultData()
        {
            Universities.Add(new University { ID = 1, Name = "University of the Philippines" });
            Universities.Add(new University { ID = 2, Name = "Ateneo de Manila University" });
            Universities.Add(new University { ID = 3, Name = "De La Salle University" });
            Universities.Add(new University { ID = 4, Name = "University of Santo Tomas" });

            Students.Add(new Students { ID = 1, Name = "Juan Dela Cruz", Gender = "Male", Age = 20, UniversityId = 1 });
            Students.Add(new Students { ID = 2, Name = "Maria Santos", Gender = "Female", Age = 19, UniversityId = 1 });
            Students.Add(new Students { ID = 3, Name = "Jose Rizal", Gender = "Male", Age = 21, UniversityId = 2 });
            Students.Add(new Students { ID = 4, Name = "Ana Reyes", Gender = "Female", Age = 22, UniversityId = 3 });
            Students.Add(new Students { ID = 5, Name = "Pedro Garcia", Gender = "Male", Age = 20, UniversityId = 4 });
            Students.Add(new Students { ID = 6, Name = "Liza Cruz", Gender = "Female", Age = 23, UniversityId = 2 });
        }

        // Loops until the user enters a valid int.
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
        private void AddUniversity()
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


        private void AddStudent()
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


        private void MaleStudents()
        {
            Console.WriteLine();

            IEnumerable<Students> MaleStudents = from student in Students
                                                 where student.Gender == "Male" || student.Gender == "male"
                                                 select student;

            Console.WriteLine("Male - Students: ");

            foreach(var student in MaleStudents)
            {
                student.Print();
            }
        }

        private void FemaleStudent()
        {
            Console.WriteLine();

            IEnumerable<Students> femaleStudents = from student in Students
                                                   where student.Gender == "Female"
                                                   select student;

            foreach(var student in femaleStudents)
            {
                student.Print();
            }
        }

        private void ShowallStudents()
        {
            Console.WriteLine();
            foreach(var student in Students)
            {
                student.Print();
            }
        }

        private void ShowUniversities()
        {
            Console.WriteLine();
            foreach(var uni in Universities)
            {
                uni.Print();
            }
        }

        public void Menu()
        {

            Trace.Listeners.Add(new ConsoleTraceListener());

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine();

                Console.WriteLine("*******************************");
                Console.WriteLine("*      UNIVERSITY MANAGER     *");
                Console.WriteLine("*******************************");

                Console.WriteLine();

                string[] choice = { "Add University", "Add Student","Show Student","Show all Universities", "Exit" };

                for (int i = 0; i < choice.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(i + 1);
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($". {choice[i]}");
                    Console.ResetColor();
                }

                Console.WriteLine();

                Console.Write("Select (1-5) : ");
                string decision = Console.ReadLine();
                try
                {
                    if (!int.TryParse(decision, out int select))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please choose 1-4");
                        continue;
                    }


                    switch (select)
                    {
                        case 1:
                            {
                                AddUniversity();
                                break;
                            }

                        case 2:
                            {
                                AddStudent();
                                break;
                            }

                        case 3:
                            {
                                AllstudentSubmenu();
                                break;
                            }

                        case 4:
                            {
                                ShowUniversities();
                                break;
                            }
                        case 5:
                            {
                                isRunning = false;
                                break;
                            }

                        default:
                            {
                                throw new FormatException($"{select} is not a valid operation choose only (1-4)");
                            }
                    }
                }

                catch (DuplicateIdException ex)
                {
                    Highlight.Error(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("Stack Trace");
                    Trace.WriteLine(ex);
                }
                catch(UniversityNotFoundException ex)
                {
                    Highlight.Error(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("Stack Trace");
                    Trace.WriteLine(ex);
                }

                catch (ArgumentNullException ex)
                {
                    Highlight.Error(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("Stack Trace");
                    Trace.WriteLine(ex);
                }
                catch (FormatException ex)
                {
                    Highlight.Error(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("Stack Trace");
                    Trace.WriteLine(ex);
                }
                catch(Exception ex)
                {
                    Highlight.Error(ex.Message);
                    Console.WriteLine();
                    Console.WriteLine("Stack Trace");
                    Trace.WriteLine(ex);
                }

            }

        }

        private void AllstudentSubmenu()
        {
            Console.WriteLine("1.Male Students");
            Console.WriteLine("2.Female Students");
            Console.WriteLine("3.All students");
            Console.Write("Your choice: ");
            int choose = ReadInt("Your choice: ");
            switch (choose)
            {
                case 1:
                    {
                        MaleStudents();
                        break;
                    }
                case 2:
                    {
                        FemaleStudent();
                        break;
                    }
                case 3:
                    {
                        ShowallStudents();
                        break;
                    }
                default:
                    {
                        throw new FormatException($"{choose} is not valid please choose only 1-4");
                    }
            }
        }
    }

    public class DataHandling
    {
    }
}
