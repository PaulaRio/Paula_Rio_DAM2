using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.Utils
{
    public static class FileUtils
    {
        public static string generateRandomFileTxtName()
        {
            return Path.GetRandomFileName().Replace(".", "")+".txt";
        }
    }
}
