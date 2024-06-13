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
    public class CarrerasService
    {
        private  string connection;
<<<<<<< HEAD:Services/CarrerasService.cs
        
        
        public CarrerasService(IMarcatelDatabaseSetting settings)
=======
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public CarreraService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Services/CarreraService.cs
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

<<<<<<< HEAD:Services/CarrerasService.cs
        public int InsertCarerras(CarrerasModel carreras)
=======
        public List<GetCarreraModel> GetCarreras()
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Services/CarreraService.cs
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetCarreraModel persona = new GetCarreraModel();

            List<GetCarreraModel> lista = new List<GetCarreraModel>();
            try
            {
<<<<<<< HEAD:Services/CarrerasService.cs
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = carreras.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = carreras.Clave});
                parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = carreras.Usuario });
                dac.ExecuteNonQuery("InsertCarerras", parametros);
                return 1;
=======
                parametros = new ArrayList();
                DataSet ds = dac.Fill("sp_get_carreras", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {

                  lista = ds.Tables[0].AsEnumerable()
                    .Select(dataRow => new GetCarreraModel {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        NombreCarrera = dataRow["NombreCarrera"].ToString(),
                        Abreviatura = dataRow["Abreviatura"].ToString(),
                        Estatus = dataRow["Estatus"].ToString(),
                        UsuarioRegistra = dataRow["UsuarioRegistra"].ToString(),
                        FechaRegistro= dataRow["FechaRegistro"].ToString()
                    }).ToList();
                }
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Services/CarreraService.cs
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public string InsertCarrera(InsertCarreraModel carrera)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@pNombreCarrera", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.NombreCarrera });
            parametros.Add(new SqlParameter { ParameterName = "@pAbreviatura", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.Abreviatura });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

            try
            {
<<<<<<< HEAD:Services/CarrerasService.cs
            
                DataSet ds = dac.Fill("GetCarreras", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new CarrerasModel){
                            Id  = int.Parse(row["Id"].ToString()),
                            Nombre  = row["Nombre"].ToString(),
                            Clave = row["Clave"].ToString(),
                            Usuario = row["Usuario"].ToString(),
                            Estatus = int.Parse(row["Estatus"].ToString()),
 
                DataSet ds = dac.Fill("sp_insert_carrera", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }


        public string UpdateCarrera(UpdateCarreraModel carrera)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;


            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.Id });
            parametros.Add(new SqlParameter { ParameterName = "@pNombreCarrera", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.NombreCarrera });
            parametros.Add(new SqlParameter { ParameterName = "@pAbreviatura", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.Abreviatura });
            parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.Estatus.ToLower() == "activo" ? 1 : 0});
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});

            try
            {
                DataSet ds = dac.Fill("sp_update_carreras", parametros);
                mensaje = ds.Tables[0].AsEnumerable().Select(dataRow => dataRow["mensaje"].ToString()).ToList()[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

<<<<<<< HEAD:Services/CarrerasService.cs
         public int UpdateCarreras(CarrerasModel carreras)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = 1 });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = carreras.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value =carreras.Clave });
                parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = carreras.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = 1 });
                dac.ExecuteNonQuery("UpdateCarreras", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DelateCarreras(int Id)
=======
        public void DeleteCarrera(int id)
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Services/CarreraService.cs
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});


            try
            {
<<<<<<< HEAD:Services/CarrerasService.cs
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DelateCarreras", parametros);
                return 1;
=======
                dac.ExecuteNonQuery("sp_delete_carreras", parametros);
>>>>>>> a6188d3f56bd959348c00796715e211e00072b5c:Services/CarreraService.cs
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}