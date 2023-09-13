using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanjilGenap
{
    internal class User
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        

        public User(string firstName, string lastName, string password)
        {
            Name = $"{firstName} {lastName}";

            Password = password ;
        }

        public void Authentication(string username, string password)
        {

        }
    }
}
