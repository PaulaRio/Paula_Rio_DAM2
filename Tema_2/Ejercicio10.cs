using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerciciosC;

namespace EjerciciosC_
{
    internal class Ejercicio10 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Escribe un número entero");
            string? cadena = Console.ReadLine();
            int numero = Utils.GetNumeroPorConsola(cadena);
            List<int> listaDigitos = new List<int>();
            listaDigitos.Add(1);
            while (numero /2 >= 1)
            {
                if(numero % 2 == 1)
                {
                    listaDigitos.Add(numero % 2);
                }
                numero /= 2;
            }
            foreach (var item in listaDigitos)
            {
                Console.Write(item);
            }
        }
    }
}
