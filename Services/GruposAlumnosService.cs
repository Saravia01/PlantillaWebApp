using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class GruposAlumnosService
    {
        private  string connection;
        
        
        public GruposAlumnosService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertGruposAlum(GruposAlumnosModel gruposalum)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@IdGrupo", SqlDbType = SqlDbType.VarChar, Value = gruposalum.IdGrupo });
                parametros.Add(new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = gruposalum.Matricula});
                dac.ExecuteNonQuery("InsertGruposAlum", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<GruposAlumnosModel> GetGruposAlum()
        {

            
            List<GruposAlumnosModel> lista = new List<GruposAlumnosModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetGruposAlum", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GruposAlumnosModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            IdGrupo  = int.Parse(row["IdGrupo"].ToString()),
                            Matricula = row["Matricula"].ToString(),
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

         public int UpdateGruposAlum(GruposAlumnosModel gruposalum)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = gruposalum.Id });
                parametros.Add(new SqlParameter { ParameterName = "@IdGrupo", SqlDbType = SqlDbType.Int, Value = gruposalum.IdGrupo });
                parametros.Add(new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = gruposalum.Matricula });
                dac.ExecuteNonQuery("UpdateGruposAlum", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DeleteGruposAlum(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DeleteGruposAlum", parametros);
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
