using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.DTO;


namespace Examen.Interfaces
{
    public interface IAPIProvider
    {
        public Task<List<EjemploDTO>> GetAsync();
    }
}
