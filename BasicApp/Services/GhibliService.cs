using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApp.DTO;
using BasicApp.Interfaces;
using BasicApp.Utils;
using BasicApp.Interfaces;

namespace BasicApp.Services
{
    public class GhibliService : IGhibliProvider
    {
        public async Task<List<GhibliDTO>> GetAsync()
        {
            return await HttpJsonClient<List<GhibliDTO>>.Get(Constants.GHIBLI_PATH);
        }
    }
}
