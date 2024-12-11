using Examen.Interfaces;
using Examen.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Services
{
    public class DirectoryService : IDirectoryProvider
    {
        public void CreateNewDirectory(string nombreDirectorio)
        {
            if (!Directory.Exists(Constantes.ROOTFILES + "/" + nombreDirectorio))
            {

                Directory.CreateDirectory(Constantes.ROOTFILES + "/" + nombreDirectorio );


            }
        }
        public List<string> getNameDirectories()
        {
            List<string> namesDirectorios = new List<string>();
            foreach (var item in Directory.GetDirectories(Constantes.ROOTFILES))
            {

                namesDirectorios.Add(Path.GetFileName(item));
            }
            return namesDirectorios;
        }
        


}
}
