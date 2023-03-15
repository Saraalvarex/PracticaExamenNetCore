using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PracticaExamenNetCore.Data;
using PracticaExamenNetCore.Models;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        #region FILTRO PERSONAJES POR SERIE Y PAGINACION
        //CREATE PROCEDURE SP_GRUPO_PERSONAJES_SERIE
        //(@POSICION INT,
        //    @IDSERIE INT,
        //    @NUMREGISTROS INT OUT)
        //AS
        //SELECT @NUMREGISTROS = COUNT(IDPERSONAJE) FROM PERSONAJES WHERE IDSERIE = @IDSERIE
        //    SELECT IDPERSONAJE, PERSONAJE, IMAGEN, IDSERIE FROM(
        //            SELECT* FROM
        //            (SELECT CAST(
        //                    ROW_NUMBER() OVER (ORDER BY PERSONAJE) AS INT) AS POSICION,
        //                    IDPERSONAJE, PERSONAJE, IMAGEN, IDSERIE
        //            FROM PERSONAJES
        //            WHERE IDSERIE = @IDSERIE) AS QUERY
        //            WHERE QUERY.POSICION>=@POSICION AND QUERY.POSICION<(@POSICION+2)) AS QUERY
        //    ORDER BY PERSONAJE
        //GO
        #endregion
        public async Task<PaginarPersonajes> GetGrupoPersonajesSerieAsync(int posicion, int idserie)
        {
            string sql = "SP_GRUPO_PERSONAJES_SERIE @POSICION, @IDSERIE, @NUMREGISTROS OUT";
            //string sql = "SP_GRUPO_EMPLEADOS_OFICIO_NUMREGISTROS @POSICION, @OFICIO, @NUMREGISTROS OUT";
            //string sql = "SP_GRUPO_EMPLEADOS_OFICIO @POSICION, @OFICIO";
            SqlParameter pamposicion = new SqlParameter("@POSICION", posicion);
            SqlParameter pamidserie = new SqlParameter("@IDSERIE", idserie);
            SqlParameter pamnumregistros = new SqlParameter("@NUMREGISTROS", -1);
            //SqlParameter pamrango = new SqlParameter("@RANGO", rango);
            pamnumregistros.Direction = ParameterDirection.Output;
            var consulta = this.context.Personajes.FromSqlRaw(sql, pamposicion, pamidserie, pamnumregistros);
            //Saco los personajes
            List<Personaje> personajes = await consulta.ToListAsync();
            //Saco el num de registros
            int numregistros = (int)pamnumregistros.Value;
            return new PaginarPersonajes
            {
                NumRegistros = numregistros,
                //Rango = rango,
                Personajes = personajes,
                Posicion = posicion
            };
            
        }
    }
}
