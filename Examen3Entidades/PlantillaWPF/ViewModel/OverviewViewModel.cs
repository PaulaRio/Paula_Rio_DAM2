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
using PlantillaWPF.Services;
using PlantillaWPF.View;
using Microsoft.Extensions.DependencyInjection;

namespace PlantillaWPF.ViewModel
{
    public partial class OverviewViewModel : ViewModelBase
    {
        [ObservableProperty]
        public int _IdFiltro=0 ;
        [ObservableProperty]
        private ObservableCollection<ObjectModel> _items;
        private ObjectDTO _obj;
        private List<int> _autoresIds;
        private List<int> _gruposIds;
        private readonly IHttpsJsonClientProvider<ObjectDTO> _httpsJsonClientProvider;
        private readonly StackPanelViewModel _stackPanelViewModel;
        private readonly IStringUtils _stringUtils;
        private readonly IObjectProvider _objectProvider;
        private readonly IAutorProvider _autorProvider;
        private readonly IGrupoProvider _grupoProvider;
        [ObservableProperty]
        private ViewModelBase? _selectedViewModel;

        public OverviewViewModel(IHttpsJsonClientProvider<ObjectDTO> httpsJsonClientProvider,
            StackPanelViewModel stackPanelViewModel, IStringUtils stringUtils, IObjectProvider objectProvider,
            IAutorProvider autorProvider, IGrupoProvider grupoProvider)
        {
            _objectProvider = objectProvider;
            _autorProvider = autorProvider;
            _grupoProvider = grupoProvider;
            _httpsJsonClientProvider = httpsJsonClientProvider;
            _stackPanelViewModel = stackPanelViewModel;
            _stringUtils = stringUtils;
            _items = new ObservableCollection<ObjectModel>();

        }

        public override async Task LoadAsync()
        {
            // Obtén todos los objetos
            IEnumerable<ObjectDTO> objetos = await _httpsJsonClientProvider.GetAsync(Constantes.OBJECT_URL);

            // Filtrar los objetos según el _IdFiltro
            var objetosFiltrados = FiltrarObjetos(objetos, _IdFiltro);

            // Actualizar la colección observable de objetos
            Items = new ObservableCollection<ObjectModel>(objetosFiltrados);

            //IEnumerable<ObjectDTO> objetos = await _httpsJsonClientProvider.GetAsync(Constantes.OBJECT_URL);//Todos objetos
            //Items = new ObservableCollection<ObjectModel>();
            //foreach (var objeto in objetos)
            //{
            //    Items.Add(ObjectModel.CreateModelFromDTO(objeto));

            //}
            //var objetosFiltrados = FiltrarObjetos(objetos, _IdFiltro);


            //Items = new ObservableCollection<ObjectModel>((IEnumerable<ObjectModel>)objetosFiltrados);


        }
        [RelayCommand]
        public async Task Filtrar()
        {
            // Asegúrate de que se aplica el filtro correctamente
            await LoadAsync();
        }

        public IEnumerable<ObjectModel> FiltrarObjetos(IEnumerable<ObjectDTO> objetos, int _IdFiltro)
        {
            if (_IdFiltro == null || _IdFiltro == 0)  // Si _IdFiltro es 0 (o algún valor que indique que no se está filtrando)
            {
                // Si el filtro es 0, devolver todos los objetos sin aplicar el filtro
                return objetos.Select(obj => ObjectModel.CreateModelFromDTO(obj));
            }

            // Si el filtro tiene un valor, se filtra
            return objetos
                .Where(obj => obj.AutoresIds.Contains(_IdFiltro) || obj.GruposIds.Contains(_IdFiltro))
                .Select(obj => ObjectModel.CreateModelFromDTO(obj));  // Transformar los objetos en ObjectModel
        }

        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            _stackPanelViewModel.SetIdObject(_stringUtils.ConvertToInteger(parameter?.ToString() ?? string.Empty) ?? int.MinValue);
            _stackPanelViewModel.SetParentViewModel(this);
            SelectedViewModel = _stackPanelViewModel;
            await _stackPanelViewModel.LoadAsync();
        }
        
        [RelayCommand]
        private  void AddObjeto()
        {

            var viewModel = new AddObjetoViewModel(new ObjectService(new HttpsJsonClientService<ObjectDTO>()),
                new AutorService(new HttpsJsonClientService<AutorDTO>()),
                new GrupoService(new HttpsJsonClientService<GrupoDTO>()));
            var view = new AddObjetoView { DataContext = viewModel };
            view.ShowDialog();
            LoadAsync();


        }
        [RelayCommand]
        private void AddAutor()
        {

            var viewModel = new AddAutorViewModel(new ObjectService(new HttpsJsonClientService<ObjectDTO>()),
                new AutorService(new HttpsJsonClientService<AutorDTO>()));
            var view = new AddAutorView { DataContext = viewModel };
            view.ShowDialog();
            LoadAsync();


        }
        [RelayCommand]
        private void AddGrupo()
        {

            var viewModel = new AddGrupoViewModel(new ObjectService(new HttpsJsonClientService<ObjectDTO>()),
                new GrupoService(new HttpsJsonClientService<GrupoDTO>()));
            var view = new AddGrupoView { DataContext = viewModel };
            view.ShowDialog();
            LoadAsync();


        }
        

    }
}
