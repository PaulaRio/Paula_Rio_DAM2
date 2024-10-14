using EjerciciosC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjerciciosC_
{   /*5. Implementar la función que toma como argumento una secuencia de
    enteros o string y devuelve una lista de elementos sin ningún
    elemento repetido y preservando el orden original de los elementos.
    */
    internal class Ejercicio5 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un array separado por comas");
            string? stringArray = Console.ReadLine();
       
            List<string> splittedStringArray = Utils.GetListStringFromString(stringArray);

            Dictionary<string, int> diccionarioReps = new Dictionary<string, int>();
            
            foreach (var item in splittedStringArray)
            {
                if (diccionarioReps.ContainsKey(item))
                {

                    diccionarioReps[item] += 1;
                }
                else
                {
                    diccionarioReps.Add(item, 1);
                }
            }
            foreach (var item in diccionarioReps)
            {
                if (item.Value>1)
                {
                   diccionarioReps.Remove(item.Key);
                }
                else
                {
                    Console.WriteLine($"Número sin repetición: {item.Key}");
                }
                
            }
            






        }
    }
}
