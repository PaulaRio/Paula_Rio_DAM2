using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Utils
{
    public class DirectoryFileUtils
    {
        public static void CreateDirectoryFILES()
        {
            int numFilesDefault = 2;
            int numDirectoryDefault = 1;
            if (!Directory.Exists(Constantes.ROOTFILES))
            {
                Directory.CreateDirectory(Constantes.ROOTFILES);
                for (int i = 0; i < numFilesDefault; i++)
                {
                    var fileName = generateRandomFileTxtName();
                    File.Create(Constantes.ROOTFILES + "/" + fileName);
                }
                for (int i = 0; i < numDirectoryDefault; i++)
                {
                    var dirName = GenerateRandomDirectoryName();
                    Directory.CreateDirectory(Constantes.ROOTFILES + "/" + dirName);
                }

            }
        }
        public static string GenerateRandomDirectoryName()
        {
            return Path.GetRandomFileName().Replace(".", "");
        }
        public static string generateRandomFileTxtName()
        {
            return Path.GetRandomFileName().Replace(".", "") + ".txt";
        }


    }



     
    
}
