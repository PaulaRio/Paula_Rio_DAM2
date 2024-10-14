using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerciciosC;

namespace EjerciciosC_
{
    internal class Ejercicio3 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un array separado por comas");
            string? numerosArray = Console.ReadLine();
            List<int> splittedNumerosArray = Utils.GetListNumbersFromString(numerosArray);
            List<int> repeticiones = new List<int>();

            Dictionary<int,int> diccionarioReps= new Dictionary<int,int>();     
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
            int keyDiccionarioMenorValor = int.MaxValue;
            foreach (var element in diccionarioReps)
            {
                if (element.Value< keyDiccionarioMenorValor)
                {
                    keyDiccionarioMenorValor = element.Value;
                }
            }
            int smallestValueWithLessrepetitions = int.MaxValue;
            foreach (var element in diccionarioReps)
            {
                if (element.Value == keyDiccionarioMenorValor &&element.Key< smallestValueWithLessrepetitions)
                {
                    smallestValueWithLessrepetitions = element.Key;
                }
            }

            Console.WriteLine($"El numero que se repite menos veces es {smallestValueWithLessrepetitions} "+$" con {keyDiccionarioMenorValor} repeticiones");


        }
    }
}
