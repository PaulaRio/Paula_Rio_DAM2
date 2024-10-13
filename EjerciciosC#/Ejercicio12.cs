using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjerciciosC;

namespace EjerciciosC_
{
    internal class Ejercicio12 : IEjecutarEjercicio
    {
        public void Ejecutar()
        {
           
            Console.WriteLine("Introduce un array de colores");
            string? cadena = Console.ReadLine();
            List<string> colores = Utils.GetListStringFromString(cadena);
            List<string> posibilidades = new List<string>{ "R", "G", "B" };
          
            
            while (colores.Count>1)
            {
                List<string> nuevaLinea = new List<string>();
                List<string> restar = new List<string>();
                for (int i = 0; i < colores.Count-1; i++)
                {
                   if( colores[i] == colores[i + 1])
                   {
                    nuevaLinea.Add(colores[i]);
                   }
                   else
                   {
                    restar.Add(colores[i]);
                    restar.Add(colores[i + 1]);
                    string cad = Utils.listToCadena(Utils.diferenciarListas(posibilidades, restar));
                    nuevaLinea.Add(cad);
                    restar.Clear();
                    
    
                   }
                }
                foreach (var item in nuevaLinea)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                colores = nuevaLinea;

            }

           
        }
    }
}
