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
    public class CreateFILESService : ICreateFILESService
    {
        public void CreateDirectoryFILES()
        {
            int numFilesDefault = 2;
            int numDirectoryDefault = 1;
            if (!Directory.Exists(Constants.ROOTFILES))
            {
                Directory.CreateDirectory(Constants.ROOTFILES);
                for (int i = 0; i < numFilesDefault; i++)
                {
                    File.Create(Constants.ROOTFILES + "/" + FileUtils.generateRandomFileTxtName);
                }
                for (int i = 0; i < numDirectoryDefault; i++)
                {
                    Directory.CreateDirectory(Constants.ROOTFILES + "/" + DirectoryUtils.GenerateRandomDirectoryName);
                }

            }



        }
    }
}
