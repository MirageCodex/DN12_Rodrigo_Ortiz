using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using vehiculo;


namespace Rodrigo_s_AudioManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type the vehicle!"); // Escribir en consola
                Console.WriteLine("Type quit to exit the program");
                Console.WriteLine("Welcome to my Audio Manager");

                string animalType = Console.ReadLine().ToLower();

                Vehiculo vehiculo = null;
                switch (animalType)
                {
                    case "train":
                        vehiculo = new tren();
                        break;
                    case "car":
                        vehiculo = new Carro();
                        break;
                    case "truck":
                        vehiculo = new Camion();
                        break;
                    case "quit":
                        Console.WriteLine("Exiting the program.");
                        return;
                    default:
                        Console.WriteLine("Vehicle not found!");
                        System.Threading.Thread.Sleep(2000);
                        break;
                }
                if (vehiculo != null)
                {

                    vehiculo.autoSound();
                }
            }
        }
    }
}
