namespace CinemaAPI.Models
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }

        public virtual ICollection<Exibicao> Exibicoes { get; set; }
    }
}
