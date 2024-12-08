using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.DTO;
using Pokemon.Interfaces;
using Pokemon.Utils;

namespace Pokemon.Services
{
    public class HistoricoApiService : IHistoricoProvider
    {
        public async Task<List<HistoricoDTO>> GetAsync()
        {
           return await HttpJsonClient< List<HistoricoDTO>>.GetMyApi(Constantes.HISTORICO_PATH);
        }
    }
}
