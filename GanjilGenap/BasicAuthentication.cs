using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GanjilGenap
{
    internal class BasicAuthentication
    {

        public static User tempUser = new User();
        public static UserDataManager userDataManager = new UserDataManager();

        public static void AuthenticationMenu()
        {
            bool isMenu = true;
            string menuChoice;
            do
            {
                Console.Clear();
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
                        FieldInputData(userDataManager.AddUser);
                        break;
                    case "2":
                        Console.Clear();
                        userDataManager.ShowUser();
                        UserMenu();
                        break;
                    case "3":
                        Console.Write("Masukkan Nama  :");
                        string nama = Console.ReadLine();
                        userDataManager.SearchUser(nama);
                        break;
                    case "4":
                        Console.Write("USERNAME : ");
                        string username = Console.ReadLine();
                        Console.Write("PASSWORD : ");
                        string password = Console.ReadLine();
                        userDataManager.Login(username, password);
                        break;
                    case "5":
                        Console.WriteLine("Keluar darin program");
                        isMenu = false;
                        break;
                    default:
                        Console.WriteLine("Menu Tidak Tersedia");
                        Console.ReadLine();
                        break;
                }
            } while
            (isMenu == true);
        }

        static void FieldInputData(Action<string, string, string, int> AddOrEditMethod, int id)
        {
            if (tempUser.FirstName == null && tempUser.LastName == null)
            {
                Console.Write("First Name:");
                string firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                tempUser = new User(firstName, lastName);
            }

            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (userDataManager.CheckPassword(password))
            {
                AddOrEditMethod(tempUser.FirstName, tempUser.LastName, password, id);
                tempUser.FirstName = null;
                tempUser.LastName = null;
            }
            else
            {
                Console.WriteLine("Password must have at least 8 with at least " +
                     "one Capital letter, at least one lower case letter and at least one number. ");
                FieldInputData(AddOrEditMethod, userDataManager.Users.Count + 1);
            }


        }

        static void UserMenu()
        {
            Console.WriteLine("1. Edit User");
            Console.WriteLine("2. Delete User");
            Console.WriteLine("3. Back");
            Console.Write("Pilihan: ");

            string choiceUserMenu = Console.ReadLine();

            switch (choiceUserMenu)
            {
                case "1":
                    EditUser();
                    break;
                case "2":
                    userDataManager.DeleteUser();
                    break;
                case "3":
                    break;
            }
        }

        static void EditUser()
        {
            Console.Write("ID yang ingin diubah : ");
            int idChoice = Convert.ToInt32(Console.ReadLine());
            var index = userDataManager.Users.FindIndex(x => x.Id == idChoice);
            if (index >= 0)
            {
                FieldInputData(userDataManager.UpdateUser, idChoice);
            }
        }
        static void Main(string[] args)
        {
            AuthenticationMenu();
        }
    }
}
