using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.DTOs;

namespace PlantillaWPF.Interfaces
{
    public interface IGrupoProvider
    {
        Task<IEnumerable<GrupoDTO>> GetGrupos();
        Task<GrupoDTO> GetOneGrupo(string id);
        Task PostGrupo(GrupoDTO Grupo);
        Task PostGrupos(IEnumerable<GrupoDTO> lista);
        Task PatchGrupo(GrupoDTO Grupo);
        Task<bool> DeleteGrupo(string id);
        Task<bool> DeleteAllGrupos();

        Task<bool> ExistenGrupos(List<int> gruposIds);
    }
}
