using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using Pokemon.Interfaces;
using Pokemon.Model;
using Pokemon.Services;
using Pokemon.Utils;

namespace Pokemon.ViewModel
{
    public partial class HistoricoViewModel : ViewModelBase
    {
        private readonly IFileService<PokeHistoricoModel> _fileService;
         

        public HistoricoViewModel(IFileService<PokeHistoricoModel> fileService) 
        {
            _fileService = fileService;
            Pokemons = new ObservableCollection<PokeHistoricoModel>();
        }
        [ObservableProperty]
        private ObservableCollection<PokeHistoricoModel> pokemons;

        [RelayCommand]
        public void SaveToFile()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constantes.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, Pokemons);
            }
        }



        public override async Task LoadAsync()
        {
            //var historicoData =  HttpJsonClient<PokeHistoricoModel>.GetMyApi;
            //Pokemons.Add(historicoData);

           
               
        }




    }
}
