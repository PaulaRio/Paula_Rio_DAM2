using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApp.DTO;

namespace BasicApp.Interfaces
{
    public interface IGhibliProvider
    {
        public Task<List<GhibliDTO>> GetAsync();
    }
}
