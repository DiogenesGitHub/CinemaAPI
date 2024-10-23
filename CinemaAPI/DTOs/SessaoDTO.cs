namespace CinemaAPI.DTOs
{
    public class SessaoDTO
    {
        public int Id { get; set; } 
        public int FilmeId { get; set; } 
        public DateTime DataHora { get; set; } 
        public string Sala { get; set; } 
        public int Duracao { get; set; } 
    }
}
