using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace reportesApi.Services
{

    public class PersonaService
    {
       public  string connection;

        public PersonaService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertPersonas (PersonaModel personas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<PersonaModel> lista = new List<PersonaModel>();

            try 
            {
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = personas.Nombre});
                parametros.Add(new SqlParameter { ParameterName = "@ApPaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@ApMaterno", SqlDbType = SqlDbType.VarChar, Value = personas.ApMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = personas.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.Int, Value = personas.Estatus });
                
                dac.ExecuteNonQuery("InsertPersonas", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0; 
            }

        }

        public List<PersonaModel> GetPersona(int persona)
        {
            List<PersonaModel> lista = new List<PersonaModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            try
            {
                DataSet ds = dac.Fill("GetPersona");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new PersonaModel{
                            Id = int.Parse(row["Id"].ToString()),
                            Nombre = row["Nombre"].ToString(),
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

        public string UpdatePersona (PersonaModel ppersonas)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<PersonaModel> lista = new List<PersonaModel>();

            try 
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = ppersonas.Id});
                parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = SqlDbType.VarChar, Value = ppersonas.Nombre});
                parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = SqlDbType.VarChar, Value = ppersonas.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = SqlDbType.VarChar, Value = ppersonas.ApMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@pDireccion", SqlDbType = SqlDbType.VarChar, Value = ppersonas.Direccion });
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = ppersonas.Estatus });
                
                dac.ExecuteNonQuery("UpdatePersona", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string DeletePersonas (PersonaModel Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<CarreraModel> lista = new List<CarreraModel>();

            try 
            {
                parametros.Add(new SqlParameter {ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = Id.Id});

                dac.ExecuteNonQuery("DeletePersonas", parametros);
                return "Correcto";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
