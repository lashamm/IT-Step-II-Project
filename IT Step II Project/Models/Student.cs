using System;

namespace IT_Step_II_Project.Models
{
    internal class Student
    {
        private string _name;
        private int _rollNumber;
        private char _grade;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                _name = value.Trim();
            }
        }

        public int RollNumber
        {
            get => _rollNumber;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(RollNumber),
                        "Roll number must be a positive integer.");
                }
                _rollNumber = value;
            }
        }

        public char Grade
        {
            get => _grade;
            set
            {
                char upperValue = char.ToUpper(value);
                if (!"AFCB".Contains(upperValue))
                {
                    throw new ArgumentException("Grade must be A, B, C, or F.");
                }
                _grade = upperValue;
            }
        }

        public Student() { }

        public Student(string name, int rollNumber, char grade)
        {
            Name = name;
            RollNumber = rollNumber;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Roll Number: {RollNumber}, Grade: {Grade}";
        }
    }
}