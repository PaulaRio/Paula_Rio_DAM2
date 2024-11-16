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
    public class DirectoryService : IDirectoryProvider
    {
        public void CreateNewDirectory(string nombreDirectorio)
        {
            if (!Directory.Exists(Constants.ROOTFILES + "/" + nombreDirectorio))
            {

                Directory.CreateDirectory(Constants.ROOTFILES + "/" + nombreDirectorio );


            }
        }

        
    }
}
