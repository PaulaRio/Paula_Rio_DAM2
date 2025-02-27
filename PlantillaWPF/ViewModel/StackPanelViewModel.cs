using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantillaWPF.Models;

namespace PlantillaWPF.ViewModel
{
    public partial class StackPanelViewModel : ViewModelBase
    {
        //private readonly ILibrosProvider _librosProvider;


        private ObservableCollection<StackPanelItemModel> _items;

        public ObservableCollection<StackPanelItemModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        //public StackPanelViewModel(ILibrosProvider librosProvider)
        //{
        //    _librosProvider = librosProvider;
        //}


        private async Task GenerateRandomItemsAsync()
        {
            Items = new ObservableCollection<StackPanelItemModel>();

            //List<LibroDTO> listaLibros = await _librosProvider.GetAsync();

            //foreach (var libro in listaLibros)
            //{
            //    Items.Add(StackPanelItemModel.CreateModelFromDTO(libro));
            //}
        }

        public override async Task LoadAsync()
        {
            await GenerateRandomItemsAsync();
            base.LoadAsync();
        }
    }
}
