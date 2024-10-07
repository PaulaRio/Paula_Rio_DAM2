using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerciciosC;

namespace EjerciciosC_
{
    internal class Ejercicio2 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Escribe un pin de 4 o 6 números");
            string? cadena = Console.ReadLine();
            char[] numeros = cadena?.ToCharArray();
            int pin = 0;
            bool letra=true;
            foreach (var item in numeros)
            {
                if (char.IsDigit(item))
                {
                    pin++;
                }
                else
                {
                    letra = false;
                }
            }
            string resultado;
            resultado = (pin == 4 && letra || pin == 6&&letra) ? "true" : "false";
            Console.WriteLine($"{resultado}");
           
            

        }
    }
}
