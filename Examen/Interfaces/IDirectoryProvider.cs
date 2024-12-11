using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Interfaces
{
   public interface IDirectoryProvider
    {
        public void CreateNewDirectory(string nombreDirectorio);
        public List<string> getNameDirectories();


    }
}
