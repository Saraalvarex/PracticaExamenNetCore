using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaExamenNetCore.Models
{
    [Table("PERSONAJES")]
    public class Personaje
    {
        [Key]
        [Column("IDPERSONAJE")]
        public int IdPersonaje { get; set; }
        [Column("PERSONAJE")]
        public string NombrePersonaje { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("IDSERIE")]
        public int IdSerie { get; set; }
    }
}
