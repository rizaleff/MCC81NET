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

namespace GanjilGenap
{
    internal class BasicAuthentication
    {
        public static List<User> users = new List<User>();
        public static string firstName;
        public static string lastName;
        public static string password;
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
                        try
                        {
                            InputUser("add", users.Count + 1);
                        }
                        catch
                        {
                            Console.WriteLine("Input Tidak Valid");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        ShowUser();
                        break;
                    case "3":
                        Console.Write("Masukkan Nama  :");
                        string nama = Console.ReadLine();
                        SearchUser(nama);
                        break;
                    case "4":
                        Console.Write("USERNAME : ");
                        string username = Console.ReadLine();
                        Console.Write("PASSWORD : ");
                        string password = Console.ReadLine();
                        Login(username, password);
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
        static void AddUser(string firstName, string lastName, string password, int id)
        {
            User user = new User(firstName, lastName, password, id);
            users.Add(user);
            Console.WriteLine("Data User Berhasil Dibuat");
            Console.ReadLine();

        }

        static void ShowUser()
        {
            Console.WriteLine("=====SHOW USER====");
            foreach (User userItem in users)
            {
                Console.WriteLine("======================");
                Console.WriteLine($"ID          : {userItem.Id}");
                Console.WriteLine($"Nama        : {userItem.FirstName} {userItem.LastName}");
                Console.WriteLine($"Username    : {userItem.Username}");
                Console.WriteLine($"Password    : {userItem.Password}");
                Console.WriteLine("======================");
            }
            UserMenu();
        }
        static void CheckPassword(string action, int id)
        {
            Console.Write("Password: ");
            password = Console.ReadLine();
            string pattern = @"(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}";
            bool isValid;

            Regex regex = new Regex(pattern);
            isValid = regex.IsMatch(password);
            if (isValid)
            {
                if (action.Equals("add"))
                {
                    AddUser(firstName, lastName, password, id);
                }
                else
                {
                    UpdateUser(firstName, lastName, password, id);
                }
            }
            else
            {
                Console.WriteLine("Password must have at least 8 with at least " +
                     "one Capital letter, at least one lower case letter and at least one number. ");
                CheckPassword(action, id);
            }
        }
        static void InputUser(string action, int id)
        {
            Console.Write("First Name:");
            firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            lastName = Console.ReadLine();
            CheckPassword(action, id);
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
                    DeleteUser();
                    break;
                case "3":
                    break;
            }
        }

        static void DeleteUser()
        {
            Console.WriteLine("ID yang ingin dihapus: ");
            try
            {
                int idChoice = Convert.ToInt32(Console.ReadLine());
                var index = users.FindIndex(x => x.Id == idChoice);
                //users.Single(x => x.Id == idChoice) != null
                if (index >= 0)
                {
                    users.RemoveAt(idChoice - 1);
                    Console.WriteLine("Data Berhasil Di Hapus");
                    Console.ReadLine();
                    ShowUser();
                }
                else
                {
                    Console.WriteLine("User Tidak Ditemukan");
                    DeleteUser();
                }

            }
            catch
            {
                Console.WriteLine("Input ID Harus Berupa Angka!!1");
            }
        }

        static void EditUser()
        {
            Console.Write("ID yang ingin diubah : ");
            int idChoice = Convert.ToInt32(Console.ReadLine());
            var index = users.FindIndex(x => x.Id == idChoice);
            //users.Single(x => x.Id == idChoice) != null
            if (index >= 0)
            {
                InputUser("edit", users.Count - 1);
            }
        }

        static void UpdateUser(string firstName, string lastName, string password, int id)
        {
            users[id].FirstName = firstName;
            users[id].LastName = lastName;
            users[id].Password = password;
            users[id].CreateUsername(firstName, lastName);
            Console.WriteLine("Data User Berhasil Diupdate");
            Console.ReadLine();
        }

        static void Login(string username, string password)
        {

            User user = users.FirstOrDefault(x => x.Username == username);

            if (user != null)
            {

                if (user.Password.Equals(password))
                {
                    Console.WriteLine($"Selamat {user.FirstName} {user.LastName}, Anda Berhasil");
                    Console.WriteLine("Tekan Enter Untuk Menuju Program Ganjil Genap");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("=========================================");
                    Console.WriteLine($"Selamat Datang {user.FirstName} {user.LastName}");
                    Console.WriteLine("=========================================");
                    Program.Menu();
                }
                else
                {
                    Console.WriteLine("Password Salah");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Username Tidak Ditemukan");
            }

        }

        static void SearchUser(string name)
        {

            bool exists = (users.Any(x => x.FirstName.Contains(name)) || users.Any(x => x.LastName.Contains(name)));

            if (exists)
            {
                foreach (User userItem in users)
                {
                    if (userItem.FirstName.Contains(name) || userItem.LastName.Contains(name))
                    {
                        Console.WriteLine("======================");
                        Console.WriteLine($"ID          : {userItem.Id}");
                        Console.WriteLine($"Nama        : {userItem.FirstName} {userItem.LastName}");
                        Console.WriteLine($"Username    : {userItem.Username}");
                        Console.WriteLine($"Password    : {userItem.Password}");
                        Console.WriteLine("======================");

                    }
                }
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Akun Tidak Ditemukan");
                Console.ReadLine();
            }


        }
        static void Main(string[] args)
        {

            AuthenticationMenu();
        }
    }
}
