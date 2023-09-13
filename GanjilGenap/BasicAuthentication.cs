using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GanjilGenap
{
    internal class BasicAuthentication
    {
        public static List<User> users = new List<User>();
        public static string firstName;
        public static string lastName;
        public static string password;
        static void AuthenticationMenu()
        {
            bool isMenu = true;
            string menuChoice;
            do
            {
                Console.WriteLine("== BASIC AUTHENTICATION ==");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Show User");
                Console.WriteLine("3. Search User");
                Console.WriteLine("4. Login User");
                Console.WriteLine("5. Exit");
                Console.Write("Input :");
                
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        try
                        {
                            InputUser();
                        }
                        catch
                        {
                            Console.WriteLine("Input Tidak Valid");
                        }
                        break;
                        case "2":
                        ShowUser();
                        break;
                        case "3":
                        break;
                        case "4":
                        break;
                        case "5":

                            isMenu = false;
                        break;
                        default:
                        Console.WriteLine("Menu Tidak Tersedia");
                        break;
                }
            }while 
            (isMenu == true);
        }
        static void AddUser(string firstName, string lastName, string password)
        {
            User user = new User(firstName,lastName, password, users.Count + 1);
            users.Add(user);
            
            
        }

        static void ShowUser()
        {
            foreach (User userItem in users)
            {
                Console.WriteLine("======================");
                Console.WriteLine($"ID          : {userItem.Id}");
                Console.WriteLine($"Nama        : {userItem.FirstName} {userItem.LastName}");
                Console.WriteLine($"Username    : {userItem.Username}");
                Console.WriteLine($"Password    : {userItem.Password}");
                Console.WriteLine("======================");
            }
        }
        static void CheckPassword()
        {
            Console.Write("Password: ");
            password = Console.ReadLine();
            string pattern = @"(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}";
            bool isValid;

            Regex regex = new Regex(pattern);
            isValid = regex.IsMatch(password);
            if (!isValid)
            {
               Console.WriteLine("Password must have at least 8 with at least " +
                    "one Capital letter, at least one lower case letter and at least one number. ");
                CheckPassword();
            }
            else
            {
                AddUser(firstName, lastName, password);
            }
        }
        static void InputUser()
        {
            Console.Write("First Name:");
            firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            lastName = Console.ReadLine();
            CheckPassword();
        }
        static void Main(string[] args)
        {
            
            AuthenticationMenu();
        }
    }
}
