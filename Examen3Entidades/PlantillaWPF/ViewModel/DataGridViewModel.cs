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
using PlantillaWPF.Models;

namespace PlantillaWPF.ViewModel
{
    public partial class DataGridViewModel : ViewModelBase
    {
        [ObservableProperty]
        private DateTime? _releaseDate;
        private IEnumerable<RelacionDTO> _relaciones;
        private readonly IFileService<ObjectDTO> _fileService;

        private readonly IObjectProvider _objectProvider;
        private readonly IRelacionProvider _relacionProvider;
        public DataGridViewModel(IObjectProvider objectProvider, IFileService<ObjectDTO> fileService,IRelacionProvider relacionProvider)
        {
            _objectProvider = objectProvider;
            _relacionProvider= relacionProvider;
            _fileService = fileService;
            Objects = new ObservableCollection<ObjectModel>();

        }
        [ObservableProperty]
        private ObservableCollection<ObjectModel> objects;

    


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
            
            var viewModel = new AddObjetoViewModel(new ObjectService(new HttpsJsonClientService<ObjectDTO>()), 
                new AutorService(new HttpsJsonClientService<AutorDTO>()), 
                new GrupoService(new HttpsJsonClientService<GrupoDTO>()),
                new RelacionService(new HttpsJsonClientService<RelacionDTO>()));
            var view = new AddObjetoView { DataContext = viewModel };
            view.ShowDialog();
             LoadAsync();


        }
        
        [RelayCommand]
        public void Export()
        {
            List<ObjectDTO> lista=new List<ObjectDTO>();
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                foreach (var obj in Objects)
                {
                    lista.Add(ObjectDTO.CreateDTOFromModel(obj));

                }
                _fileService.Save(saveFileDialog.FileName, lista);
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
                
                Objects.Clear();
               
                foreach (var obj in loadedObjects)
                {   
                    Objects.Add(ObjectModel.CreateModelFromDTO(obj, _relaciones));
                    
                }
            }
            

        }
        public async Task CargarTabla()
        {

            IEnumerable<ObjectDTO> requestData = await _objectProvider.GetObjetos();

            foreach (var element in requestData)
            {
                Objects.Add(ObjectModel.CreateModelFromDTO(element, _relaciones));
            }

        }
        public override async Task LoadAsync()
        {
            _relaciones = await _relacionProvider.GetRelaciones();
            Objects.Clear();
            await CargarTabla();

        }
    }
}
