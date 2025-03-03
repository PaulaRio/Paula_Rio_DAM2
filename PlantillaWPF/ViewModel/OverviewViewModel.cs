using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlantillaWPF.DTO;
using PlantillaWPF.Service;
using PlantillaWPF.DTOs;
using PlantillaWPF.Models;

using PlantillaWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.Interfaces;
using PlantillaWPF.Utils;

namespace PlantillaWPF.ViewModel
{
    public partial class OverviewViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<ObjectModel> _items;
        
        private readonly IHttpsJsonClientProvider<ObjectDTO> _httpsJsonClientProvider;
        private readonly StackPanelViewModel _stackPanelViewModel;
        private readonly IStringUtils _stringUtils;
        [ObservableProperty]
        private ViewModelBase? _selectedViewModel;

        public OverviewViewModel(IHttpsJsonClientProvider<ObjectDTO> httpsJsonClientProvider,
            StackPanelViewModel stackPanelViewModel, IStringUtils stringUtils)
        {
            _httpsJsonClientProvider = httpsJsonClientProvider;
            _stackPanelViewModel = stackPanelViewModel;
            _stringUtils = stringUtils;
            _items = new ObservableCollection<ObjectModel>();
        }

        public override async Task LoadAsync()
        {
            IEnumerable<ObjectDTO> objetos = await _httpsJsonClientProvider.GetAsync(Constantes.OBJECT_URL);
            Items = new ObservableCollection<ObjectModel>();
            foreach (var objeto in objetos)
            {
                Items.Add(ObjectModel.CreateModelFromDTO(objeto));
            }
        }

        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            _stackPanelViewModel.SetIdObject(_stringUtils.ConvertToInteger(parameter?.ToString() ?? string.Empty) ?? int.MinValue);
            _stackPanelViewModel.SetParentViewModel(this);
            SelectedViewModel = _stackPanelViewModel;
            await _stackPanelViewModel.LoadAsync();
        }

    }
}
