using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioManager;

namespace OOP.ConsoleExapmle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!"); // Escribir en consola

            Animal animal = new Animal();
            animal.AnimalSound();

            Console.ReadKey(); // Leer cualquier tecla para continuar
            
        }
    }
}
