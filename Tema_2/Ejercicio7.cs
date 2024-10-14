using EjerciciosC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    internal class Ejercicio7 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un array separado por comas");
            string? cadena = Console.ReadLine();
            List<int> splittedStringArray = Utils.GetListNumbersFromString(cadena);
            int sumaIzda = 0;
            int sumaDcha = 0;
            int numeroCentral = -1;
           
                for (int i = 0; i < splittedStringArray.Count; i++)
                { 
                sumaIzda = Utils.SumDigitsList(splittedStringArray, 0, i );
                sumaDcha = Utils.SumDigitsList(splittedStringArray, i + 1, splittedStringArray.Count);
                    if (sumaIzda == sumaDcha)
                    {
                        numeroCentral = i ;
                        i = splittedStringArray.Count;

                    }
                }
            if (numeroCentral==-1)
            {
                Console.WriteLine("No hay numero central");
            }
            Console.WriteLine($"La posición en la que se encuentra el numero central es {numeroCentral}");


        }
    }
}
