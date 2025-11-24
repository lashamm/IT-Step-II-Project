using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace IT_Step_II_Project.Models
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }

        public User() { }
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
