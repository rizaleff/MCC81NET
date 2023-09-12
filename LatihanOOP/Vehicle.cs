using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LatihanOOP
{
    class Vehicle
    {
        
        private string name;
        private int speed;
        private string color;
        public int Wheel { get; private set; }
        
        public Vehicle(string name, int speed, string color, int wheel)
        {
            this.name = name;
            this.speed = speed; 
            this.color = color; 
            Wheel = wheel;
        }

        public void spesification()
        {
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Speed: {speed}");
            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"Wheel: {Wheel}");
        }
    }



}
