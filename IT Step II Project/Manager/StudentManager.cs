using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Step_II_Project.Manager
{
    internal class StudentManager : Icrud
    {
        private List<Models.Student> _students = new List<Models.Student>();

        public void addStudent(Models.Student student)
        {
            _students.Add(student);
        }
        
        public void showAll()
        {
            _students.ForEach(s => Console.WriteLine($"Name: {s.Name}, Roll Number: {s.RollNumber}, Grade: {s.Grade}"));
        }

        public void findStudent()
        {
            Console.WriteLine("Enter Roll Number to find student:");
            int rollNumber = int.Parse(Console.ReadLine());
            var student = _students.FirstOrDefault(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                Console.WriteLine($"Name: {student.Name}, Roll Number: {student.RollNumber}, Grade: {student.Grade}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }


        public void ChangeGrade()
        {
            Console.WriteLine("Enter Roll Number to change grade:");
            int rollNumber = int.Parse(Console.ReadLine());
            var student = _students.FirstOrDefault(s => s.RollNumber == rollNumber);
            if (student != null)
            {
                Console.WriteLine("Enter new grade (A, B, C, F):");
                char newGrade = char.Parse(Console.ReadLine());
                student.Grade = newGrade;
                Console.WriteLine("Grade updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }


    }
}
