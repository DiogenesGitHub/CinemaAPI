namespace CinemaAPI.DTOs
{
    public class ExibicaoDTO
    {
        public int Id { get; set; } 
        public int? FilmeId { get; set; } 
        public int? SalaId { get; set; } 
        public DateTime DataExibicao { get; set; } 
    }
}
