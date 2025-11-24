using IT_Step_II_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IT_Step_II_Project.Manager
{
    public class UserManager
    {
        private List<User> _users = new List<User>();
        private readonly string _filePath;

        public UserManager()
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string dataFolder = Path.Combine(projectRoot, "Data");

            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            _filePath = Path.Combine(dataFolder, "User.json");

            LoadUserData();
        }

        private bool UsernameExists(string username)
        {
            return _users.Any(u => u.username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
        public void UserCreate()
        {
            string username;

            while (true)
            {
                Console.WriteLine("Please enter your username");
                username = Console.ReadLine();

                if (UsernameExists(username))
                {
                    Console.WriteLine($"Username '{username}' is already taken. Please try a different username.");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            PasswordValidation(password);

            Console.WriteLine("Please confirm your password");
            string passwordConfirm = Console.ReadLine();
            ConfirmPassword(password, passwordConfirm);

            User newUser = new User(username, password, passwordConfirm);
            _users.Add(newUser);
            SaveUserData();

            Console.WriteLine("User created successfully!");
        }

        private void PasswordValidation(string password)
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

        private void ConfirmPassword(string password, string passwordConfirm)
        {
            if (password != passwordConfirm)
            {
                throw new ArgumentException("Passwords do not match.");
            }
        }

        private void SaveUserData()
        {
            Console.WriteLine($"Saving to: {_filePath}");
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(_users, jsonOptions);
            File.WriteAllText(_filePath, jsonString);
        }

        private void LoadUserData()
        {
            if (File.Exists(_filePath)) 
            {
                var jsonString = File.ReadAllText(_filePath); 
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    _users = JsonSerializer.Deserialize<List<User>>(jsonString) ?? new List<User>();
                }
            }
        }
        public List<User> GetAllUsers()
        {
            return _users;
        }

        public bool UserLogin(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.username.Equals(username, StringComparison.OrdinalIgnoreCase)
                                               && u.password == password);
            if (user != null)
            {
                Console.WriteLine("Login successful!");
                return true;
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
                return false;
            }
        }
    }
}
