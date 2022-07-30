using Microsoft.EntityFrameworkCore;
using PeliculasAPI.Models;

namespace PeliculasAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Genero> Generos { get; set; }
    }
}
