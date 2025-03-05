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
        //private IEnumerable<RelacionDTO> _relaciones;
        private readonly IFileService<GrupoDTO> _fileService;

        private readonly IObjectProvider _objectProvider;
        private readonly IGrupoProvider _grupoProvider;
        private readonly IRelacionProvider _relacionProvider;
        public DataGridViewModel(IGrupoProvider grupoProvider, IFileService<GrupoDTO> fileService,IRelacionProvider relacionProvider)
        {
            _grupoProvider = grupoProvider;
            _relacionProvider= relacionProvider;
            _fileService = fileService;
            Objects = new ObservableCollection<GrupoDTO>();

        }
        [ObservableProperty]
        private ObservableCollection<GrupoDTO> objects;

    


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
            List<GrupoDTO> lista=new List<GrupoDTO>();
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                foreach (var obj in Objects)
                {
                    lista.Add(obj);

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
                await _grupoProvider.DeleteAllGrupos();
                await _grupoProvider.PostGrupos(loadedObjects);
                
                Objects.Clear();
               
                foreach (var obj in loadedObjects)
                {   
                    Objects.Add(obj);
                    
                }
            }
            

        }
        public async Task CargarTabla()
        {

            IEnumerable<GrupoDTO> requestData = await _grupoProvider.GetGrupos();

            foreach (var element in requestData)
            {
                Objects.Add(element);
            }

        }
        public override async Task LoadAsync()
        {
            //_relaciones = await _relacionProvider.GetRelaciones();
            Objects.Clear();
            await CargarTabla();

        }
    }
}
