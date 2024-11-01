using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorArchivos.Interfaces
{
   public interface IFileProvider
    {
        public void CreateFile(string nombreFichero);
    }
}
