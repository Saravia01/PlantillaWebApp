using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
   public class ProfesorService
    {
        private string connection;

        public ProfesorService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<Profesor>> GetProfesoresAsync()
        {
            List<Profesor> profesores = new List<Profesor>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetProfesores", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    profesores.Add(new Profesor
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                        Direccion = row["Direccion"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return profesores;
        }

        public async Task<Profesor> GetProfesorByIdAsync(int id)
        {
            Profesor profesor = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetProfesorById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    profesor = new Profesor
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                        Direccion = row["Direccion"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return profesor;
        }

        public async Task AddProfesorAsync(Profesor profesor)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = profesor.Nombre },
                    new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = profesor.ApellidoPaterno },
                    new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = profesor.ApellidoMaterno },
                    new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = profesor.Direccion }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertProfesor", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateProfesorAsync(Profesor profesor)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = profesor.Id },
                    new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = profesor.Nombre },
                    new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = profesor.ApellidoPaterno },
                    new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = profesor.ApellidoMaterno },
                    new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = profesor.Direccion }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdateProfesor", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteProfesorAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeleteProfesor", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}