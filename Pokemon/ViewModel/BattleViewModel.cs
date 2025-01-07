using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        //TODO: espablecer id en base a los count de la base de datos.
        private int _contadorId;

        private int _currentPokemonId;

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
            _OurChangingHP =100;
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

            if (string.IsNullOrEmpty(CurrentPokemonPath))
            {
                await GenerateCurrentPokemon();

            }

            
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
            if (OurChangingHP <=0)
            {
                MessageBox.Show("Game Over");
                Application.Current.Shutdown();
            }


        }

        [RelayCommand]
        private async Task Capture_Click(object? parameter)
        {
            if (_pokeService.CaptureSuccess(ChangingPokeHP))
            {   MessageBox.Show("Pokemon capturado");
                _Catch = true;
                _DateEnd = DateTime.Now;
                if (_Shiny)
                {
                    OurChangingHP = 100;
                    _DamageDonePokemon = 0;
                }
                else
                {
                    OurChangingHP += 5;
                    _DamageDonePokemon = _DamageReceivedTrainer - 5;
                }
               
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
                 await GuardarHistoricoActualAsync(_PokeName);
                
            }

            _currentPokemonId = _contadorId;
            _contadorId++;

            int randomId = new Random().Next(1, AllPokemons.Count);
            _PokeName = AllPokemons[randomId];
            
            PokemonSpriteModel peticionSprite = await HttpJsonClient<PokemonSpriteModel>.GetPokeApi($"{Constantes.POKE_URL}/{_PokeName}");
            _Shiny = _pokeService.IsShiny();

            CurrentPokemonPath = _Shiny ? peticionSprite.sprites.front_shiny ?? Constantes.MISSINGNO_IMAGE_PATH: 
                peticionSprite.sprites.front_default ?? Constantes.MISSINGNO_IMAGE_PATH;
            ColorIsShiny = _Shiny ? Constantes.COLOR_SHINY: Constantes.COLOR_NORMAL; 
            


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
                    dateStart = _DateStart,
                    dateEnd = _DateEnd,
                    pokeName = name,
                    damageDoneTrainer = _SumDamageDoneTrainer,
                    damageReceivedTrainer = _DamageReceivedTrainer,
                    damageDonePokemon = _DamageDonePokemon,
                    @catch = _Catch,
                    shiny = _Shiny
                };

                
                var resultado = await HttpJsonClient<PokeHistoricoModel>.Post(Constantes.HISTORICO_PATH, historico);
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
