using System;

namespace IT_Step_II_Project.Models
{
    /// <summary>
    /// Student class 
    /// </summary>
    internal class Student
    {
        /// <summary>
        /// ველები Student class-ისთვის
        /// </summary>
        private string _name;
        private int _rollNumber;
        private char _grade;

        /// <summary>
        /// Student's name property
        /// </summary>
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

        /// <summary>
        /// Student's rollnumber property
        /// </summary>
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

        /// <summary>
        /// Student's grader property
        /// </summary>
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
        
        /// <summary>
        /// უპარამეტრო კონსტრუქტორი
        /// </summary>
        public Student() { }

        /// <summary>
        /// პარამეტრიანი კონსტრუქტორი
        /// </summary>
        /// <param name="name"></param>
        /// <param name="rollNumber"></param>
        /// <param name="grade"></param>
        public Student(string name, int rollNumber, char grade)
        {
            Name = name;
            RollNumber = rollNumber;
            Grade = grade;
        }

    }
}