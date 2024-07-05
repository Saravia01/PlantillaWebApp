using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class GruposMateriasService
    {
        private  string connection;
        
        
        public GruposMateriasService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertGruposMaterias(GruposMateriasModel gm)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@IdMateria", SqlDbType = SqlDbType.Int, Value = gm.IdMateria });
                parametros.Add(new SqlParameter { ParameterName = "@IdGrupo", SqlDbType = SqlDbType.Int, Value = gm.IdGrupo});
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = gm.Estatus});
                parametros.Add(new SqlParameter { ParameterName = "@Fecha_registra", SqlDbType = SqlDbType.VarChar, Value = gm.Fecha_registra});
                parametros.Add(new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.Int, Value = gm.UsuarioRegistra });
               
                dac.ExecuteNonQuery("InsertGruposMaterias", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<GruposMateriasModel> GetGruposMaterias()
        {

            
            List<GruposMateriasModel> lista = new List<GruposMateriasModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetGruposMaterias", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new GruposMateriasModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            IdMateria  = int.Parse(row["IdMateria"].ToString()),
                            IdGrupo = int.Parse(row["IdGrupo"].ToString()),
                            Estatus = int.Parse(row["Periodo"].ToString()),
                            Fecha_registra = row["Fecha_registra"].ToString(),
                            UsuarioRegistra = int.Parse(row["UsuarioRegistra"].ToString()),
                            
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

         public int UpdateGruposMaterias(GruposMateriasModel gm)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = gm.Id });
                parametros.Add(new SqlParameter { ParameterName = "@IdMateria", SqlDbType = SqlDbType.Int, Value = gm.IdMateria });
                parametros.Add(new SqlParameter { ParameterName = "@IdGrupo", SqlDbType = SqlDbType.Int, Value = gm.IdGrupo });
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = gm.Estatus });
                parametros.Add(new SqlParameter { ParameterName = "@Fecha_registra", SqlDbType = SqlDbType.VarChar, Value = gm.Fecha_registra });
                parametros.Add(new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.Int, Value = gm.UsuarioRegistra });
            
                dac.ExecuteNonQuery("UpdateGruposMaterias", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DeleteGruposMaterias(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DeleteGruposMaterias", parametros);
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
