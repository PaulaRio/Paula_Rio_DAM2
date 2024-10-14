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
        /// <summary>
        /// Veerifica si lo introducido por consola es un numero
        /// </summary>
        /// <param name="numero"> cadena pasada por consola</param>
        /// <returns>Devuelve un numero si el string es un numero, en caso contrario, lo notifica</returns>
        public static int GetNumeroPorConsola(string? numero)
        {
 
            if (!int.TryParse(numero, out int val))
            {
                Console.WriteLine("No has introducido un número");
                return 0;
            }
            return val;
        }
        /// <summary>
        /// Obtiene una lista de numeros sacados del string introducido, separados por una coma
        /// </summary>
        /// <param name="datos">Cadena de numeros a extraer</param>
        /// <returns>Lista de numeros </returns>
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
        /// <summary>
        /// Obtiene una lista de elementos sacados del string introducido, separados por una coma
        /// </summary>
        /// <param name="datos">Cadena que contiene los elementos a extraer</param>
        /// <returns>Lista de elementos </returns>
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
        /// <summary>
        /// Separa los numeros de dos o más cifras en digitos, devolviendolos en una lista
        /// </summary>
        /// <param name="n">numero a separar</param>
        /// <returns>Lista de digitos</returns>
        public static List<int> NumbersToDigits(int n)
        {
            List<int> listaDigitos = new List<int>();
            while (n>0)
            {
                listaDigitos.Add(n % 10);
                n /= 10;
            }
            return listaDigitos;
        }
        /// <summary>
        /// Suma los numeros pasadosen una lista
        /// </summary>
        /// <param name="lista">Lista de numeros a sumar</param>
        /// <param name="origen">Posición desde a que queremos empezar a sumar</param>
        /// <param name="fin">Posición a partir de la cual no queremos que siga sumando</param>
        /// <returns>Suma de todos los numeros del list</returns>
        public static int SumDigitsList(List<int> lista,int origen, int fin)
        {
            int suma = 0;
            for (int  i = origen;  i < fin;  i++)
            {
                suma = suma + lista[i];
            }
            return suma;
        }
        /// <summary>
        /// Resta los elementos de la segunda cadena a los de la primera
        /// </summary>
        /// <param name="cadenaRestada">Cadena que queremos devolver habiendo restado los elementos de la otra</param>
        /// <param name="cadenaResta">Cadena que contiene los elementos que queremos retirar</param>
        /// <returns>Lista de elementos de una cadena habiéndo retirado los de la segunda cadena</returns>
        public static List<string> SubstractStrings(string cadenaRestada,string cadenaResta )
        {
            List<string> listaRestada = Utils.GetListStringFromString(cadenaRestada);
            List<string> listaResta = Utils.GetListStringFromString(cadenaResta);


            foreach (string str in listaResta)
            {
               
              listaRestada.RemoveAll(x => x == str);
                
            }
            return listaRestada;
        }
        /// <summary>
        /// Resta los elementos de la segunda lista a los de la primera
        /// </summary>
        /// <param name="listaRestada">Lista que queremos devolver habiendo restado los elementos de la otra</param>
        /// <param name="listaResta">Lista que contiene los elementos que queremos retirar</param>
        /// <returns>Lista de elementos de una lista habiéndo retirado los de la segunda lista</returns>
        public static List<string> SubstractLists(List<string> listaRestada, List<string> listaResta)
        {
            List<string> resultado = new List<string>(listaRestada);


            foreach (string str in listaResta)
            {

                resultado.RemoveAll(x => x == str);

            }
            return resultado;
        }
        /// <summary>
        /// Pasa una lista a una cadena, donde los elementos estan separados por comas
        /// </summary>
        /// <param name="lista">Lista que queremos convertir a cadena</param>
        /// <returns>Cadena con elementos separados por comas</returns>
        public static string ListToString(List<string> lista)
        {
            string cadena= "";


            foreach (string str in lista)
            {

               cadena += str + ",";

            }
            if (cadena.Length > 1) {
               cadena = cadena.Substring(0, cadena.Length - 1);
            }
            return cadena;
        }
        /// <summary>
        /// Pasa una lista a una cadena de numeros, donde estos estan separados por comas
        /// </summary>
        /// <param name="lista">Lista que queremos convertir a cadena</param>
        /// <returns>Cadena con numeros separados por comas</returns>
        public static string ListToIntString(List<int> lista)
        {
            string cadena = "";


            foreach (int i in lista)
            {

                cadena += i + ",";

            }
            if (cadena.Length > 1)
            {
                cadena = cadena.Substring(0, cadena.Length - 1);
            }
            return cadena;
        }
    }

}
