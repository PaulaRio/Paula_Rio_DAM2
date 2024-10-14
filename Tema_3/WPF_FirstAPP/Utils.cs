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
    }
}
