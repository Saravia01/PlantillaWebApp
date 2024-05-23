using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class CarrerasService
    {
        private  string connection;
        
        
        public CarrerasService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertCarrerasABM(CarrerasModel carreras)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = carreras.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = carreras.Clave});
                parametros.Add(new SqlParameter { ParameterName = "@Usuario", SqlDbType = SqlDbType.VarChar, Value = carreras.Usuario });
                dac.ExecuteNonQuery("InsertCarrerasABM", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<CarrerasModel> GetCarrerasABM()
        {

            
            List<CarrerasModel> lista = new List<CarrerasModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetCarreras", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new CarrerasModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            Nombre  = row["Nombre"].ToString(),
                            Clave = row["Clave"].ToString(),
                            Usuario = row["Usuario"].ToString(),
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

         public int UpdateCarrerasABM(CarrerasModel carreras)
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
                dac.ExecuteNonQuery("UpdateCarrerasABM", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DelateCarrerasABM(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DelateCarrerasABM", parametros);
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