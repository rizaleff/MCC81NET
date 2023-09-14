using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GanjilGenap
{
    internal class UserDataManager
    {
        public List<User> Users { get; set; }
        public UserDataManager() 
        {
            Users = new List<User>();
        }
        public void AddUser(string firstName, string lastName, string password, int id)
        {
            User user = new User(firstName, lastName, password, id);
            Users.Add(user);
            Console.WriteLine("Data User Berhasil Dibuat");
            Console.ReadLine();
        }
        public void ShowUser()
        {
            Console.WriteLine("=====SHOW USER====");
            foreach (User userItem in Users)
            {

                userItem.GetUser();

            }
        }

        public void DeleteUser()
        {
            Console.WriteLine("ID yang ingin dihapus: ");
            try
            {
                int idChoice = Convert.ToInt32(Console.ReadLine());
                var index = Users.FindIndex(x => x.Id == idChoice);
                if (index >= 0)
                {
                    Users.RemoveAt(idChoice - 1);
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

        public void UpdateUser(string firstName, string lastName, string password, int id)
        {
            Users[id].FirstName = firstName;
            Users[id].LastName = lastName;
            Users[id].Password = password;
            Users[id].CreateUsername(firstName, lastName);
            Console.WriteLine("Data User Berhasil Diupdate");
            Console.ReadLine();
        }

        public void SearchUser(string name)
        {
            bool exists = Users.Any(x => x.GetFullName().Contains(name, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                foreach (User userItem in Users)
                {
                    if (userItem.GetFullName().Contains(name, StringComparison.OrdinalIgnoreCase))
                    {

                        userItem.GetUser();
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

        public void Login(string username, string password)
        {

            User user = Users.FirstOrDefault(x => x.Username == username);

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
                    GanjilGenapProgram ganjilGenapProgram = new GanjilGenapProgram();
                    ganjilGenapProgram.Menu();
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

        public bool CheckPassword(string password)
        {

            string pattern = @"(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}";
            bool isValid;

            Regex regex = new Regex(pattern);
            isValid = regex.IsMatch(password);
            return isValid;
        }
    }
}
