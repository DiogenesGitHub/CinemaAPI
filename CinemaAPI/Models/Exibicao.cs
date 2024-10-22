namespace CinemaAPI.Models
{
    public class Exibicao
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public int SalaId { get; set; }
        public DateTime DataExibicao { get; set; }

        public virtual Filme Filme { get; set; }
        public virtual Sala Sala { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }
    }
}
