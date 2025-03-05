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
using System.Collections.ObjectModel;
using PlantillaWPF.Utils;

namespace PlantillaWPF.ViewModel
{
   public partial class AddObjetoViewModel : ViewModelBase
    {
        private readonly IHttpsJsonClientProvider<AutorDTO> _httpsJsonClientProvider;
        private ICollection<AutorDTO> _allAutores;
        private ICollection<GrupoDTO> _allGrupos;
        private List<int> _allIdAutores;
        private List<int> _allIdGrupos;
        
        [ObservableProperty]
        public string _Nombre;
        [ObservableProperty]
        public string _Email;
        [ObservableProperty]
        public string _IdsGrupos;



        private readonly IObjectProvider _objectProvider;
        private readonly IAutorProvider _autorProvider;
        private readonly IGrupoProvider _grupoProvider;
        private readonly IRelacionProvider _relacionProvider;

        public AddObjetoViewModel( IObjectProvider objectProvider, IAutorProvider autorProvider, IGrupoProvider grupoProvider, IRelacionProvider relacionProvider)
        {
            _objectProvider = objectProvider;
            _autorProvider = autorProvider;
            _grupoProvider = grupoProvider;
            _relacionProvider = relacionProvider;

            _allIdAutores = new List<int>();
            _allIdGrupos = new List<int>();
            
        }


        [RelayCommand]
        private void CancelarVentana(object? parameter)
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is AddObjetoView)?.Close();
        }

       
        [RelayCommand]
        private async Task Save()
        {
            await LoadAsync();
            ObjectDTO objeto = await PostObjectAsync();
            if (objeto!=null)
            {
                await PostRelacionAsync(objeto);
                MessageBox.Show("Post exitoso");
                
            }
            else
            {
                MessageBox.Show("Post fallido");
                
            }
            


        }
        public override async Task LoadAsync()
        {
            IEnumerable<AutorDTO> autores = await _autorProvider.GetAutores();
            _allAutores = new ObservableCollection<AutorDTO>();
            foreach (var autor in autores)
            {
                //_allAutores.Add(autor);
                _allIdAutores.Add(autor.Id);
            }
            IEnumerable<GrupoDTO> grupos = await _grupoProvider.GetGrupos();
            _allGrupos = new ObservableCollection<GrupoDTO>();
            foreach (var grupo in grupos)
            {
                //_allGrupos.Add(grupo);
                _allIdGrupos.Add(grupo.Id);
            }


        }
        private async Task PostRelacionAsync(ObjectDTO objeto)
        {
            

            foreach (var idGrupo in IdsGrupos)
            {  
                await _relacionProvider.PostRelacion(new RelacionDTO { IdGrupo= idGrupo,IdObjeto= objeto.Id });
                

            }
            

        }

        private async Task<ObjectDTO> PostObjectAsync()
        {
            
   
            bool compGrupos= ComprobarGrupos();
           

            try
            {
                if (compGrupos)
                {
                    ObjectDTO nuevoObjeto = new ObjectDTO
                    {
                        Name = _Nombre,
                        Email = _Email,
                        
                        //GruposIds = listaGrupos.Length > 0 ? listaGrupos.ToList() : new List<int>(),


                    };



                    return await _objectProvider.PostObjeto(nuevoObjeto);
                    MessageBox.Show("Objeto creado exitosamente");
                    


                }

                return default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return default;
            }
            


        }

        private bool ComprobarGrupos()
        {
            List<int> gruposIds = string.IsNullOrEmpty(IdsGrupos) ? new List<int>() : IdsGrupos.Split(',').Select(int.Parse).ToList();
            foreach (var grupoId in gruposIds)
            {
                if (!_allIdGrupos.Contains(grupoId))
                {
                    MessageBox.Show("Uno de los grupos introducidos no existe, debes crearlo primero");
                    gruposIds.Clear();
                    return false;
                }

            }
            return true;
        }
        
    }
}
