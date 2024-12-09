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
        public List<string> NamePokeTeam = new List<string>();
        public override async Task LoadAsync()
        {
            await GenerateStackPanelItems();
           
        }
        private async Task GenerateStackPanelItems()
        {
            int contador = 0;
            PokemonSpriteModel sprite;
            List<PokeHistoricoModel> requestMyAPIData = await HttpJsonClient<PokeHistoricoModel>.GetListMyApi(Constantes.HISTORICO_PATH) ?? new List<PokeHistoricoModel>();
            
            PokeModel requestData = await HttpJsonClient<PokeModel>.GetPokeApi(Constantes.ALLPOKE_URL) ?? new PokeModel();
            foreach (var item in requestMyAPIData)
            {
                if (item.@catch && !NamePokeTeam.Contains(item.pokeName))
                {
                    NamePokeTeam.Add(item.pokeName);

                }
                else
                {

                }
            }
            Items.Add(new StackPanelItemModel
                {
                    //ImagePath = sprite.sprites.front_default ?? Constantes.MISSINGNO_IMAGE_PATH,
                    //PokemonName = pokemonsByType.pokemon[i].pokemon.name
                });
            
        }
    }
}
