using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class ProfesoresService
    {
        private  string connection;
        
        
        public ProfesoresService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertProfesores(ProfesoresModel profesores)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = profesores.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@ApPaterno", SqlDbType = SqlDbType.VarChar, Value = profesores.ApPaterno});
                parametros.Add(new SqlParameter { ParameterName = "@ApMaterno", SqlDbType = SqlDbType.VarChar, Value = profesores.ApMaterno});
                parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = profesores.Direccion });
                dac.ExecuteNonQuery("InsertProfesores", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<ProfesoresModel> GetProfesores()
        {

            
            List<ProfesoresModel> lista = new List<ProfesoresModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetProfesores", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new ProfesoresModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            Nombre  = row["Nombre"].ToString(),
                            ApPaterno = row["ApPaterno"].ToString(),
                            ApMaterno = row["ApMaterno"].ToString(),
                            Direccion = row["Direccion"].ToString(),
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

         public int UpdateProfesores(ProfesoresModel profesor)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = profesor.Id });
                parametros.Add(new SqlParameter { ParameterName = "@Nombre", SqlDbType = SqlDbType.VarChar, Value = profesor.Nombre });
                parametros.Add(new SqlParameter { ParameterName = "@ApPaterno", SqlDbType = SqlDbType.VarChar, Value = profesor.ApPaterno });
                parametros.Add(new SqlParameter { ParameterName = "@ApMaterno", SqlDbType = SqlDbType.VarChar, Value = profesor.ApMaterno });
                parametros.Add(new SqlParameter { ParameterName = "@Direccion", SqlDbType = SqlDbType.VarChar, Value = profesor.Direccion});
                dac.ExecuteNonQuery("UpdateProfesores", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DeleteProfesores(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DeleteProfesores", parametros);
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
