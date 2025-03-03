using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using PlantillaWPF.View;
using PlantillaWPF.Interfaces;
using PlantillaWPF.DTOs;
using PlantillaWPF.Services;

namespace PlantillaWPF.ViewModel
{
    public partial class DataGridViewModel : ViewModelBase
    {
        [ObservableProperty]
        private DateTime? _releaseDate;


        private readonly IObjectProvider _objectProvider;
        public DataGridViewModel(IObjectProvider objectProvider)
        {
            _objectProvider = objectProvider;
            Objects = new ObservableCollection<ObjectDTO>();

        }
        [ObservableProperty]
        private ObservableCollection<ObjectDTO> objects;



        private void MyDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "CreatedDate")
            {
                var column = e.Column as DataGridTextColumn;
                if (column != null)
                {
                    column.Binding = new Binding("Fecha creacion")
                    {
                        StringFormat = "dd/MM/yyyy"
                    };
                }
            }
        }
        [RelayCommand]
        private void Add_Click()
        {
            // var popUpWindow = App.Current.Services.GetService<AddView>();

            //popUpWindow?.Show();
            var viewModel = new AddViewModel(new ObjectService(new HttpsJsonClientService<ObjectDTO>()));
            var view = new AddView { DataContext = viewModel };
            view.ShowDialog();
            LoadAsync();


        }
        public async Task CargarTabla()
        {

            IEnumerable<ObjectDTO> requestData = await _objectProvider.GetObjeto();
            foreach (var element in requestData)
            {
                Objects.Add(element);
            }

        }
        public override async Task LoadAsync()
        {
           // _mainViewModel = App.Current.Services.GetService<MainViewModel>();
            Objects.Clear();
            await CargarTabla();

        }
    }
}
