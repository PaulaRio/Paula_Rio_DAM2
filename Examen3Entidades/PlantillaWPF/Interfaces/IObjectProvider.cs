using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.DTOs;

namespace PlantillaWPF.Interfaces
{
    public interface IObjectProvider
    {
        Task<IEnumerable<ObjectDTO>> GetObjetos();
        Task<ObjectDTO> GetOneObjeto(string id);
        Task PostObjeto(ObjectDTO Objeto);
        Task PostObjetos(IEnumerable<ObjectDTO> lista);
        Task PatchObjeto(ObjectDTO Objeto);
        Task<bool> DeleteObjeto(string id);
        Task<bool> DeleteAllObjetos();
        Task<bool> ExisteObjeto(string id);
        Task<bool> ExistenObjetos(List<int> objetosIds);
    }
}
