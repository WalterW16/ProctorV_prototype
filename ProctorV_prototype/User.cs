using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities
{
    internal class User
    {
        private string username;
        private string password;
        private string email;
        private string firstName;
        private string lastName;
        private string phone_number;
        private string role;
        
        public User() {
            username = "User";
            firstName = "noName";
            lastName = "noSurname";
            Password = "noPassword";
            Email = "mnoEmail@";
            phone_number = "noPhoneNumber";
            role = "unknown";
        }

        public User(string username, string password, string email, string phone_number, string firstName, string lastName,  string role)
        {
            Username = username;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone_number = phone_number;
            Role = role;
            
        }
        public User(User obj)
        {
            this.username = obj.username;
            this.password = obj.password;
            this.email = obj.email;
            this.firstName = obj.firstName;
            this.lastName = obj.lastName;
            this.phone_number = obj.phone_number;
            this.role = obj.role;
        }
    

         public User GetThis()
        {
            return this;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Role { get => role; set => role = value; }
        public string Email {
            get { return email; }
            set
            {
                if (value.Contains("@"))
                    email = value;
                else
                    throw new ArgumentException("Invalid email address");
            }
        }

      
    }
}
