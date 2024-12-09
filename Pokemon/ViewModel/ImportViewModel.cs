using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Pokemon.Interfaces;
using Pokemon.Model;
using Pokemon.Utils;

namespace Pokemon.ViewModel
{
    public partial class ImportViewModel : ViewModelBase
    {
        private readonly IFileService<PokeHistoricoModel> _fileService;
       

        public ImportViewModel(IFileService<PokeHistoricoModel> fileService)
        {
            _fileService = fileService;
            Pokemons = new ObservableCollection<PokeHistoricoModel>();
        }
        [ObservableProperty]
        private ObservableCollection<PokeHistoricoModel> pokemons;

        [RelayCommand]
        public async void LoadFromFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (openFileDialog.ShowDialog() == true)
            {
                
                var loadedPokemons = _fileService.Load(openFileDialog.FileName);
                Pokemons.Clear();
                Pokemons = new ObservableCollection<PokeHistoricoModel>(loadedPokemons);
            }
        }
    }
}
