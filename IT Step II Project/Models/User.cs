using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IT_Step_II_Project.Models
{
    /// <summary>
    /// User class
    /// </summary>
    public class User
    {
        /// <summary>
        /// User class username
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// User class password
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// Gets or sets the confirmation password.
        /// </summary>
        public string passwordConfirm { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// კონსტრუქტორი რომელიც ქმნის ობიექტს
        public User() { }
        /// <summary>
        /// User class
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="passwordConfirm"></param>
        public User(
            string username,
            string password,
            string passwordConfirm)
        {
            this.username = username;
            this.password = password;
            this.passwordConfirm = passwordConfirm;
         }

        public override string ToString()
        {
            return $"Username: {username}, Password: {password}";
        }
    }
}
