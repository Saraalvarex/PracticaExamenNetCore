using Microsoft.EntityFrameworkCore;
using PracticaExamenNetCore.Models;

namespace PracticaExamenNetCore.Data
{
    public class SerieContext: DbContext
    {
        public SerieContext(DbContextOptions<SerieContext> options) : base(options) { }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
    }
}
