using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using PlantillaWPF.DTOs;

using PlantillaWPF.Utils;
using System.Windows;
using PlantillaWPF.Interfaces;

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
            if (Objeto != null)
            {
                await _httpsJsonClientProvider.PatchAsync(Constantes.OBJECT_URL, Objeto);
            }
            else
            {
                MessageBox.Show("No se ha podido cargar el objeto, no se ha realizado el cambio");
            }
        }

        public async Task PostObjeto(ObjectDTO Objeto)
        {
            if (Objeto != null)
            {
                await _httpsJsonClientProvider.PostAsync(Constantes.OBJECT_URL, Objeto);
            }
            else
            {
                MessageBox.Show("No se ha podido cargar el objeto, no se ha realizado el cambio");
            }
        }
        public async Task<bool> DeleteObjeto(string id)
        {
            if (await _httpsJsonClientProvider.DeleteAsync(Constantes.OBJECT_URL, id))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar el objeto");
                return false;
            }
        }
    }
}
