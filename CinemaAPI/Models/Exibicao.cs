namespace CinemaAPI.Models
{
    public class Exibicao
    {
        public int Id { get; set; } 
        public int? FilmeId { get; set; } 
        public int? SalaId { get; set; } 
        public DateTime DataExibicao { get; set; } 
    }
}
