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
        public string _Descripcion;
        [ObservableProperty]
        public string _Photo;
        [ObservableProperty]
        public string _AutoresIds;
        [ObservableProperty]
        public string _GruposIds;

        
        private readonly IObjectProvider _objectProvider;
        private readonly IAutorProvider _autorProvider;
        private readonly IGrupoProvider _grupoProvider;

        public AddObjetoViewModel( IObjectProvider objectProvider,IAutorProvider autorProvider, IGrupoProvider grupoProvider)
        {
            _objectProvider=objectProvider;
            _autorProvider=autorProvider;
            _grupoProvider =grupoProvider;

            _allIdAutores = new List<int>(); 
            _allIdGrupos = new List<int>();

        }

       
        [RelayCommand]
        private void CancelarVentana(object? parameter)
        {
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is AddObjetoView)?.Close();
        }

        //TODO: comprobacion campos
        [RelayCommand]
        private async Task Save()
        {
            if (await PostObjectAsync())
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
            IEnumerable<AutorDTO> autores = await _autorProvider.GetAutores();
            _allAutores = new ObservableCollection<AutorDTO>();
            foreach (var autor in autores)
            {
                _allAutores.Add(autor);
                _allIdAutores.Add(autor.Id);
            }
            IEnumerable<GrupoDTO> grupos = await _grupoProvider.GetGrupos();
            _allGrupos = new ObservableCollection<GrupoDTO>();
            foreach (var grupo in grupos)
            {
                _allGrupos.Add(grupo);
                _allIdGrupos.Add(grupo.Id);
            }


        }


        private async Task<bool> PostObjectAsync()
        {
            await LoadAsync();
            int[] listaAutores=string.IsNullOrEmpty(_AutoresIds)?new int [0]:listNum(_AutoresIds);
            int[] listaGrupos = string.IsNullOrEmpty(_GruposIds) ? new int[0]: listNum(_GruposIds);
            if (!await _autorProvider.ExistenAutores(listaAutores.ToList()))
            {
                MessageBox.Show("Uno o más autores no existen. Debes crear los autores primero.");
                _AutoresIds = string.Empty; 
                return false; 
            }
            if (!await _grupoProvider.ExistenGrupos(listaGrupos.ToList()))
            {
                MessageBox.Show("Uno o más grupos no existen. Debes crear los grupos primero.");
                _GruposIds = string.Empty; 
                return false; 
            }
            try
            {
                ObjectDTO nuevoObjeto = new ObjectDTO
                {
                    Name = _Nombre,
                    Description = _Descripcion,
                    Photo = string.IsNullOrEmpty(_Photo) ? "string" : _Photo,
                    //AutoresIds = listaAutores.Length > 0 ? listaAutores.ToList() : new List<int>(),
                    //GruposIds = listaGrupos.Length > 0 ? listaGrupos.ToList() : new List<int>(),


                };

               

                await _objectProvider.PostObjeto(nuevoObjeto);
                MessageBox.Show("Objeto creado exitosamente");
                return true;
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private int[] listNum(string cad)
        {
            if (string.IsNullOrEmpty(cad))
            {
                return new int[0]; 
            }

            
            cad = cad.Replace(" ", "");
            string[] numeros;

            
            if (cad.Contains(","))
            {
                numeros = cad.Split(',');
            }
            else
            {
                
                numeros = new string[] { cad };
            }

            
            return numeros.Select(n => int.Parse(n)).ToArray();
        }
    }
}
