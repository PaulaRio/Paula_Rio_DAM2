using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using

using PlantillaWPF.DTOs;
using PlantillaWPF.Providers;
using PlantillaWPF.Utils;

namespace PlantillaWPF.Services
{
    public class ObjectService : IObjectProvider
    {
        private readonly IHttpsJsonClientProvider<ObjectDTO> _httpsJsonClientProvider;
        public ObjectService(IHttpsJsonClientProvider<ObjectDTO> httpsJsonClientProvider)
        {
            _httpsJsonClientProvider = httpsJsonClientProvider;
        }

       
        public async Task<IEnumerable<ObjectDTO>> GetObjeto()
        {
            return await _httpsJsonClientProvider.GetAsync(Constantes.OBJECT_URL);
        }

        public async Task<ObjectDTO> GetOneObjeto(string id)
        {
            return await _httpsJsonClientProvider.GetByIdAsync(Constantes.OBJECT_URL,id);
        }

        public async Task PatchObjeto(ObjectDTO Objeto)
        {
            throw new NotImplementedException();
        }

        public async Task PostObjeto(ObjectDTO Objeto)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteObjeto(string id)
        {
            throw new NotImplementedException();
        }
    }
}
