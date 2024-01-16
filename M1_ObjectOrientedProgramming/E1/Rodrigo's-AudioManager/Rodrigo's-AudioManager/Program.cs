using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nuget;


namespace Rodrigo_s_AudioManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Hola Mundo!"); 
            Console.WriteLine("Este es mi Manager de Audio");

            NAudio Nuget = new NAudio();

            Nuget.NugetSound();

            Console.ReadKey(); 
        }
    }
}
