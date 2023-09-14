using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GanjilGenap
{
    internal class User
    {
        public int Id {  get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; private set; }
        public string Password { get; set; }
        

        public User(string firstName, string lastName, string password, int id)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CreateUsername(firstName, lastName);
            Password = password ;
        }
        
        public User(string firstName, string lastName) 
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public User() { }
        public void CreateUsername(string firstName, string lastName)
        {
            try
            {
                
                Username = firstName.Substring(0, 2) + lastName.Substring(0, 2) + Id;
            }
            catch
            {
                Console.WriteLine("First Name atau Last Name minimal terdiri dari 2 huruf");
            }
        }

        public void GetUser()
        {
            Console.WriteLine("======================");
            Console.WriteLine($"ID          : {Id}");
            Console.WriteLine($"Nama        : {FirstName} {LastName}");
            Console.WriteLine($"Username    : {Username}");
            Console.WriteLine($"Password    : {Password}");
            Console.WriteLine("======================");
        }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }    
    }
}
