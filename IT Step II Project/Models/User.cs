using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Step_II_Project.Models
{
    internal class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }

        public User(
            string username,
            string password,
            string passwordConfirm)
        {
            this.username = username;
            this.password = password;
            this.passwordConfirm = passwordConfirm;
         }

        public void passwordValidation(string password)
        {
            if (password.Length < 8)
            {
                throw new ArgumentException("Password must be at least 8 characters long.");
            }
            if (!password.Any(char.IsUpper))
            {
                throw new ArgumentException("Password must contain at least one uppercase letter.");
            }
            if (!password.Any(char.IsLower))
            {
                throw new ArgumentException("Password must contain at least one lowercase letter.");
            }
            if (!password.Any(char.IsDigit))
            {
                throw new ArgumentException("Password must contain at least one digit.");
            }
        }

        public void confirmPassword(string password, string passwordConfirm)
        {
            if (password != passwordConfirm)
            {
                throw new ArgumentException("Passwords do not match.");
            }
        }


        public void UserCreate()
        {
            Console.WriteLine("Please enter your username");
            username = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            password = Console.ReadLine();
            passwordValidation(password);

            Console.WriteLine("Please confirm your password");
            passwordConfirm = Console.ReadLine();
            confirmPassword(password, passwordConfirm);

            using (var sw = new StreamWriter("users.txt", true))
            {
                sw.WriteLine($"{username},{password}");
            }
        }

        public override string ToString()
        {
            return $"Username: {username}, Password: {password}";
        }
    }
}
