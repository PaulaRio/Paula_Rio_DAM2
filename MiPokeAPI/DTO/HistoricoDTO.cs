namespace MiPokeAPI.DTO
{
    public class HistoricoDTO
    { 
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string PokeName { get; set; }  
        public int  DamageDoneTrainer { get; set; }
        public int DamageReceivedTrainer { get; set; }
        public int DamageDonePokemon { get; set; }
        public bool Catch { get; set; }
        public bool Shiny { get; set; }



    }
}
