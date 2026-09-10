using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace LINQ
{
    internal class UniversityDisplay
    {
        private DataHandling Data;
        public UniversityDisplay(DataHandling Data)
        {
            this.Data = Data;
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

                string[] choice = { "Add University", "Add Student", "Show Student", "Show all Universities", "Exit" };

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
                                Data.AddUniversity();
                                break;
                            }

                        case 2:
                            {
                                Data.AddStudent();
                                break;
                            }

                        case 3:
                            {
                                AllstudentSubmenu();
                                break;
                            }

                        case 4:
                            {
                                Data.ShowUniversities();
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
                catch (UniversityNotFoundException ex)
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
                catch (Exception ex)
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
            int choose = DisplayRead.ReadInt("Your choice: ");
            switch (choose)
            {
                case 1:
                    {
                        Data.MaleStudents();
                        break;
                    }
                case 2:
                    {
                        Data.FemaleStudent();
                        break;
                    }
                case 3:
                    {
                        Data.ShowallStudents();
                        break;
                    }
                default:
                    {
                        throw new FormatException($"{choose} is not valid please choose only 1-4");
                    }
            }
        }
    }
}
