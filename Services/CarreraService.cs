using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class CarreraService
    {
        private  string connection;
        
        
        public CarreraService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int Insertcarreras(CarerasModel Carrera)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
               
                parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = Carrera.Usuario });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = Carrera.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = Carrera.Clave });
                dac.ExecuteNonQuery("InsertCarreras", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<CarrerasModel> getCarreras ()
        {

            
            List<CarrerasModel> lista = new List<CarrerasModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("getCarreras", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new CarrerasModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            Nombre  = row["Nombre"].ToString(),
                            Usuario = row["Usuario"].ToString(),
                            Clave = row["Clave"].ToString(),
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
        public int UpdateCarrera(CarrerasModel carreras)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@ID", SqlDbType = SqlDbType.INT, Value = carreras.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = carreras.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@clave", SqlDbType = SqlDbType.VarChar, Value = carreras.Clave });
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.Int, Value = 1 });
                 parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = carreras.Usuario });

                dac.ExecuteNonQuery("UpdateCarrera", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }
        
          public int DeleteCarrera(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = Id });
               
                dac.ExecuteNonQuery("DeleteCarrera", parametros);
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