using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerciciosC;

namespace EjerciciosC_
{
    internal class Ejercicio11 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Escribe un número entero");
            string? cadena = Console.ReadLine();
            int numero = Utils.GetNumeroPorConsola(cadena);
            int aux = numero;
            
            int suma = 0;
            List<int> listaPotencias = new List<int>();
            for (int i = numero; i >0; i--)
            {
                int potencia = (int)Math.Pow(i, 2);
                if (aux >= potencia)
                {
                    listaPotencias.Add(i);
                    suma = suma + potencia;
                    aux = aux - potencia;
                }

            }
            
            while (listaPotencias.Count<4)
            {
                if(suma < numero) 
                { 
                listaPotencias.Add(1);
                    suma = suma + 1;
                }
                else
                {
                    listaPotencias.Add(0);
                }
                
            }
            
                
                Console.WriteLine(Utils.ListToIntString(listaPotencias).Replace(",","+"));
            
            
        }
    }
}
