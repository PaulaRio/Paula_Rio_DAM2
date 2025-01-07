using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokemon.Model
{
    public class PokeHistoricoModel
    {
        public int id { get; set; }

        public DateTime dateStart { get; set; }
        
        public DateTime dateEnd { get; set; }
       
        public string pokeName { get; set; }
       
        public int damageDoneTrainer { get; set; }
        
        public int damageReceivedTrainer { get; set; }
        
        public int damageDonePokemon { get; set; }

        public bool @catch { get; set; }
        
        public bool shiny { get; set; }

    }
}
