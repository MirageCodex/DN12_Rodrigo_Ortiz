using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libreria;


namespace Rodrigo_s_AudioManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Hola Mundo!"); 
            Console.WriteLine("Este es mi Manager de Audio");

            Class1 libreria = new Class1();

            libreria.nugget();

            Console.ReadKey(); 
        }
    }
}
