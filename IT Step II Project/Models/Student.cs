using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Step_II_Project.Models
{
    internal class Student
    {
        private string _name;
        private int _rollNumber;
        private char _grade;

        public string Name { 
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value;
            }
        }
        public int RollNumber {
            get => _rollNumber;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("RollNumber must be a positive integer.");
                }
            } 
        }
        public char Grade {
            get => _grade;
            set
            {
                if(value != 'A' || value != 'F' || value != 'C' || value != 'B')
                {
                    throw new ArgumentException("Wrong grade");
                }
            }
        }
    }
}
