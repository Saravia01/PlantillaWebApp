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

        public int InsertCarreras(CarrerasModel carreras)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@nombreCarrera", SqlDbType = SqlDbType.VarChar, Value = carreras.nombreCarrera });
                parametros.Add(new SqlParameter { ParameterName = "@clave", SqlDbType = SqlDbType.VarChar, Value = carreras.clave });
                parametros.Add(new SqlParameter { ParameterName = "@id_persona", SqlDbType = SqlDbType.Int, Value = carreras.id_persona});
                parametros.Add(new SqlParameter { ParameterName = "@estatus", SqlDbType = SqlDbType.Int, Value = carreras.estatus});
                dac.ExecuteNonQuery("insertCarreras", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }
        public List<CarrerasModel> getCarreras()
        {
            
            List<CarrerasModel> lista = new List<CarrerasModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
                DataSet ds = dac.Fill("getCarreras");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new CarrerasModel{
                            nombreCarrera  = row["nombreCarrera"].ToString(),
                            clave = row["clave"].ToString(),
                            id_persona  = int.Parse(row["id_persona"].ToString()),
                            estatus  = int.Parse(row["estatus"].ToString()),
                            fecha = row["fechaRegistro"].ToString(),
                            
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