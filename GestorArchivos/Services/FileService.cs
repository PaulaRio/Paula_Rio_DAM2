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
    }
}
