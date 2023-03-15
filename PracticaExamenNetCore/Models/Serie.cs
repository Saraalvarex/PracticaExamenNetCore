using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaExamenNetCore.Models
{
    [Table("SERIES")]
    public class Serie
    {
        [Key]
        [Column("IDSERIE")]
        public int IdSerie { get; set; }
        [Column("SERIE")]
        public string NombreSerie { get; set; }
        [Column("IMAGEN")]
        public string Imagen { get; set; }
        [Column("PUNTUACION")]
        public double Puntuacion { get; set; }
        [Column("AÑO")]
        public int Anio { get; set; }
    }
}
