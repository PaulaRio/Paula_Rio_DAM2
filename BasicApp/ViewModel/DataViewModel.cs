using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BasicApp.DTO;
using BasicApp.Interfaces;
using BasicApp.Utils;
using BasicApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace BasicApp.ViewModel
{
    
    public partial class DataViewModel : ViewModelBase
    { 
        private readonly IGhibliProvider _ghibliProvider;
        [ObservableProperty]
        private DateTime? _releaseDate;

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

        private void MyDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Estreno")
            {
                var column = e.Column as DataGridTextColumn;
                if (column != null)
                {
                    column.Binding = new Binding("Estreno")
                    {
                        StringFormat = "dd/MM/yyyy"
                    };
                }
            }
        }

        [RelayCommand]
        private void Add_Click()
        {
            var popUpWindow = App.Current.Services.GetService<AddView>();

            popUpWindow?.Show();


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
