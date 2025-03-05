using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PlantillaWPF.DTOs;
using PlantillaWPF.Interfaces;
using PlantillaWPF.Utils;

namespace PlantillaWPF.Services
{
    public class RelacionService : IRelacionProvider
    {
        private readonly IHttpsJsonClientProvider<RelacionDTO> _httpsJsonClientProvider;

        public RelacionService(IHttpsJsonClientProvider<RelacionDTO> httpsJsonClientProvider)
        {
            _httpsJsonClientProvider = httpsJsonClientProvider;
        }


        public async Task<IEnumerable<RelacionDTO>> GetRelaciones()
        {
            return await _httpsJsonClientProvider.GetAsync(Constantes.RELACION_URL);
        }

        public async Task<RelacionDTO> GetOneRelacion(string id)
        {
            return await _httpsJsonClientProvider.GetByIdAsync(Constantes.RELACION_URL, id);
        }

        public async Task PatchRelacion(RelacionDTO Relacion)
        {
            if (Relacion != null)
            {
                await _httpsJsonClientProvider.PatchAsync(Constantes.RELACION_URL, Relacion);
            }
            else
            {
                MessageBox.Show("No se ha podido cargar la relacion, no se ha realizado el cambio");
            }
        }

        public async Task PostRelacion(RelacionDTO Relacion)
        {
            if (Relacion != null)
            {
                await _httpsJsonClientProvider.PostAsync(Constantes.RELACION_URL, Relacion);
            }
            else
            {
                MessageBox.Show("No se ha podido cargar la relacion, no se ha realizado el cambio");
            }
        }
        public async Task<bool> DeleteRelacion(string id)//await _httpsJsonClientProvider.PatchAsync($"{Constantes.RELACION_URL}{_obj.Id}", _obj) != null
        {
            if (await _httpsJsonClientProvider.DeleteAsync($"{Constantes.RELACION_URL}", id))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar la relacion");
                return false;
            }
        }

        public async Task<bool> DeleteAllRelaciones()
        {
            bool exito = true;
            IEnumerable<RelacionDTO> lista = await GetRelaciones();
            foreach (RelacionDTO obj in lista)
            {
                if (!await DeleteRelacion(obj.Id.ToString()))
                {
                    MessageBox.Show("No se ha podido eliminar la relacion");
                    exito = false;
                }

            }
            return exito;
        }

        public async Task PostRelaciones(IEnumerable<RelacionDTO> lista)
        {
            if (lista != null)
            {
                foreach (RelacionDTO obj in lista)
                {

                    await PostRelacion(obj);

                }
            }
            else
            {
                MessageBox.Show("No se ha podido cargar la lista, no se ha realizado el cambio");
            }

        }
    }
}
