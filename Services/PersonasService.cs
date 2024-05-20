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

        public int InsertPersonas(PersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = personas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@ApPaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@ApMaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApMaterno });
                 parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = personas.Direccion });
                dac.ExecuteNonQuery("InsertPersonas", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<PersonasModel> GetPersonas ()
        {

            
            List<PersonasModel> lista = new List<PersonasModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetPersonas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new PersonasModel{
                            ID  = int.Parse(row["ID"].ToString()),
                            Nombre  = row["Nombre"].ToString(),
                            ApPaterno = row["ApPaterno"].ToString(),
                            ApMaterno = row["ApMaterno"].ToString(),
                            Direccion = row["Direccion"].ToString(),
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
          public int UpdatePersonas(PersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = personas.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@ApPaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@ApMaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApMaterno });
                 parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = personas.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = personas.Estatus });

                dac.ExecuteNonQuery("UpdatePersonas", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }
        
          public int DeletePersonas(PersonasModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@ID", SqlDbType = SqlDbType.VarChar, Value = personas.ID });
               
                dac.ExecuteNonQuery("DeletePersonas", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }
    }
}