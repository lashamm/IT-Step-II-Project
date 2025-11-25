using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;  
using IT_Step_II_Project.Models;

namespace IT_Step_II_Project.Manager
{
    internal class StudentManager : Icrud
    {
        private List<Student> _students;
        private readonly string _filePath;

        public StudentManager()
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string dataFolder = Path.Combine(projectRoot, "Data");

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            _filePath = Path.Combine(dataFolder, "Students.json");
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            if (File.Exists(_filePath))
            {
                var jsonString = File.ReadAllText(_filePath);
            }
        }

        public void AddStudent()
        {
            try
            {
                Console.WriteLine("=== Add New Student ===");

                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine()??string.Empty;

                Console.Write("Enter Roll Number: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber))
                {
                    Console.WriteLine("Invalid roll number. Please enter a number.");
                    return;
                }
                
                if (_students.Any(s => s.RollNumber == rollNumber))
                {
                    Console.WriteLine("A student with this roll number already exists.");
                    return;
                }

                Console.Write("Enter Grade (A, B, C, F): ");
                if (!char.TryParse(Console.ReadLine(), out char grade))
                {
                    Console.WriteLine("Invalid grade.");
                    return;
                }

                var student = new Student(name, rollNumber, grade);
                _students.Add(student);

                Console.WriteLine("Student added successfully!");

                Console.WriteLine($"Saving to: {_filePath}");
                var jsonOptions = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                var jsonString = JsonSerializer.Serialize(_students, jsonOptions);
                File.WriteAllText(_filePath, jsonString);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public void ShowAll()
        {
            if (_students.Count == 0)
            {
                Console.WriteLine("No students to display.");
                return;
            }

            Console.WriteLine("\n=== All Students ===");
            Console.WriteLine($"{"Name",-20} {"Roll Number",-15} {"Grade",-10}");
            Console.WriteLine(new string('-', 45));

            foreach (var student in _students)
            {
                Console.WriteLine($"{student.Name,-20} {student.RollNumber,-15} {student.Grade,-10}");
            }

            Console.WriteLine($"\nTotal Students: {_students.Count}");
        }

        public void FindStudent()
        {
            try
            {
                Console.Write("Enter Roll Number to find student: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber))
                {
                    Console.WriteLine("Invalid roll number.");
                    return;
                }

                var student = _students.FirstOrDefault(s => s.RollNumber == rollNumber);

                if (student != null)
                {
                    Console.WriteLine("\n=== Student Found ===");
                    Console.WriteLine($"Name: {student.Name}");
                    Console.WriteLine($"Roll Number: {student.RollNumber}");
                    Console.WriteLine($"Grade: {student.Grade}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ChangeGrade()
        {
            try
            {
                Console.Write("Enter Roll Number to change grade: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber))
                {
                    Console.WriteLine("Invalid roll number.");
                    return;
                }

                var student = _students.FirstOrDefault(s => s.RollNumber == rollNumber);

                if (student != null)
                {
                    Console.WriteLine($"Current grade: {student.Grade}");
                    Console.Write("Enter new grade (A, B, C, F): ");

                    if (!char.TryParse(Console.ReadLine(), out char newGrade))
                    {
                        Console.WriteLine("Invalid grade.");
                        return;
                    }

                    student.Grade = newGrade;
                    Console.WriteLine("Grade updated successfully!");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        public void DeleteStudent()
        {
            try
            {
                Console.Write("Enter Roll Number to delete student: ");
                if (!int.TryParse(Console.ReadLine(), out int rollNumber))
                {
                    Console.WriteLine("Invalid roll number.");
                    return;
                }

                var student = _students.FirstOrDefault(s => s.RollNumber == rollNumber);

                if (student != null)
                {
                    Console.Write($"Are you sure you want to delete {student.Name}? (Y/N): ");
                    char confirmation = char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();

                    if (confirmation == 'Y')
                    {
                        _students.Remove(student);
                        Console.WriteLine("Student deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled.");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}