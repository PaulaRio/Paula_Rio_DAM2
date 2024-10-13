using EjerciciosC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    internal class Ejercicio8 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un array de numeros separado por comas");
            string? cadenaRestada = Console.ReadLine();
            Console.WriteLine("Introduce otro array de numeros separado por comas");
            string? cadenaResta = Console.ReadLine();
            List<string> resultado = Utils.SubstractStrings(cadenaRestada, cadenaResta);
            Console.WriteLine(Utils.ListToString(resultado));
            
        }
    }
}
