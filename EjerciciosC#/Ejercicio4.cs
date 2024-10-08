using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerciciosC;

namespace EjerciciosC_
{
    class Ejercicio4 : IEjecutarEjercicio
    {
        /*4. Dada un array de enteros, encuentra todo los números que aparecen
        un número impar de veces.*/
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un array separado por comas");
            string? numerosArray = Console.ReadLine();
            List<int> splittedNumerosArray = Utils.GetListNumbersFromString(numerosArray);
            
            Dictionary<int, int> diccionarioReps = new Dictionary<int, int>();
            Dictionary<int, int> nImparveces = new Dictionary<int, int>();
            int cont = 0;
            foreach (int i in splittedNumerosArray)
            {
                if (diccionarioReps.ContainsKey(i))
                {
                    diccionarioReps[i] += 1;
                }
                else
                {
                    diccionarioReps.Add(i, 1);
                }

            }
            
            foreach (var element in diccionarioReps)
            {
                if (element.Value %2!=0)
                {
                    nImparveces.TryAdd(element.Key,element.Value);
                }
            }
            foreach (var item in nImparveces)
            {
                Console.WriteLine($"El número {item.Key} " + $" con {item.Value} repeticiones impares");
            }

            

        }
    }
}
