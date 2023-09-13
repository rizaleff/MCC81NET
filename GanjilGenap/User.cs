using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GanjilGenap
{
    internal class User
    {
        public int Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        

        public User(string firstName, string lastName, string password, int id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = firstName.Substring(0,2)+lastName.Substring(0,2);
            Password = password ;
        }

        public void Authentication(string username, string password)
        {

        }
    }
}
