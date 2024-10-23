﻿namespace CinemaAPI.DTOs
{
    public class FilmeDTO
    {
        public int Id { get; set; } 
        public string Titulo { get; set; } 
        public string Genero { get; set; } 
        public int? Duracao { get; set; } 
        public int? AnoLancamento { get; set; } 
    }
}
