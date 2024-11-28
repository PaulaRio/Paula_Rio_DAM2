using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokemon.Model;
using Pokemon.Models;
using Pokemon.Utils;

namespace Pokemon.ViewModel
{
    public class TeamViewModel : ViewModelBase
    {
        public ObservableCollection<StackPanelItemModel> Items { get; set; }
        private async Task GenerateStackPanelItems(PokeModel pokemonsByType, int indexStartShowPokemon,
            List<Task<PokemonSpriteModel>> peticionesSprite, int numPokemonsGrid)
        {
            int contador = 0;
            PokemonSpriteModel sprite;
           
                sprite = await peticionesSprite[contador];
                contador++;
                Items.Add(new StackPanelItemModel
                {
                    ImagePath = sprite.sprites.front_default ?? Constantes.MISSINGNO_IMAGE_PATH,
                    //PokemonName = pokemonsByType.pokemon[i].pokemon.name
                });
            
        }
    }
}
