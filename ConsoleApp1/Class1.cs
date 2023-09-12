using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanjilGenap
{
    internal class Class1
    {
        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("=========================================");
            Console.WriteLine("MENU GANJIL GENAP");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("1. Cek Ganjil Genap");
            Console.WriteLine("2. Print Ganjil/Genap (dengan limit)");
            Console.WriteLine("3. Exit");
            Console.WriteLine("-----------------------------------------");
            Console.Write("Pilihan: ");
            string inputMenu = Console.ReadLine();

            switch (inputMenu)
            {
                case "1":
                    Console.Write("Masukkan bilangan yang ingin dicek: ");
                    try
                    {
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(EvenOddCheck(number));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Input harus berupa angka!");
                    }

                    Menu();
                    break;

                case "2":
                    Console.Write("Pilih Ganjil/Genap: ");
                    string choice = Console.ReadLine();
                    Console.Write("Masukkan limit: ");
                    try
                    {
                        int limit = Convert.ToInt32(Console.ReadLine());
                        PrintEvenOdd(limit, choice);
                        Console.WriteLine();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Input Limit harus berupa angka!");
                    }
                    Menu();
                    break;

                case "3":
                    Console.WriteLine("Keluar dari aplikasi.....");
                    break;

                default:
                    Console.WriteLine("Menu Tidak Ditemukan");
                    Menu();
                    break;
            }
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }

        static void PrintEvenOdd(int limit, string choice)
        {
            Console.WriteLine("Print Bilangan 1 - " + limit);

            CheckNumber(limit);

            switch (choice)
            {
                case "Genap":
                    PrintLoop(2, limit);
                    break;
                case "Ganjil":
                    PrintLoop(1, limit);
                    break;
                default:
                    Console.Write("Input Pilihan Tidak Valid");
                    break;
            }
        }

        static string EvenOddCheck(int input)
        {
            CheckNumber(input);

            if (input % 2 == 0)
            {
                return "Genap";
            }
            return "Ganjil";

        }
        static void CheckNumber(int number)
        {
            if (number <= 0)
            {
                Console.WriteLine("Input Tidak Sesuai");
                Menu();
            }
        }

        static void PrintLoop(int startNumber, int limit)
        {
            for (int i = startNumber; i <= limit; i += 2)
            {
                Console.Write(i + ", ");
            }
        }
        static void Main(string[] args)
        {
            MessageConverting messageConverting = StringToInt("10");
            Menu();
        }

    }
}
