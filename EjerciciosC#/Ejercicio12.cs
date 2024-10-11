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
            /*Un triángulo de color se crea a partir de una fila de colores, cada uno de los
cuales es rojo, verde o azul. Las filas sucesivas, cada una con un color
menos que la anterior, se generan considerando los dos colores que se
tocan en la fila anterior.
Si estos colores son idénticos, se utiliza el mismo color en la nueva fila. Si
son diferentes, se utiliza el color que falta en la nueva fila. Así se continúa
hasta que se genera la última fila, con un solo color.*/
            Console.WriteLine("Introduce un array de colores");
            string? cadena = Console.ReadLine();
            List<string> colores = Utils.GetListStringFromString(cadena);
            List<string> posibilidades = new List<string>{ "R", "G", "B" };
            List<string> nuevaLinea = new List<string>();
            List<string> restar = new List<string>();
            string cad = "";
            while (colores.Count>=1)
            { 
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
                    cad = Utils.listToCadena(Utils.diferenciarListas(posibilidades, restar));
                    nuevaLinea.Add(cad);
                    restar.Clear();
                    
    
                   }
                }
                foreach (var item in nuevaLinea)
                {
                    Console.Write(item);
                }
                
                colores = nuevaLinea;

            }

            nuevaLinea.Clear();
        }
    }
}
