using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicApp.DTO;
using BasicApp.Interfaces;
using BasicApp.Utils;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp.ViewModel
{
    
    public partial class DataViewModel : ViewModelBase
    { 
        private readonly IGhibliProvider _ghibliProvider;

        private  MainViewModel _mainViewModel;
        public DataViewModel(IGhibliProvider ghibliProvider)
        {
            _ghibliProvider=ghibliProvider;
            Films = new ObservableCollection<GhibliDTO>();
            
        }
        [ObservableProperty]
        private ObservableCollection<GhibliDTO> films;


        [RelayCommand]
        private void Logout_Click()
        {
            _mainViewModel.SelectViewModel(_mainViewModel.LoginViewModel);

        }

        public async Task CargarTabla()
        {

            List<GhibliDTO> requestData = await _ghibliProvider.GetAsync();
            foreach (var element in requestData)
            {
                Films.Add(element);
            }

        }
        public override async Task LoadAsync()
        {
            _mainViewModel = App.Current.Services.GetService<MainViewModel>();
            Films.Clear();
            await CargarTabla();

        }
        
    }

}
