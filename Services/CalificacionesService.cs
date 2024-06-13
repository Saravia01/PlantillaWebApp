using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class CalificacionesService
    {
        private  string connection;
        
        
        public CalificacionesService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertCalificaciones(CalificacionesModel calificaciones)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@IdMateria", SqlDbType = SqlDbType.Int, Value = calificaciones.IdMateria });
                parametros.Add(new SqlParameter { ParameterName = "@Periodo", SqlDbType = SqlDbType.VarChar, Value = calificaciones.Periodo});
                parametros.Add(new SqlParameter { ParameterName = "@Parcial", SqlDbType = SqlDbType.VarChar, Value = calificaciones.Parcial});
                parametros.Add(new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = calificaciones.Matricula });
                parametros.Add(new SqlParameter { ParameterName = "@Calificacion", SqlDbType = SqlDbType.Int, Value = calificaciones.Calificacion });
                dac.ExecuteNonQuery("InsertCalificaciones", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<CalificacionesModel> GetCalificaciones()
        {

            
            List<CalificacionesModel> lista = new List<CalificacionesModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetCalificaciones", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new CalificacionesModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            IdMateria  = int.Parse(row["IdMateria"].ToString()),
                           Matricula = row["Matricula"].ToString(),
                            Periodo = row["Periodo"].ToString(),
                            Parcial = row["Parcial"].ToString(),
                            Calificacion = int.Parse(row["Calificacion"].ToString()),
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

         public int UpdateCalificaciones(CalificacionesModel calificaciones)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = calificaciones.Id });
                parametros.Add(new SqlParameter { ParameterName = "@IdMateria", SqlDbType = SqlDbType.Int, Value = calificaciones.IdMateria });
                parametros.Add(new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = calificaciones.Matricula });
                parametros.Add(new SqlParameter { ParameterName = "@Periodo", SqlDbType = SqlDbType.VarChar, Value = calificaciones.Periodo });
                parametros.Add(new SqlParameter { ParameterName = "@Parcial", SqlDbType = SqlDbType.VarChar, Value = calificaciones.Parcial });
                parametros.Add(new SqlParameter { ParameterName = "@Calificacion", SqlDbType = SqlDbType.Int, Value = calificaciones.Calificacion });
                dac.ExecuteNonQuery("UpdateCalificaciones", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DeleteCalificaciones(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DeleteCalificaciones", parametros);
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
