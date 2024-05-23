using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class PersonasService
    {
        private  string connection;
        
        
        public PersonasService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int insertpersonas(PersonaModel Persona)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
               
                parametros.Add(new SqlParameter { ParameterName = "@APPaterno", SqlDbType = SqlDbType.VarChar, Value = Persona.APPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@APMaterno", SqlDbType = SqlDbType.VarChar, Value = Persona.APMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@Dirreccion", SqlDbType = SqlDbType.VarChar, Value = Persona.Dirreccion });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = Persona.Nombre });
                dac.ExecuteNonQuery("sp_insert_personas", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<PersonaModel> getPersonas ()
        {

            
            List<PersonaModel> lista = new List<PersonaModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("getPersonas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new PersonaModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            Nombre  = row["Nombre"].ToString(),
                            APPaterno = row["APPaterno"].ToString(),
                            APMaterno = row["APMaterno"].ToString(),
                            Dirreccion = row["Dirreccion"].ToString(),
                            Estatus = int.Parse(row["Estatus"].ToString()),

                        });
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

