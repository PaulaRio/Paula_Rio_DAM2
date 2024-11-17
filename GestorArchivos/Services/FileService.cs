using GestorArchivos.Interfaces;
using GestorArchivos.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.Services
{
    class FileService : IFileProvider

    {
        public void CreateNewFile(string nombreFichero)
        {
            if (!File.Exists(Constants.ROOTFILES+ "/"+nombreFichero+".txt"))
            {
               
              File.Create(Constants.ROOTFILES + "/" + nombreFichero + ".txt");
               

            }
        }
        //Porfi , tengo que acordarme de modificar el codigo para que etsos metodos se puedan usar siempre, osea introducir ruta por parámetro
        public List<string> getNameFiles()
        {
            List<string> namesFicheros = new List<string>();
            foreach (var item in Directory.GetFiles(Constants.ROOTFILES))
            {

                namesFicheros.Add(Path.GetFileName(item));
            }
            return namesFicheros;
        }
    }
}
