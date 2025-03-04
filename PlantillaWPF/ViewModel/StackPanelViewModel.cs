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

namespace PlantillaWPF.ViewModel
{
    public partial class StackPanelViewModel : ViewModelBase
    {
        
        [ObservableProperty]
        private ObservableCollection<ObjectModel> _items;
        private int _objetoId;
        private ObjectDTO _obj;
        private  OverviewViewModel _overviewViewModel;
        private readonly IHttpsJsonClientProvider<ObjectDTO> _httpsJsonClientProvider;
        [ObservableProperty]
        private StackPanelItemModel _Item;
        private readonly IObjectProvider _objectProvider;

        public StackPanelViewModel(IHttpsJsonClientProvider<ObjectDTO> httpsJsonClientProvider, IObjectProvider objectProvider)
        {
            _httpsJsonClientProvider=httpsJsonClientProvider ?? throw new ArgumentNullException(nameof(httpsJsonClientProvider));
            _objectProvider = objectProvider;
            _items = new ObservableCollection<ObjectModel>();

        }
        public void SetIdObject(int id)
        {
            _objetoId= id;
        }

        public override async Task LoadAsync()
        {
            IEnumerable<ObjectDTO> objetos = await _httpsJsonClientProvider.GetAsync(Constantes.OBJECT_URL);
            Items = new ObservableCollection<ObjectModel>();
            foreach (var objeto in objetos)
            {
                Items.Add(ObjectModel.CreateModelFromDTO(objeto));
            }
            _obj = objetos.FirstOrDefault(x => x.Id == _objetoId);
            Item = StackPanelItemModel.CreateModelFromDTO(_obj) ;
        
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
            _obj.Name=Item.Name;
            _obj.Description = Item.Description;
            _obj.Photo = Item.Photo;

            if ( await _httpsJsonClientProvider.PatchAsync($"{Constantes.OBJECT_URL}{_obj.Id}", _obj) != null)
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
