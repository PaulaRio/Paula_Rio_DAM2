using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Divisas
{
    public static class UtilsDivisas
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
        public static double cambioDivisas(double numero,string?de, string? a)
        {
            double resultado=0;
            switch (de)
            {
                case "euro":
                    if(a.Equals("dolar"))
                    {
                        resultado=numero * 1.05;
                    }
                    else
                    {
                        resultado =( numero / 1.05)*1.30;
                    }
                    break;
                case "libra":
                    if (a.Equals("dolar"))
                    {
                        resultado = numero * 1.30;
                    }
                    else
                    {
                        resultado = (numero / 1.30) * 1.05;
                    }
                    break;
                case "dolar":
                    if (a.Equals("libra"))
                    {
                        resultado = numero / 1.30;
                    }
                    else
                    {
                        resultado = numero / 1.05;
                    }
                    break;
                //default:
                   
                //    break;
            }

            return resultado;
        }




    }
}
