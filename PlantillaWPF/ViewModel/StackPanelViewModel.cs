using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private  OverviewViewModel _overviewViewModel;
        private readonly IHttpsJsonClientProvider<ObjectDTO> _httpsJsonClientProvider;
        [ObservableProperty]
        private StackPanelItemModel _Item;

       public StackPanelViewModel(IHttpsJsonClientProvider<ObjectDTO> httpsJsonClientProvider)
        {
            _httpsJsonClientProvider=httpsJsonClientProvider ?? throw new ArgumentNullException(nameof(httpsJsonClientProvider));
            _items= new ObservableCollection<ObjectModel>();

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
            Item = StackPanelItemModel.CreateModelFromDTO(objetos.FirstOrDefault(x => x.Id == _objetoId) ?? new ObjectDTO());
        }
        internal void SetParentViewModel(ViewModelBase overviewViewModel)
        {
            if (overviewViewModel is OverviewViewModel overview)
            {
                _overviewViewModel = overview;
            }

        }

        [RelayCommand]
        private async Task Close(object? parameter)
        {
            if (_overviewViewModel != null)
            {
                _overviewViewModel.SelectedViewModel = null;
            }
        }



    }
}
