using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class GrupoAlumnoService
    {
        private string connection;

        public GrupoAlumnoService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<GrupoAlumno>> GetGrupoAlumnosAsync()
        {
            List<GrupoAlumno> grupoAlumnos = new List<GrupoAlumno>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetGrupoAlumnos", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    grupoAlumnos.Add(new GrupoAlumno
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        IdGrupo = int.Parse(row["IdGrupo"].ToString()),
                        Matricula = row["Matricula"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return grupoAlumnos;
        }

        public async Task<GrupoAlumno> GetGrupoAlumnoByIdAsync(int id)
        {
            GrupoAlumno grupoAlumno = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetGrupoAlumnoById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    grupoAlumno = new GrupoAlumno
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        IdGrupo = int.Parse(row["IdGrupo"].ToString()),
                        Matricula = row["Matricula"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return grupoAlumno;
        }

        public async Task AddGrupoAlumnoAsync(GrupoAlumno grupoAlumno)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@IdGrupo", SqlDbType = SqlDbType.Int, Value = grupoAlumno.IdGrupo },
                    new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = grupoAlumno.Matricula }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertGrupoAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateGrupoAlumnoAsync(GrupoAlumno grupoAlumno)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = grupoAlumno.Id },
                    new SqlParameter { ParameterName = "@IdGrupo", SqlDbType = SqlDbType.Int, Value = grupoAlumno.IdGrupo },
                    new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = grupoAlumno.Matricula }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdateGrupoAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteGrupoAlumnoAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeleteGrupoAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}