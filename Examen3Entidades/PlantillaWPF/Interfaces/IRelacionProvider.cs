using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.DTOs;

namespace PlantillaWPF.Interfaces
{
    public interface IRelacionProvider
    {
        Task<IEnumerable<RelacionDTO>> GetRelaciones();
        Task<RelacionDTO> GetOneRelacion(string id);
        Task PostRelacion(RelacionDTO Relacion);
        Task PostRelaciones(IEnumerable<RelacionDTO> lista);
        Task PatchRelacion(RelacionDTO Relacion);
        Task<bool> DeleteRelacion(string id);
        Task<bool> DeleteAllRelaciones();

    }
}
