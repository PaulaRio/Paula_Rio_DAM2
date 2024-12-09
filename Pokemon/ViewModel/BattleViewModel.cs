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
       // private readonly IHistoricoProvider _historicoApiService;
        [ObservableProperty]
        public string _CurrentPokemonPath;

        [ObservableProperty]
        public int _CurrentPokemonHP;

        [ObservableProperty]
        public int _CurrentPokemonAttack;

        [ObservableProperty]
        public int _ChangingPokeHP;

        public int ActualPokeHP;

        private DateTime _DateStart;

        private DateTime _DateEnd;

        private string _PokeName;

        private int _DamageDoneTrainer;

        private int _SumDamageDoneTrainer;

        private int _DamageReceivedTrainer;

        private int _DamageDonePokemon;

        private bool _Catch;

        private bool _Shiny;

        [ObservableProperty]
        public int _OurChangingHP;

        [ObservableProperty]
        public string _ColorIsShiny;


        public ObservableCollection<string> AllPokemons { get; } = new();

        //IHistoricoProvider historicoApiService
        public BattleViewModel(IPokeOpsProvider pokeService)
        {

          
            _CurrentPokemonPath=null;
            _CurrentPokemonHP= 0;
            _CurrentPokemonAttack = 0;
            _OurChangingHP=100;
            _ColorIsShiny = "Red";
            _pokeService = pokeService;
            //_historicoApiService = historicoApiService;
            
        }

        public override async Task LoadAsync()
        {
            PokeModel requestData = await HttpJsonClient<PokeModel>.GetPokeApi(Constantes.ALLPOKE_URL) ?? new PokeModel();
            foreach (var element in requestData.Results)
            {
                AllPokemons.Add(element.Nombre);
            }

            
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
            int damage = _pokeService.NumAtack();
            _SumDamageDoneTrainer += damage;
            ActualPokeHP = ActualPokeHP - damage;

            ChangingPokeHP = (100/CurrentPokemonHP) * ActualPokeHP;
            Console.WriteLine(ChangingPokeHP);
            if (ActualPokeHP <= 0) 
            {
                _DateEnd = DateTime.Now;
                
                await GenerateCurrentPokemon();
            }
            else
            {
                OurChangingHP = OurChangingHP - (CurrentPokemonAttack/10);
                _DamageReceivedTrainer += CurrentPokemonAttack;
            }



        }

        [RelayCommand]
        private async Task Capture_Click(object? parameter)
        {
            if (_pokeService.CaptureSuccess(ChangingPokeHP))
            {
                _DamageDonePokemon = OurChangingHP;
                _Catch = true;
                _DateEnd = DateTime.Now;
                if (_Shiny)
                {
                    OurChangingHP = 100;
                }
                else
                {
                    OurChangingHP = OurChangingHP + 5;
                }
                _DamageDonePokemon = _DamageDonePokemon - OurChangingHP;
                await GenerateCurrentPokemon();
            }
            else
            {
                _DateEnd = DateTime.Now;
                await GenerateCurrentPokemon();
            }
            
        }

        private async Task GenerateCurrentPokemon()
        {
            if (!string.IsNullOrEmpty(CurrentPokemonPath))
            {
                bool guardadoExitoso = await GuardarHistoricoActualAsync(_PokeName);
                
            }
            // TODO: Porfi Pau del futuro, requerda hacer un Utils de esto
            int randomId = new Random().Next(1, AllPokemons.Count);
            _PokeName = AllPokemons[randomId];
            
            PokemonSpriteModel peticionSprite; 
            peticionSprite = await HttpJsonClient<PokemonSpriteModel>.GetPokeApi($"{Constantes.POKE_URL}/{_PokeName}");
            _Shiny = _pokeService.IsShiny();
            if (_Shiny)
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


            _SumDamageDoneTrainer = 0;
            _DamageDonePokemon = 0;
            _DamageReceivedTrainer = 0;
            _Catch = false;

            _DateStart = DateTime.Now;
        }
        private async Task<bool> GuardarHistoricoActualAsync(string name)
        {
            try
            {

                PokeHistoricoModel historico = new PokeHistoricoModel
                {
                    DateStart = _DateStart,
                    DateEnd = _DateEnd,
                    PokeName = name,
                    DamageDoneTrainer = _SumDamageDoneTrainer,
                    DamageReceivedTrainer = _DamageReceivedTrainer,
                    DamageDonePokemon = _DamageDonePokemon,
                    Catch = _Catch,
                    Shiny = _Shiny
                };

                
                var resultado = await HttpJsonClient<PokeHistoricoModel>.Post("pokeHistorico", historico);
                return resultado != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el histórico: {ex.Message}");
                return false;
            }
        }


    }
}
