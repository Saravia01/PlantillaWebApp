using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class CalificacionService
    {
        private string connection;

        public CalificacionService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<Calificacion>> GetCalificacionesAsync()
        {
            List<Calificacion> calificaciones = new List<Calificacion>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetCalificaciones", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    calificaciones.Add(new Calificacion
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        IdMateria = int.Parse(row["IdMateria"].ToString()),
                        Matricula = row["Matricula"].ToString(),
                        Periodo = row["Periodo"].ToString(),
                        Parcial = row["Parcial"].ToString(),
                        Calificacion = decimal.Parse(row["Calificacion"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return calificaciones;
        }

        public async Task<Calificacion> GetCalificacionByIdAsync(int id)
        {
            Calificacion calificacion = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetCalificacionById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    calificacion = new Calificacion
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        IdMateria = int.Parse(row["IdMateria"].ToString()),
                        Matricula = row["Matricula"].ToString(),
                        Periodo = row["Periodo"].ToString(),
                        Parcial = row["Parcial"].ToString(),
                        Calificacion = decimal.Parse(row["Calificacion"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return calificacion;
        }

        public async Task AddCalificacionAsync(Calificacion calificacion)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@IdMateria", SqlDbType = SqlDbType.Int, Value = calificacion.IdMateria },
                    new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = calificacion.Matricula },
                    new SqlParameter { ParameterName = "@Periodo", SqlDbType = SqlDbType.VarChar, Value = calificacion.Periodo },
                    new SqlParameter { ParameterName = "@Parcial", SqlDbType = SqlDbType.VarChar, Value = calificacion.Parcial },
                    new SqlParameter { ParameterName = "@Calificacion", SqlDbType = SqlDbType.Decimal, Value = calificacion.Calificacion }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertCalificacion", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateCalificacionAsync(Calificacion calificacion)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = calificacion.Id },
                    new SqlParameter { ParameterName = "@IdMateria", SqlDbType = SqlDbType.Int, Value = calificacion.IdMateria },
                    new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = calificacion.Matricula },
                    new SqlParameter { ParameterName = "@Periodo", SqlDbType = SqlDbType.VarChar, Value = calificacion.Periodo },
                    new SqlParameter { ParameterName = "@Parcial", SqlDbType = SqlDbType.VarChar, Value = calificacion.Parcial },
                    new SqlParameter { ParameterName = "@Calificacion", SqlDbType = SqlDbType.Decimal, Value = calificacion.Calificacion }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdateCalificacion", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteCalificacionAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeleteCalificacion", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
