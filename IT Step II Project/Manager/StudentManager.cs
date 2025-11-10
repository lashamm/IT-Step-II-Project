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



    }
}
