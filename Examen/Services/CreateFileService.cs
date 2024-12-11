using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Utils;
using Examen.Interfaces;

namespace Examen.Services
{
    class CreateFileService : ICreateFileProvider
    {
        public void CreateNewFile(string nombreFichero)
        {
            if (!File.Exists(Constantes.ROOTFILES + "/" + nombreFichero + ".txt"))
            {

                File.Create(Constantes.ROOTFILES + "/" + nombreFichero + ".txt");


            }
        }

        public List<string> getNameFiles()
        {
            List<string> namesFicheros = new List<string>();
            foreach (var item in Directory.GetFiles(Constantes.ROOTFILES))
            {

                namesFicheros.Add(Path.GetFileName(item));
            }
            return namesFicheros;
        }
    }
}
