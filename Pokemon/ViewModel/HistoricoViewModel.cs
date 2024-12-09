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
using Pokemon.Model;
using Pokemon.Services;
using Pokemon.Utils;

namespace Pokemon.ViewModel
{
    public partial class HistoricoViewModel : ViewModelBase
    {
       // private readonly HistoricoApiService<PokeHistoricoModel> _historicoApiService;
        [ObservableProperty]
        private ObservableCollection<PokeHistoricoModel> pokemons;

        public HistoricoViewModel() 
        {
            //_historicoApiService = historicoApiService;
            Pokemons = new ObservableCollection<PokeHistoricoModel>();
        }

       


        public override async Task LoadAsync()
        {
            //var historicoData =  HttpJsonClient<PokeHistoricoModel>.GetMyApi;
            //Pokemons.Add(historicoData);

           
               
        }




    }
}
