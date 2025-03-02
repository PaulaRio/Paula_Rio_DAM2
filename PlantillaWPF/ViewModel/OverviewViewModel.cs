using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Examen_Galaxy.Constants;
using Examen_Galaxy.DTO;
using Examen_Galaxy.Interface;
using Examen_Galaxy.Model;
using Examen_Galaxy.Service;
using PlantillaWPF.DTOs;
using PlantillaWPF.Models;
using PlantillaWPF.Providers;
using PlantillaWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Galaxy.ViewModel
{
    public partial class OverviewViewModel : ViewModelBase
    {

        [ObservableProperty]
        private ObservableCollection<ObjectModel> _items;
        IHttpsJsonClientProvider<UserDTO> _httpsJsonClientProvider;
        private readonly IHttpJsonProvider<ObjectDTO> _httpJsonProvider;
        private readonly ExplorePlanetViewModel _explorePlanetViewModel;
        private readonly IStringUtils _stringUtils;
        [ObservableProperty]
        private ViewModelBase? _selectedViewModel;

        public OverviewViewModel(IHttpJsonProvider<PlanetaDTO> httpJsonProvider,
            ExplorePlanetViewModel explorePlanetViewModel, IStringUtils stringUtils)
        {
            _httpJsonProvider = httpJsonProvider;
            _explorePlanetViewModel = explorePlanetViewModel;
            _stringUtils = stringUtils;
            _items = new ObservableCollection<PlanetModel>();
        }

        public override async Task LoadAsync()
        {
            IEnumerable<PlanetaDTO> planetas = await _httpJsonProvider.GetAsync(Constantes.PLANET_RESOURCE);
            Items = new ObservableCollection<PlanetModel>();
            foreach (var planeta in planetas)
            {
                Items.Add(PlanetModel.CreateModelFromDTO(planeta));
            }
        }

        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            _explorePlanetViewModel.SetIdPlanet(_stringUtils.ConvertToInteger(parameter?.ToString() ?? string.Empty) ?? int.MinValue);
            _explorePlanetViewModel.SetParentViewModel(this);
            SelectedViewModel = _explorePlanetViewModel;
            await _explorePlanetViewModel.LoadAsync();
        }
    }
}
