using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AudioManager;

namespace OOP.ConsoleExapmle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type the animal!"); // Escribir en consola

                string animalType = Console.ReadLine().ToLower();

                Animal animal = null;
                switch (animalType)
                {
                    case "cat":
                        animal = new Cat();
                        break;
                    case "cow":
                        animal = new Cow();
                        break;
                    case "dog":
                        animal = new Dog();
                        break;
                    case "elephant":
                        animal = new Elephant();
                        break;
                    case "lion":
                        animal = new Lion();
                        break;
                    case "pig":
                        animal = new Pig();
                        break;
                    default:
                        Console.WriteLine("Animal not found!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
                if (animal != null)
                {

                    animal.AnimalSound();
                }
            }
            
        }
    }
}
