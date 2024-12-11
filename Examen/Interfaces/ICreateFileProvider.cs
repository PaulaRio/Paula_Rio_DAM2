using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Interfaces
{
   public interface ICreateFileProvider
    {
        public void CreateNewFile(string nombreFichero);
        public List<string> getNameFiles();
    }
}
