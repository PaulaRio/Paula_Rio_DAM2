using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Divisas
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
        public static decimal cambioDivisas(decimal numero,string?de, string? a)
        {   
            //if(de)


            return 0;
        }




    }
}
