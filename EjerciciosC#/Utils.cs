using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjerciciosC_
{
    public static class Utils
    {
        public static int GetNumeroPorConsola(string? numero)
        {
 
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
        public static List<string> GetListStringFromString(string? datos)
        {
            string[] splittedDatos = datos?.Split(",") ?? [];
            List<string> splittedDatosString = new List<string>();
            foreach (string dato in splittedDatos)
            {
                splittedDatosString.Add(dato);
            }
               
           
            return splittedDatosString;
        }
        public static List<int> NumeroDigitos(int n)
        {
            List<int> listaDigitos = new List<int>();
            while (n>0)
            {
                listaDigitos.Add(n % 10);
                n /= 10;
            }
            return listaDigitos;
        }
        public static int SumaDigitosList(List<int> lista,int origen, int fin)
        {
            int suma = 0;
            for (int  i = origen;  i < fin;  i++)
            {
                suma = suma + lista[i];
            }
            return suma;
        }
    }

}
