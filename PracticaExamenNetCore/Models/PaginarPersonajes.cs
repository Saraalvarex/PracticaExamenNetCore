namespace PracticaExamenNetCore.Models
{
    public class PaginarPersonajes
    {
        public int NumRegistros { get; set; }
        public int Rango { get; set; }
        public List<Personaje> Personajes { get; set; }
        //Tambien podria guardar la posicion
        public int Posicion { get; set; }
    }
}
