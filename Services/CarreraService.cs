using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;
using System.IO;

namespace reportesApi.Services
{

    public class CarreraService
    {
        public string connection;

        public CarreraService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int InsertCarreras (CarreraModel carrera)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@NombreCarrera", SqlDbType = SqlDbType.VarChar, Value = carrera.NombreCarrera});
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = carrera.Clave});
                parametros.Add(new SqlParameter { ParameterName = "@Idpersona", SqlDbType = SqlDbType.Int, Value = carrera.IdPersona});
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.Int, Value = carrera.Estatus});
                parametros.Add(new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.Date, Value = carrera.FechaRegistro});
                
                dac.ExecuteNonQuery("InsertCarreras", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;            
            }

        }

        public List<CarreraModel> GetCarrera( int carrera)
        {
            List<CarreraModel> lista = new List<CarreraModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            try
            {
                DataSet ds = dac.Fill("GetCarrera");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new CarreraModel{
                            Id = int.Parse(row["Id"].ToString()),
                            NombreCarrera = row["NombreCarrera"].ToString(),
                            Clave = row["Clave"].ToString(),
                            IdPersona = int.Parse(row["IdPersona"].ToString()),
                            Estatus = int.Parse(row["Estatus"].ToString()),
                            FechaRegistro = row["FechaRegistro"].ToString(),
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

        public string UpdateCarrera (CarreraModel pcarrera)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<CarreraModel> lista = new List<CarreraModel>();

            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = pcarrera.Id});
                parametros.Add(new SqlParameter { ParameterName = "@pNombreCarrera", SqlDbType = SqlDbType.VarChar, Value = pcarrera.NombreCarrera});
                parametros.Add(new SqlParameter { ParameterName = "@pClave", SqlDbType = SqlDbType.VarChar, Value = pcarrera.Clave});
                parametros.Add(new SqlParameter { ParameterName = "@pIdPersona", SqlDbType = SqlDbType.Int, Value = pcarrera.IdPersona});
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = pcarrera.Estatus});
                parametros.Add(new SqlParameter { ParameterName = "@pFechaRegistro", SqlDbType = SqlDbType.Date, Value = pcarrera.FechaRegistro});
                
                dac.ExecuteNonQuery("UpdateCarrera", parametros);
                return "Correcto";
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public string DeleteCarrera (CarreraModel Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<CarreraModel> lista = new List<CarreraModel>();

            try 
            {
                parametros.Add(new SqlParameter {ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = Id.Id});

                dac.ExecuteNonQuery("DeleteCarrera", parametros);
                return "Correcto";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}