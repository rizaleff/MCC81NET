
using System.Collections.Generic;

namespace GanjilGenap;
class Program
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
        string inputMenu = Console.ReadLine(); //Input pilihan menut untuk pengguna.

        switch (inputMenu)
        {
            case "1":
                Console.Write("Masukkan bilangan yang ingin dicek: ");
                string inputNumber = Console.ReadLine();
                StringToInt(inputNumber, EvenOddCheck())
                Menu();
                break;

            case "2":
                Console.Write("Pilih Ganjil/Genap: "); //Label input pilihan.
                string choice = Console.ReadLine(); //Field input pilihan.

                Console.Write("Masukkan limit: "); //Label input pilihan 
                string inputLimit = Console.ReadLine();

                PrintEvenOdd(inputLimit, choice);
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
    }

    static void PrintEvenOdd(string inputLimit, string choice)
    {

        Console.WriteLine("Print Bilangan 1 - " + inputLimit);
        
        int limit = StringToNumber(inputLimit);

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

    static int StringToNumber(string inputNumber)
    {
        try
        {
            return Convert.ToInt32(inputNumber);
            
        }
        catch (FormatException)
        {
            return -1;
        }
    }

    static void StringToInt(string inputNumber, Action<int> action)
    {
        int number;
        try
        {
            number = Convert.ToInt32(inputNumber);
            action(number);
        }
        catch (FormatException)
        {
            Console.WriteLine("Input Harus Berupa angka");
        }
    }

    /* static MessageConverting StringToInt(string inputNumber)
     {
         MessageConverting messageConverting = new MessageConverting();
         try
         {

             messageConverting.number = Convert.ToInt32(inputNumber);
             messageConverting.message = "Sukes";

             if(messageConverting.number <= 0)
             {
                 messageConverting.message = "Input Harus Lebih dari 1";
             }
             return messageConverting;
         }
         catch (FormatException)
         {
             messageConverting.message = "Input Harus Berupa angka";
             return messageConverting;
         }

     }*/

   /* static void Main(string[] args)
    {
        MessageConverting messageConverting = StringToInt("10");
        Menu();
    }*/
}