using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class GruposService
    {
        private  string connection;
        
        
        public GruposService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertGrupos(GruposModel grupos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.VarChar, Value = grupos.Clave });
                parametros.Add(new SqlParameter { ParameterName = "@NombreGrupo", SqlDbType = SqlDbType.VarChar, Value = grupos.NombreGrupo});
                dac.ExecuteNonQuery("InsertGrupos", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<GruposModel> GetGrupos()
        {

            
            List<GruposModel> lista = new List<GruposModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetGrupos", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GruposModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            Clave  = row["Clave"].ToString(),
                            NombreGrupo = row["NombreGrupo"].ToString(),
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

         public int UpdateGrupos(GruposModel grupos)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = 1 });
                parametros.Add(new SqlParameter { ParameterName = "@Clave", SqlDbType = SqlDbType.Int, Value = grupos.Clave });
                parametros.Add(new SqlParameter { ParameterName = "@NombreGrupo", SqlDbType = SqlDbType.VarChar, Value = grupos.NombreGrupo });
                dac.ExecuteNonQuery("UpdateGrupos", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DeleteGrupos(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DeleteGrupos", parametros);
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