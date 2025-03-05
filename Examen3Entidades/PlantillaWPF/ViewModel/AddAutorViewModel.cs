using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PlantillaWPF.View;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.ComponentModel;
using PlantillaWPF.Interfaces;
using PlantillaWPF.DTOs;
using PlantillaWPF.Models;
using PlantillaWPF.Utils;
using System.Collections.ObjectModel;

namespace PlantillaWPF.ViewModel
{
   public partial class AddAutorViewModel : ViewModelBase
    {
        private readonly IHttpsJsonClientProvider<AutorDTO> _httpsJsonClientProvider;
        private ICollection<AutorDTO> _allAutores;
        private List<int> _allIdAutores;
        [ObservableProperty]
        public string _Nombre;
        [ObservableProperty]
        public string _Descripcion;
        [ObservableProperty]
        public string _IdObjeto;
        
        
        private readonly IObjectProvider _objectProvider;
        private readonly IAutorProvider _autorProvider;
       

        public AddAutorViewModel( IObjectProvider objectProvider,IAutorProvider autorProvider)
        {
            _objectProvider=objectProvider;
            _autorProvider=autorProvider;
           


        }

       
        [RelayCommand]
        private void CancelarVentana(object? parameter)
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is AddAutorView)?.Close();
        }

        //TODO: comprobacion campos
        [RelayCommand]
        private async Task Save()
        {
            if (await PostAutorAsync())
            {
                MessageBox.Show("Post exitoso");
                
            }
            else
            {
                MessageBox.Show("Post fallido");
                
            }
            


        }
        public override async Task LoadAsync()
        {
            IEnumerable<AutorDTO> autores = await _httpsJsonClientProvider.GetAsync(Constantes.OBJECT_URL);
            _allAutores = new ObservableCollection<AutorDTO>();
            foreach (var autor in autores)
            {
                _allAutores.Add(autor);
                _allIdAutores.Add(autor.Id);
            }

           
        }


        private async Task<bool> PostAutorAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(_IdObjeto))
                {
                    MessageBox.Show("El campo 'ID Objeto' es obligatorio.");
                    return false;
                }
                if ( !await _objectProvider.ExisteObjeto(IdObjeto))
                {
                MessageBox.Show("El ID del objeto no existe. Debe ser un objeto válido.");
                return false;
                }
           
                AutorDTO nuevoAutor = new AutorDTO
                {
                    Name = _Nombre,
                    Description = _Descripcion,
                    IdObjeto =int.Parse(_IdObjeto),
                };

                await _autorProvider.PostAutor(nuevoAutor);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        
    }
}
