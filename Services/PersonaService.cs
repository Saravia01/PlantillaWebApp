using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;
using reportesApi.Models.Compras;
using OfficeOpenXml;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
namespace reportesApi.Services
{
    public class PersonaService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public PersonaService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<PersonaModel> GetPersonas()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            PersonaModel persona = new PersonaModel();

            List<PersonaModel> lista = new List<PersonaModel>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_personas", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new PersonaModel {
                        Nombre = dataRow["Nombre"].ToString(),
                        ApPaterno = dataRow["ApPaterno"].ToString(),
                        ApMaterno = dataRow["ApMaterno"].ToString(),
                        Direccion = dataRow["Direccion"].ToString(),
                        Estatus = dataRow["Estatus"].ToString(),
                        UsuarioRegistra = dataRow["UsuarioRegistra"].ToString(),
                        FechaRegistro= dataRow["FechaRegistro"].ToString()
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public void InsertPersona(PersonaModel persona)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApPaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApMaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pDirección", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Direccion });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

            try
            {
                dac.ExecuteNonQuery("sp_insert_personas", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePersona(PersonaModel persona)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();

            parametros.Add(new SqlParameter { ParameterName = "@pNombre", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Nombre });
            parametros.Add(new SqlParameter { ParameterName = "@pApPaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApPaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pApMaterno", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.ApMaterno });
            parametros.Add(new SqlParameter { ParameterName = "@pDirección", SqlDbType = System.Data.SqlDbType.VarChar, Value = persona.Direccion });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.Int, Value = persona.Estatus == "Activo" ? 1 : 0 });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});

            try
            {
                dac.ExecuteNonQuery("sp_update_persona", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletePersona(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pIdPersona", SqlDbType = SqlDbType.Int, Value = id });

            try
            {
                dac.ExecuteNonQuery("sp_delete_persona", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}