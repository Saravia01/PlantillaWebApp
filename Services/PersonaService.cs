using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class PersonaService
    {
        private  string connection;
        
        
        public PersonaService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public UsuarioModel InsertPersona(PersonaModel Persona)
        {
            
            UsuarioModel usuario = new UsuarioModel();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = Persona.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@pApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = Persona.ApellidoPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = Persona.ApellidoMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = Persona.Direccion });
                DataSet ds = dac.Fill("insert_personas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Persona.Nombre = row["Nombre"].ToString();
                        Persona.ApellidoPaterno = row["ApellidoPaterno"].ToString();
                        Persona.ApellidoMaterno = (row["ApellidoMaterno"].ToString());
                        Persona.Direccion = row["Direccion"].ToString();
                        Persona.Id = int.Parse(row["Id"].ToString());
                    
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
