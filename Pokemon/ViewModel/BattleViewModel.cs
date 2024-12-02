using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Pokemon.Model;
using Pokemon.Models;
using Pokemon.Utils;

namespace Pokemon.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        private static readonly Random _random = new();

        [ObservableProperty]
        public string _CurrentPokemonPath;

        public ObservableCollection<string> AllPokemons { get; } = new();

        //[ObservableProperty]
        //public StackPanelItemModel _Item;

        
        

        public BattleViewModel()
        {

           // _Item = new StackPanelItemModel();
            _CurrentPokemonPath=null;

        }

        public override async Task LoadAsync()
        {
            PokeModel requestData = await HttpJsonClient<PokeModel>.Get(Constantes.POKE_URL) ?? new PokeModel();
            foreach (var element in requestData.Results)
            {
                AllPokemons.Add(element.Nombre);
            }

            //_CurrentPokemon= requestData.Results[randomId].Nombre;
            await GenerateCurrentPokemon();


        }
        private async Task GenerateCurrentPokemon()
        {
            //Porfi Pau del futuro, requerda hacer un Utils de esto
            int randomId = new Random().Next(1, 20);
            string pokeAleatorio = AllPokemons[randomId];
            
            PokemonSpriteModel peticionSprite; 
            peticionSprite = await HttpJsonClient<PokemonSpriteModel>.Get($"{Constantes.POKE_URL}/{pokeAleatorio}");
            //Item.ImagePath = peticionSprite.sprites.front_default ?? Constantes.MISSINGNO_IMAGE_PATH;
            _CurrentPokemonPath= peticionSprite.sprites.front_default ?? Constantes.MISSINGNO_IMAGE_PATH;
        




        }
    }
}
