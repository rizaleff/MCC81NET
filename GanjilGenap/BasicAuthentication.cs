using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanjilGenap
{
    internal class BasicAuthentication
    {
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
                        break;

                        case "2":
                        break;
                        case "3":
                        break;
                        case "4":
                        break;
                        case "5":

                        isMenu = false;
                        break;
                }
            }while 
            (isMenu == true);
        }
        static void Main(string[] args)
        {

            AuthenticationMenu();
        }
    }
}
