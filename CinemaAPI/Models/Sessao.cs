namespace CinemaAPI.Models
{
    public class Sessao
    {
        public int Id { get; set; }
        public int ExibicaoId { get; set; }
        public DateTime DataHora { get; set; }

        public virtual Exibicao Exibicao { get; set; }
    }
}
