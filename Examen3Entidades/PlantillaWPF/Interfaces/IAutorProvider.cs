using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.DTOs;

namespace PlantillaWPF.Interfaces
{
    public interface IAutorProvider
    {
        Task<IEnumerable<AutorDTO>> GetAutores();
        Task<AutorDTO> GetOneAutor(string id);
        Task PostAutor(AutorDTO Autor);
        Task PostAutores(IEnumerable<AutorDTO> lista);
        Task PatchAutor(AutorDTO Autor);
        Task<bool> DeleteAutor(string id);
        Task<bool> DeleteAllAutores();

        Task<bool> ExistenAutores(List<int> autoresIds);
       
    }
}
