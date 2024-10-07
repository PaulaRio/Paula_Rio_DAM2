using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC_
{
    public static class Utils
    {
        public static int GetNumeroPorConsola()
        {
            Console.WriteLine("Escribe un número por consola");
            string? numero = Console.ReadLine();
            if (!int.TryParse(numero, out int val))
            {
                Console.WriteLine("No has introducido un número");
                return 0;
            }
            return val;
        }

        public static List<int> GetListNumbersFromString(string? datos)
        {
            string[] splittedDatos = datos?.Split(",") ?? [];

            List<int> splittedDatosInt = new List<int>();
            foreach (string dato in splittedDatos)
            {
                if (!int.TryParse(dato, out int val))
                {
                    return [];
                }
                splittedDatosInt.Add(val);
            }
            return splittedDatosInt;
        }
    }

}
