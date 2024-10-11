using EjerciciosC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    /*Escribe una función que tome un parámetro positivo num y devuelva
    su persistencia multiplicativa, que es el número de veces que debes
    multiplicar los dígitos de num hasta llegar a un solo dígito.
    39 --> 3 (porque 3*9 = 27, 2*7 = 14, 1*4 = 4 y el 4 sólo tiene un dígito)*/
    internal class Ejercicio6 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Escribe un número entero");
            string? cadena = Console.ReadLine();
            int numero = Utils.GetNumeroPorConsola(cadena);
           
            List<int> listaDigitos= new List<int>();
            int cont = 0;
            int aux = 1;

            while (numero / 10 != 0)
            {   
                listaDigitos = Utils.NumeroToDigitos(numero);
                foreach (var item in listaDigitos)
                {
                    aux = aux * item;
                   

                }
                Console.WriteLine($"El nuevo numero es: {aux}");
                numero = aux;
                aux=1;
                cont++;

            }
            Console.WriteLine($" El contador queda en {cont}");



        }
    }
}
