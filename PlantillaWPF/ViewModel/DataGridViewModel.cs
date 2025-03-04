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
using Microsoft.Win32;
using PlantillaWPF.Utils;
using System.Windows;

namespace PlantillaWPF.ViewModel
{
    public partial class DataGridViewModel : ViewModelBase
    {
        [ObservableProperty]
        private DateTime? _releaseDate;
        private readonly IFileService<ObjectDTO> _fileService;

        private readonly IObjectProvider _objectProvider;
        public DataGridViewModel(IObjectProvider objectProvider, IFileService<ObjectDTO> fileService)
        {
            _objectProvider = objectProvider;
            _fileService = fileService;
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
            
            var viewModel = new AddViewModel(new ObjectService(new HttpsJsonClientService<ObjectDTO>()));
            var view = new AddView { DataContext = viewModel };
            view.ShowDialog();
            LoadAsync();


        }
        
        [RelayCommand]
        public void Export()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, Objects);
            }
        }
        [RelayCommand]
        public async void Import()
        {
             
            var openFileDialog = new OpenFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (openFileDialog.ShowDialog() == true)
            {

                var loadedObjects = _fileService.Load(openFileDialog.FileName);
                if (loadedObjects == null || !loadedObjects.Any())
                {
                    MessageBox.Show("El archivo seleccionado está vacío o no es válido.");
                    
                }
                await _objectProvider.DeleteAllObjetos();
                await _objectProvider.PostObjetos(loadedObjects);
                //foreach (var obj in loadedObjects)
                //{
                //    await _objectProvider.PostObjeto(obj);
                //}
                Objects.Clear();
                Objects = new ObservableCollection<ObjectDTO>(loadedObjects);
            }
            

        }
        public async Task CargarTabla()
        {

            IEnumerable<ObjectDTO> requestData = await _objectProvider.GetObjetos();
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
