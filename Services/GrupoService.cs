using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class GrupoService
    {
        private string connection;

        public GrupoService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<Grupo>> GetGruposAsync()
        {
            List<Grupo> grupos = new List<Grupo>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetGrupos", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    grupos.Add(new Grupo
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Clave = row["Clave"].ToString(),
                        Nombre = row["Nombre"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return grupos;
        }

        public async Task<Grupo> GetGrupoByIdAsync(int id)
        {
            Grupo grupo = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetGrupoById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    grupo = new Grupo
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Clave = row["Clave"].ToString(),
                        Nombre = row["Nombre"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return grupo;
        }

        public async Task AddGrupoAsync(Grupo grupo)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = grupo.Clave },
                    new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = grupo.Nombre }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertGrupo", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateGrupoAsync(Grupo grupo)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = grupo.Id },
                    new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = grupo.Clave },
                    new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = grupo.Nombre }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdateGrupo", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteGrupoAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeleteGrupo", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}