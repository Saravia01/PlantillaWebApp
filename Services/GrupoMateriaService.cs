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
    public class GrupoMateria
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public GrupoMateria(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public List<GetGrupoMateria> GetGrupoMateria()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetGrupoMateria persona = new GetGrupoMateria();

            List<GetGrupoMateria> lista = new List<GetGrupoMateria>();
            try
            {
                parametros = new ArrayList();
                DataSet ds = dac.Fill("GetGrupoMateria", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetGrupoMateria {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        IdGrupo = int.Parse(dataRow["IdGrupo"].ToString()),
                        IdMateria = int.Parse(dataRow["IdMateria"].ToString()),
                        Estatus = dataRow["Estatus"].ToString(),
                        Fecha = dataRow["Fecha"].ToString(),
                        Usuario = dataRow["Usuario"].ToString(),
                       
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public string InsertGrupoMateria(InsertGrupoMateria GrupoMateria)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@IdGrupo", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.IdGrupo });
            parametros.Add(new SqlParameter { ParameterName = "@IdMateria", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.IdMateria});
            parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.Estatus});
            parametros.Add(new SqlParameter { ParameterName = "@Fecha", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.Fecha});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.Usuario});

            try
            {
                DataSet ds = dac.Fill("InsertGrupoMateria", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

        public string UpdateGrupoMateria(UpdateGrupoMateria GrupoMateria)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.Id });
            parametros.Add(new SqlParameter { ParameterName = "@IdGrupo", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.IdGrupo });
            parametros.Add(new SqlParameter { ParameterName = "@IdMateria", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.IdMateria});
            parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.Estatus});
            parametros.Add(new SqlParameter { ParameterName = "@Fecha", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.Fecha});
            parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = System.Data.SqlDbType.VarChar, Value = GrupoMateria.Usuario});
          
            try
            {
                DataSet ds = dac.Fill("UpdateGrupoMateria", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

    }
}