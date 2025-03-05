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

       
        public async Task<IEnumerable<ObjectDTO>> GetObjetos()
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

        public async Task<ObjectDTO> PostObjeto(ObjectDTO Objeto)
        {
            if (Objeto != null)
            {
               return await _httpsJsonClientProvider.PostAsync(Constantes.OBJECT_URL, Objeto);
            }
            else
            {
                return default;
                MessageBox.Show("No se ha podido cargar el objeto, no se ha realizado el cambio");
            }
        }
        public async Task<bool> DeleteObjeto(string id)//await _httpsJsonClientProvider.PatchAsync($"{Constantes.OBJECT_URL}{_obj.Id}", _obj) != null
        {
            if (await _httpsJsonClientProvider.DeleteAsync($"{Constantes.OBJECT_URL}", id))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar el objeto");
                return false;
            }
        }

        public async Task<bool> DeleteAllObjetos()
        {
            bool exito = true;
            IEnumerable<ObjectDTO> lista = await GetObjetos();
            foreach (ObjectDTO obj in lista)
            {
                if (!await DeleteObjeto( obj.Id.ToString()))
                {
                    MessageBox.Show("No se ha podido eliminar el objeto");
                    exito = false;
                }
                
            }
            return exito;
        }

        public async Task PostObjetos(IEnumerable<ObjectDTO> lista)
        {   if(lista != null) 
            {
                foreach (ObjectDTO obj in lista)
                {

                    await PostObjeto(obj);

                }
            }
            else
            {
                MessageBox.Show("No se ha podido cargar la lista, no se ha realizado el cambio");
            }
            
        }
        public async Task<bool> ExisteObjeto(string id)
        {
            try
            {

                var objeto = await _httpsJsonClientProvider.GetByIdAsync($"{Constantes.OBJECT_URL}",id);

                return objeto != null;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al verificar los grupos: {ex.Message}");
                return false;
            }

        }
        public async Task<bool> ExistenObjetos(List<int> objetosIds)
        {
            try
            {

                var objetos = await _httpsJsonClientProvider.GetAsync(Constantes.OBJECT_URL);


                var objetosExistentes = objetos.Where(g => objetosIds.Contains(g.Id)).ToList();


                return objetosExistentes.Count == objetosIds.Count;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al verificar los objetos: {ex.Message}");
                return false;
            }

        }


    }
}
