using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerciciosC;

namespace EjerciciosC_
{
    internal class Ejercicio1 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Escribe una cadena de letras minúsculas");
            string cadena = Console.ReadLine();
            char [] letras = cadena.ToCharArray();
            char[] vocales = { 'a', 'e','i','o','u'};
            int nVocales = 0;
            for (int i = 0;i<cadena.Length;i++)
            {
                if (vocales.Contains(letras[i]))
                {
                    nVocales ++;
                }

            }
            Console.WriteLine($"El número de vocales presente es: {nVocales}");
        }
    }
}
