using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlantillaWPF.DTOs;
using PlantillaWPF.Interfaces;
using PlantillaWPF.Models;
using PlantillaWPF.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlantillaWPF.ViewModel
{
    public partial class StackPanelViewModel : ViewModelBase
    {

        //[ObservableProperty]
        //private ObservableCollection<ObjectModel> _items;
        [ObservableProperty]
        private ObservableCollection<AutorModel> _items;
        private int _objetoId;
        //private ObjectDTO _obj;
        private AutorDTO _obj;
        private  OverviewViewModel _overviewViewModel;
        private readonly IHttpsJsonClientProvider<AutorDTO> _httpsJsonClientProvider;
        [ObservableProperty]
        private StackPanelItemModel _Item;
        private readonly IObjectProvider _objectProvider;
        private readonly IAutorProvider _autorProvider;
        private readonly IRelacionProvider _relacionProvider;
        private IEnumerable<RelacionDTO> _relaciones;

        public StackPanelViewModel(IHttpsJsonClientProvider<AutorDTO> httpsJsonClientProvider, IAutorProvider autorProvider, IRelacionProvider relacionProvider)
        {
            _httpsJsonClientProvider = httpsJsonClientProvider ?? throw new ArgumentNullException(nameof(httpsJsonClientProvider));
            _autorProvider = autorProvider;
             _items = new ObservableCollection<AutorModel>();
            //_items = new ObservableCollection<AutorModel>();
            _relacionProvider = relacionProvider;
        }
        public void SetIdObject(int id)
        {
            _objetoId= id;
        }

        public override async Task LoadAsync()
        {
            IEnumerable<AutorDTO> autores = await _httpsJsonClientProvider.GetAsync(Constantes.AUTOR_URL);
            Items = new ObservableCollection<AutorModel>();
            //Items = new ObservableCollection<AutorDTO>();
            foreach (var autor in autores)
            {
                Items.Add(AutorModel.CreateModelFromDTO(autor));
            }
            _obj = autores.FirstOrDefault(x => x.Id == _objetoId);
            Item = StackPanelItemModel.CreateModelFromDTO(_obj) ;
            //Item = _obj;

        }
        internal void SetParentViewModel(ViewModelBase overviewViewModel)
        {
            if (overviewViewModel is OverviewViewModel overview)
            {
                _overviewViewModel = overview;
            }

        }

        [RelayCommand]
        private async Task Save()
        {
            _obj.IdObjeto=Item.IdObjeto;
           
            

            if ( await _httpsJsonClientProvider.PatchAsync($"{Constantes.AUTOR_URL}{_obj.Id}", _obj) != null)
            {
                _overviewViewModel.LoadAsync();
                MessageBox.Show("Datos modificados");


            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        [RelayCommand]
        private async Task Delete()
        {//await _objectProvider.DeleteObjeto(_obj.Id.ToString())
            if (await _objectProvider.DeleteObjeto(_obj.Id.ToString()))
            {
                _overviewViewModel.LoadAsync();
                MessageBox.Show("Objeto eliminado");


            }
            else
            {
                MessageBox.Show("Error al actualizar");
            }
        }


        [RelayCommand]
        private async Task Close()
        {
            if (_overviewViewModel != null)
            {
                _overviewViewModel.SelectedViewModel = null;
            }
        }



    }
}
