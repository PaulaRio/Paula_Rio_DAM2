using EjerciciosC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    internal class Prueba :IEjecutarEjercicio
    {
        public void Ejecutar()
        {
            Console.WriteLine("Introduce un array de colores (por ejemplo, R,G,B)");
            string? cadena = Console.ReadLine();
            List<string> colores = Utils.GetListStringFromString(cadena);
            List<string> posibilidades = new List<string> { "R", "G", "B" };

            // Mientras haya más de un color en la fila
            while (colores.Count > 1)
            {
                List<string> nuevaLinea = new List<string>(); // Limpia la lista al inicio
                List<string> restar = new List<string>();     // Lista para manejar los colores diferentes

                for (int i = 0; i < colores.Count - 1; i++)
                {
                    if (colores[i] == colores[i + 1])
                    {
                        nuevaLinea.Add(colores[i]); // Si son iguales, agrega el mismo color
                    }
                    else
                    {
                        restar.Add(colores[i]);
                        restar.Add(colores[i + 1]);

                        // Se usa una copia de 'posibilidades' para evitar modificarla directamente
                        string cad = Utils.listToCadena(Utils.diferenciarListas(new List<string>(posibilidades), restar));
                        nuevaLinea.Add(cad);
                        restar.Clear();
                    }
                }

                // Muestra la nueva línea
                foreach (var item in nuevaLinea)
                {
                    Console.Write(item);
                }
                Console.WriteLine(); // Salto de línea para ver cada paso del proceso

                colores = nuevaLinea; // Actualiza los colores para la siguiente iteración
            }
        }
    }
}
