using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.DTOs;

namespace PlantillaWPF.Providers
{
    public interface IObjectProvider
    {
        Task<IEnumerable<ObjectDTO>> GetObjeto();
        Task<ObjectDTO> GetOneObjeto(string id);
        Task PostObjeto(ObjectDTO Objeto);
        Task PatchObjeto(ObjectDTO Objeto);
        Task<bool> DeleteObjeto(string id);
    }
}
