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
    public class GrupoService : IGrupoProvider
    {
        private readonly IHttpsJsonClientProvider<GrupoDTO> _httpsJsonClientProvider;
        public GrupoService(IHttpsJsonClientProvider<GrupoDTO> httpsJsonClientProvider)
        {
            _httpsJsonClientProvider = httpsJsonClientProvider;
        }

       
        public async Task<IEnumerable<GrupoDTO>> GetGrupos()
        {
            return await _httpsJsonClientProvider.GetAsync(Constantes.GRUPO_URL);
        }

        public async Task<GrupoDTO> GetOneGrupo(string id)
        {
            return await _httpsJsonClientProvider.GetByIdAsync(Constantes.GRUPO_URL, id);
        }

        public async Task PatchGrupo(GrupoDTO Grupo)
        {
            if (Grupo != null)
            {
                await _httpsJsonClientProvider.PatchAsync(Constantes.GRUPO_URL, Grupo);
            }
            else
            {
                MessageBox.Show("No se ha podido cargar el objeto, no se ha realizado el cambio");
            }
        }

        public async Task PostGrupo(GrupoDTO Grupo)
        {
            if (Grupo != null)
            {
                await _httpsJsonClientProvider.PostAsync(Constantes.GRUPO_URL, Grupo);
            }
            else
            {
                MessageBox.Show("No se ha podido cargar el objeto, no se ha realizado el cambio");
            }
        }
        public async Task<bool> DeleteGrupo(string id)//await _httpsJsonClientProvider.PatchAsync($"{Constantes.OBJECT_URL}{_obj.Id}", _obj) != null
        {
            if (await _httpsJsonClientProvider.DeleteAsync($"{Constantes.GRUPO_URL}", id))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar el objeto");
                return false;
            }
        }

        public async Task<bool> DeleteAllGrupos()
        {
            bool exito = true;
            IEnumerable<GrupoDTO> lista = await GetGrupos();
            foreach (GrupoDTO obj in lista)
            {
                if (!await DeleteGrupo( obj.Id.ToString()))
                {
                    MessageBox.Show("No se ha podido eliminar el objeto");
                    exito = false;
                }
                
            }
            return exito;
        }

        public async Task PostGrupos(IEnumerable<GrupoDTO> lista)
        {   if(lista != null) 
            {
                foreach (GrupoDTO obj in lista)
                {

                    await PostGrupo(obj);

                }
            }
            else
            {
                MessageBox.Show("No se ha podido cargar la lista, no se ha realizado el cambio");
            }
            
        }
        public async Task<bool> ExistenGrupos(List<int> gruposIds)
        {
            try
            {

                var grupos = await _httpsJsonClientProvider.GetAsync(Constantes.GRUPO_URL);


                var gruposExistentes = grupos.Where(g => gruposIds.Contains(g.Id)).ToList();


                return gruposExistentes.Count == gruposIds.Count;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al verificar los grupos: {ex.Message}");
                return false;
            }

        }
    }
}
