﻿using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Models
{
    public class Genero
    {
        public int Id { get; set; } 
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
    }
}
