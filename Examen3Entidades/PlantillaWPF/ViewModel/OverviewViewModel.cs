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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PlantillaWPF.ViewModel
{
    public partial class OverviewViewModel : ViewModelBase
    {
        [ObservableProperty]
        public int _IdFiltro=0 ;
        [ObservableProperty]
        private ObservableCollection<ObjectModel> _items;
        private IEnumerable<RelacionDTO> _relaciones;
        private ObjectDTO _obj;
       
        private List<int> _gruposIds;
        private readonly IHttpsJsonClientProvider<ObjectDTO> _httpsJsonClientProvider;
        private readonly StackPanelViewModel _stackPanelViewModel;
        private readonly IStringUtils _stringUtils;
        private readonly IObjectProvider _objectProvider;
        private readonly IAutorProvider _autorProvider;
        private readonly IGrupoProvider _grupoProvider;
        private readonly IRelacionProvider _relacionProvider;
        [ObservableProperty]
        private ViewModelBase? _selectedViewModel;

        public OverviewViewModel(IHttpsJsonClientProvider<ObjectDTO> httpsJsonClientProvider,
            StackPanelViewModel stackPanelViewModel, IStringUtils stringUtils, IObjectProvider objectProvider,
            IAutorProvider autorProvider, IGrupoProvider grupoProvider,IRelacionProvider relacionProvider)
        {
            _objectProvider = objectProvider;
            _autorProvider = autorProvider;
            _grupoProvider = grupoProvider;
            _httpsJsonClientProvider = httpsJsonClientProvider;
            _stackPanelViewModel = stackPanelViewModel;
            _stringUtils = stringUtils;
            _items = new ObservableCollection<ObjectModel>();
            _relacionProvider = relacionProvider;
        }

        public override async Task LoadAsync()
        {
            // Obtén todos los objetos
            IEnumerable<ObjectDTO> objetos = await _httpsJsonClientProvider.GetAsync(Constantes.OBJECT_URL);

            // Filtrar los objetos según el _IdFiltro
            var objetosFiltrados = FiltrarObjetos(objetos, _IdFiltro);

            // Actualizar la colección observable de objetos
            Items = new ObservableCollection<ObjectModel>(objetosFiltrados);
            _relaciones = await _relacionProvider.GetRelaciones();
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
            if (_IdFiltro == null || _IdFiltro == 0)  
            {
               
                return objetos.Select(obj => ObjectModel.CreateModelFromDTO(obj, _relaciones));
            }


            return objetos.Where(obj => obj.IdAutor == _IdFiltro || _relaciones.Where(r => r.IdObjeto == obj.Id).Any(r => r.IdGrupo == _IdFiltro))
                .Select(obj => ObjectModel.CreateModelFromDTO(obj,_relaciones)).ToList();
            
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
                new GrupoService(new HttpsJsonClientService<GrupoDTO>()),
                new RelacionService(new HttpsJsonClientService<RelacionDTO>()));
            var view = new AddObjetoView { DataContext = viewModel };
            view.ShowDialog();
            LoadAsync();


        }
        [RelayCommand]
        private void AddAutor()
        {
            // var viewModel = App.Current.Services.GetService<AddAutorViewModel>();
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
