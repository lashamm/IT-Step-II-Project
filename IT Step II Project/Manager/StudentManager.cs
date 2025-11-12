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
            Console.WriteLine("Enter Student Name:");
            student.Name = Console.ReadLine();
            Console.WriteLine("Enter Roll Number:");
            student.RollNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Grade (A, B, C, F):");
            student.Grade = char.Parse(Console.ReadLine());


            _students.Add(student);
        }
        
        public void showAll(Models.Student student)
        {
            _students.ForEach(student => Console.WriteLine($"Name: {student.Name}, Roll Number: {student.RollNumber}, Grade: {student.Grade}"));
        }

        public void findStudent(Models.Student student)
        {
            Console.WriteLine("Enter Roll Number to find student:");
            int rollNumber = int.Parse(Console.ReadLine());
            student = _students.FirstOrDefault(s => s.RollNumber == rollNumber);
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
