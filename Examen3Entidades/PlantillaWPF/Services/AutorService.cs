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
    public class AutorService : IAutorProvider
    {
        private readonly IHttpsJsonClientProvider<AutorDTO> _httpsJsonClientProvider;
        public AutorService(IHttpsJsonClientProvider<AutorDTO> httpsJsonClientProvider)
        {
            _httpsJsonClientProvider = httpsJsonClientProvider;

        }


        public async Task<IEnumerable<AutorDTO>> GetAutores()
        {
            return await _httpsJsonClientProvider.GetAsync(Constantes.AUTOR_URL);
        }

        public async Task<AutorDTO> GetOneAutor(string id)
        {
            return await _httpsJsonClientProvider.GetByIdAsync(Constantes.AUTOR_URL, id);
        }

        public async Task PatchAutor(AutorDTO Autor)
        {
            if (Autor != null)
            {
                await _httpsJsonClientProvider.PatchAsync(Constantes.AUTOR_URL, Autor);
            }
            else
            {
                MessageBox.Show("No se ha podido cargar el objeto, no se ha realizado el cambio");
            }
        }

        public async Task PostAutor(AutorDTO Autor)
        {
            if (Autor != null)
            {
                await _httpsJsonClientProvider.PostAsync(Constantes.AUTOR_URL, Autor);
            }
            else
            {
                MessageBox.Show("No se ha podido cargar el objeto, no se ha realizado el cambio");
            }
        }
        public async Task<bool> DeleteAutor(string id)//await _httpsJsonClientProvider.PatchAsync($"{Constantes.AUTOR_URL}{_obj.Id}", _obj) != null
        {
            if (await _httpsJsonClientProvider.DeleteAsync($"{Constantes.AUTOR_URL}", id))
            {
                return true;
            }
            else
            {
                MessageBox.Show("No se ha podido eliminar el objeto");
                return false;
            }
        }

        public async Task<bool> DeleteAllAutores()
        {
            bool exito = true;
            IEnumerable<AutorDTO> lista = await GetAutores();
            foreach (AutorDTO obj in lista)
            {
                if (!await DeleteAutor(obj.Id.ToString()))
                {
                    MessageBox.Show("No se ha podido eliminar el objeto");
                    exito = false;
                }

            }
            return exito;
        }

        public async Task PostAutores(IEnumerable<AutorDTO> lista)
        {
            if (lista != null)
            {
                foreach (AutorDTO obj in lista)
                {

                    await PostAutor(obj);

                }
            }
            else
            {
                MessageBox.Show("No se ha podido cargar la lista, no se ha realizado el cambio");
            }

        }
        public async Task<bool> ExistenAutores(List<int> autoresIds)
        {
            try
            {

                var autores = await _httpsJsonClientProvider.GetAsync(Constantes.AUTOR_URL);


                var autoresExistentes = autores.Where(a => autoresIds.Contains(a.Id)).ToList();


                return autoresExistentes.Count == autoresIds.Count;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Error al verificar los autores: {ex.Message}");
                return false;
            }

        }
    }
}
