using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.Utils
{
    public static class DirectoryUtils
    {
       
        public static string GenerateRandomDirectoryName()
        {
            return Path.GetRandomFileName().Replace(".", "");
        }
    }
}
