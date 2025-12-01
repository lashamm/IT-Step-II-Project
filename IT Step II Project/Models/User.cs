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

        //////  ინკაფსულაცია
        public string username { get; set; }
        /// <summary>
        /// User class property password
        /// </summary>
        public string password { get; set; }
        /// <summary>
        /// Property that gets or sets the confirmation password.
        /// </summary>
        public string passwordConfirm { get; set; }
        //////


        //// პოლიმორფიზმი overloading
        /// <summary>
        /// კონსტრუქტორი User class-ისთვის
        /// </summary>
        /// კონსტრუქტორი რომელიც ქმნის ობიექტს
        public User() { }
        /// <summary>
        /// User class კონსტრუქტორი
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
        ////

    }
}
