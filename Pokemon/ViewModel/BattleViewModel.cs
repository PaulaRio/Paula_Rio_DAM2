using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Pokemon.Model;
using Pokemon.Utils;

namespace Pokemon.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        private static readonly Random _random = new();
        [ObservableProperty]
        public string _CurrentPokemon;
        public override async Task LoadAsync()
        {
            PokeModel requestData = await HttpJsonClient<PokeModel>.Get(Constantes.POKE_URL) ?? new PokeModel();
            foreach (var element in requestData.Results)
            {
                _CurrentPokemon=element.Nombre;
            }
        }
    }
}
