using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerciciosC;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjerciciosC_
{
    internal class Ejercicio9 : IEjecutarEjercicio

    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un número de más de un dígito");
            string? cadena = Console.ReadLine();
            int numero = Utils.GetNumeroPorConsola(cadena);
            List<int> listaDigitos = new List<int>();
     
            int n = 0;
        
            listaDigitos = Utils.NumeroToDigitos(numero);
  
            listaDigitos.Sort();
      
            for (int i = listaDigitos.Count- 1; i >= 0; i--)
            {
                
                    n=((int) Math.Pow(10, i))* listaDigitos[i] + n;
                
            }
            Console.WriteLine($"El numero es: {n}");
               
               
                

            

        }
    }
}
