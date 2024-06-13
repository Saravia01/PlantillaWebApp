using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class PersonaService
    {
        private string connection;

        public PersonaService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<Persona>> GetPersonasAsync()
        {
            List<Persona> personas = new List<Persona>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetPersonas", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    personas.Add(new Persona
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        Estatus = row["Estatus"].ToString(),
                        UsuarioRegistra = row["UsuarioRegistra"].ToString(),
                        FechaRegistro = DateTime.Parse(row["FechaRegistro"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return personas;
        }

        public async Task<Persona> GetPersonaByIdAsync(int id)
        {
            Persona persona = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetPersonaById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    persona = new Persona
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Nombre = row["Nombre"].ToString(),
                        ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                        ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                        Direccion = row["Direccion"].ToString(),
                        Estatus = row["Estatus"].ToString(),
                        UsuarioRegistra = row["UsuarioRegistra"].ToString(),
                        FechaRegistro = DateTime.Parse(row["FechaRegistro"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return persona;
        }

        public async Task AddPersonaAsync(Persona persona)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = persona.Nombre },
                    new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = persona.ApellidoPaterno },
                    new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = persona.ApellidoMaterno },
                    new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = persona.Direccion },
                    new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = persona.Estatus },
                    new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = persona.UsuarioRegistra },
                    new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.DateTime, Value = persona.FechaRegistro }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertPersona", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdatePersonaAsync(Persona persona)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = persona.Id },
                    new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = persona.Nombre },
                    new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = persona.ApellidoPaterno },
                    new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = persona.ApellidoMaterno },
                    new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = persona.Direccion },
                    new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = persona.Estatus },
                    new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = persona.UsuarioRegistra },
                    new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.DateTime, Value = persona.FechaRegistro }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdatePersona", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletePersonaAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeletePersona", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
