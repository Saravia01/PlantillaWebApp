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
    public class CarreraService
    {
        private  string connection;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ArrayList parametros = new ArrayList();


        public CarreraService(IMarcatelDatabaseSetting settings, IWebHostEnvironment webHostEnvironment)
        {
             connection = settings.ConnectionString;

             _webHostEnvironment = webHostEnvironment;
             
        }

        public int Insertcarreras(CarrerasModel Carrera)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            GetCarrerasModel persona = new GetCarreraModel();

            List<GetCarreraModel> lista = new List<GetCarreraModel>();
            try
            {
               
                parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = Carrera.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = Carrera.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = Carrera.Clave });
                dac.ExecuteNonQuery("Insertcarreras", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        public List<CarrerasModel> getcarreras ()
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            string mensaje;

            parametros.Add(new SqlParameter { ParameterName = "@pNombreCarrera", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.NombreCarrera });
            parametros.Add(new SqlParameter { ParameterName = "@pAbreviatura", SqlDbType = System.Data.SqlDbType.VarChar, Value = carrera.Abreviatura });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1 });

            try
            {
            
                DataSet ds = dac.Fill("getcarreras", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new CarrerasModel){
                            Id  = int.Parse(row["Id"].ToString()),
                            Nombre  = row["Nombre"].ToString(),
                            Usuario = row["Usuario"].ToString(),
                            Clave = row["Clave"].ToString(),
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
        public int Updatecarrera(CarrerasModel carreras)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@ID", SqlDbType = SqlDbType.Int, Value = 1 });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = carreras.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@clave", SqlDbType = SqlDbType.VarChar, Value = carreras.Clave });
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.Int, Value = 1 });
                parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = carreras.Usuario });

                dac.ExecuteNonQuery("Updatecarrera", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }
        
          public int Deletecarrera(int Id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            parametros = new ArrayList();
            parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = id });
            parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = System.Data.SqlDbType.Int, Value = 1});


            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = Id });
               
                dac.ExecuteNonQuery("Deletecarrera", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}