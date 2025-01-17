﻿namespace CinemaAPI.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int AnoLancamento { get; set; }

        public virtual ICollection<Exibicao> Exibicoes { get; set; }
    }
}
