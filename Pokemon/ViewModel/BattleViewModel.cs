using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Pokemon.Interfaces;
using Pokemon.Model;
using Pokemon.Models;
using Pokemon.Utils;

namespace Pokemon.ViewModel
{
    public partial class BattleViewModel : ViewModelBase
    {
        private static readonly Random _random = new();

        private IPokeOpsProvider _pokeService;
        private readonly IHistoricoProvider _historicoApiService;
        [ObservableProperty]
        public string _CurrentPokemonPath;

        [ObservableProperty]
        public int _CurrentPokemonHP;

        [ObservableProperty]
        public int _CurrentPokemonAttack;

        [ObservableProperty]
        public int _ChangingPokeHP;

        public int ActualPokeHP;

        [ObservableProperty]
        public int _OurChangingHP;

        [ObservableProperty]
        public string _ColorIsShiny;


        public ObservableCollection<string> AllPokemons { get; } = new();
       

        //[ObservableProperty]
        //public StackPanelItemModel _Item;




        public BattleViewModel(IPokeOpsProvider pokeService,IHistoricoProvider historicoApiService)
        {

           // _Item = new StackPanelItemModel();
            _CurrentPokemonPath=null;
            _CurrentPokemonHP= 0;
            _CurrentPokemonAttack = 0;
            _OurChangingHP=100;
            _ColorIsShiny = "Red";
            _pokeService = pokeService;
            _historicoApiService = historicoApiService;

        }

        public override async Task LoadAsync()
        {
            PokeModel requestData = await HttpJsonClient<PokeModel>.GetPokeApi(Constantes.ALLPOKE_URL) ?? new PokeModel();
            foreach (var element in requestData.Results)
            {
                AllPokemons.Add(element.Nombre);
            }

            //_CurrentPokemon= requestData.Results[randomId].Nombre;
            await GenerateCurrentPokemon();


        }

        [RelayCommand]
        private async Task Escape_Click(object? parameter)
        {
            await GenerateCurrentPokemon();
        }

        [RelayCommand]
        private async Task Atack_Click(object? parameter)
        {
            ActualPokeHP = ActualPokeHP - _pokeService.NumAtack();
            ChangingPokeHP = (100/CurrentPokemonHP) * ActualPokeHP;
            Console.WriteLine(ChangingPokeHP);
            if (ActualPokeHP <= 0) 
            {
                await GenerateCurrentPokemon();
            }
            else
            {
                OurChangingHP = OurChangingHP - (CurrentPokemonAttack/10);

            }



        }

        [RelayCommand]
        private async Task Capture_Click(object? parameter)
        {
            await GenerateCurrentPokemon();
        }

        private async Task GenerateCurrentPokemon()
        {
            // TODO: Porfi Pau del futuro, requerda hacer un Utils de esto
            int randomId = new Random().Next(1, 101);
            string pokeAleatorio = AllPokemons[randomId];
            
            PokemonSpriteModel peticionSprite; 
            peticionSprite = await HttpJsonClient<PokemonSpriteModel>.GetPokeApi($"{Constantes.POKE_URL}/{pokeAleatorio}");
            //Item.ImagePath = peticionSprite.sprites.front_default ?? Constantes.MISSINGNO_IMAGE_PATH;
            if (_pokeService.IsShiny())
            {
                CurrentPokemonPath = peticionSprite.sprites.front_shiny ?? Constantes.MISSINGNO_IMAGE_PATH;
                ColorIsShiny = "Gold";
            }
            else
            { 
            CurrentPokemonPath = peticionSprite.sprites.front_default ?? Constantes.MISSINGNO_IMAGE_PATH;
                ColorIsShiny = "Red";
            }


            CurrentPokemonHP = peticionSprite.stats[0].base_stat ;
            ActualPokeHP = CurrentPokemonHP;
            ChangingPokeHP = 100;

            CurrentPokemonAttack = peticionSprite.stats[1].base_stat;

        }
    }
}
