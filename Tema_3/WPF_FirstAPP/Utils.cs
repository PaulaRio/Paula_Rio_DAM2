using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_FirstAPP
{
    public static class Utils
    {
        /// <summary>
        /// Veerifica si lo introducido por consola es un numero
        /// </summary>
        /// <param name="numero"> cadena pasada por consola</param>
        /// <returns>Devuelve un numero si el string es un numero, en caso contrario, lo notifica</returns>
        public static int? ConvertToNumber(string str)
        {
            if (!int.TryParse(str, out int val))
            {
                return null;
            }
            return val;
        }
        public static bool IsNumberPrime(int val)
        {
            for (int i = 2; i < val; i++)
            {
                if (val % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static string Triangle(int? uno, int? dos, int? tres)
        {
            string cadena= "";
            if (uno == dos && tres == dos)
            {
                cadena="Es equilátero";
            } else if(uno==dos&&dos!=tres|| dos == tres && dos != uno|| uno == tres && dos != tres)
            {
                cadena = "Es isósceles";
            }
            else
            {

                cadena = "Es escaleno";
            }
            return cadena;
                
        }
        public static string Calculadora(int? num, string? operador, int? tres)
        {
            //string cadena = "";
            //if (uno == dos && tres == dos)
            //{
            //    cadena = "Es equilátero";
            //}
            //else if (uno == dos && dos != tres || dos == tres && dos != uno || uno == tres && dos != tres)
            //{
            //    cadena = "Es isósceles";
            //}
            //else
            //{

            //    cadena = "Es escaleno";
            //}
            //return cadena;

        }


    }

}
