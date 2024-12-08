using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.DTO;

namespace Pokemon.Interfaces
{
    public interface IHistoricoProvider
    {
        public Task<List<HistoricoDTO>> GetAsync();
    }
}
