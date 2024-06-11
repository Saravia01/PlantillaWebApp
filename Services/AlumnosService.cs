using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class AlumnosService
    {
        private  string connection;
        
        
        public AlumnosService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertAlumnos(AlumnosModel Alumnos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
               
                parametros.Add(new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = Alumnos.ApellidoPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = Alumnos.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = Alumnos.Matricula });
                parametros.Add(new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = Alumnos.ApellidoMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@Dirreccion", SqlDbType = SqlDbType.VarChar, Value = Alumnos.Dirreccion });
                dac.ExecuteNonQuery("InsertAlumnos", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<AlumnosModel> GetAlumnos ()
        {

            
            List<AlumnosModel> lista = new List<AlumnosModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetAlumnos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new AlumnosModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            Nombre  = row["Nombre"].ToString(),
                            ApellidoPaterno = row["ApellidoPaterno"].ToString(),
                            ApellidoMaterno = row["ApellidoMaterno"].ToString(),
                            Matricula = row["Matricula"].ToString(),
                            Dirreccion = row["Dirreccion"].ToString(),

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
        public int UpdateAlumnos(AlumnosModel Alumnos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = 1 });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = Alumnos.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@ApellidoPaterno", SqlDbType = SqlDbType.VarChar, Value = Alumnos.ApellidoPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@ApellidoMaterno", SqlDbType = SqlDbType.VarChar, Value = Alumnos.ApellidoMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = Alumnos.Matricula });
                parametros.Add(new SqlParameter { ParameterName = "@Dirreccion", SqlDbType = SqlDbType.VarChar, Value = Alumnos.Dirreccion });


                dac.ExecuteNonQuery("UpdateAlumnos", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }
        
          public int DeleteAlumnos(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = Id });
               
                dac.ExecuteNonQuery("DeleteAlumnos", parametros);
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