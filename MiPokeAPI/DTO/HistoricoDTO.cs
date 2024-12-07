namespace MiPokeAPI.DTO
{
    public class HistoricoDTO
    { 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string PokeName { get; set; }  
        public int  DamageDoneTrainer { get; set; }
        public int DamageReceivedTrainer { get; set; }
        public int DamageDonePokemon { get; set; }
        public bool Catch { get; set; }



    }
}
