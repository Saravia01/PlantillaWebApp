using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class AlumnoService
    {
        private string connection;

        public AlumnoService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<Alumno>> GetAlumnosAsync()
        {
            List<Alumno> alumnos = new List<Alumno>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetAlumnos", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    alumnos.Add(new Alumno
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                        Matricula = row["Matricula"].ToString(),
                        Direccion = row["Direccion"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumnos;
        }

        public async Task<Alumno> GetAlumnoByIdAsync(int id)
        {
            Alumno alumno = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetAlumnoById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    alumno = new Alumno
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                        Matricula = row["Matricula"].ToString(),
                        Direccion = row["Direccion"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return alumno;
        }

        public async Task AddAlumnoAsync(Alumno alumno)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = alumno.Nombre },
                    new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = alumno.ApellidoPaterno },
                    new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = alumno.ApellidoMaterno },
                    new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = alumno.Matricula },
                    new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = alumno.Direccion }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAlumnoAsync(Alumno alumno)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = alumno.Id },
                    new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = alumno.Nombre },
                    new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = alumno.ApellidoPaterno },
                    new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = alumno.ApellidoMaterno },
                    new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = alumno.Matricula },
                    new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = alumno.Direccion }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdateAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteAlumnoAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeleteAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
