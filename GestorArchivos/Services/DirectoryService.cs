using GestorArchivos.Interfaces;
using GestorArchivos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.Services
{
    public class DirectoryService : IDirectoryProvider
    {
        public void CreateDirectory(string nombreDirectorio)
        {
            throw new NotImplementedException();
        }

        public void CreateDirectoryFILES()
        {
            DirectoryUtils.CreateDirectoryIfNotExists(Constants.ROOTFILES);
            

            
        }
    }
}
