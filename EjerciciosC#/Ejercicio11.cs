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
            int i = numero;
            int suma = 0;
            List<int> listaPotencias = new List<int>();
            while (i>0)
            {
                if(aux >= Math.Pow(i, 2))
                {
                    listaPotencias.Add(i);
                    suma = suma + (int)Math.Pow(i, 2);
                    aux = i;
                }
               
                i--;
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
            foreach (var item in listaPotencias)
            {
                
                Console.WriteLine(item);
            }
            
        }
    }
}
