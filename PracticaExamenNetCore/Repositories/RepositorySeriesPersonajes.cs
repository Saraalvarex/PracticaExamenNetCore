using Microsoft.AspNetCore.Mvc;
using PracticaExamenNetCore.Data;
using PracticaExamenNetCore.Models;

namespace PracticaExamenNetCore.Repositories
{
    public class RepositorySeriesPersonajes
    {
        private SerieContext context;
        public RepositorySeriesPersonajes(SerieContext context)
        {
            this.context= context;
        }

        public List<Serie> GetSeries()
        {
            return this.context.Series.ToList();
        }
        public List<Personaje> FindPersonajes(int idserie)
        {
            var query = from datos in this.context.Personajes
                        where datos.IdSerie==idserie
                        select datos;
            return query.ToList();
        }

    }
}
