using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class MateriasAlumnosService
    {
        private  string connection;
        
        
        public MateriasAlumnosService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertMateriasAlum(MateriasAlumnosModel materiasalum)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@IdMaterias", SqlDbType = SqlDbType.VarChar, Value = materiasalum.IdMaterias });
                parametros.Add(new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = materiasalum.Matricula});
                dac.ExecuteNonQuery("InsertMateriasAlum", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<MateriasAlumnosModel> GetMateriasAlum()
        {

            
            List<MateriasAlumnosModel> lista = new List<MateriasAlumnosModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetMateriasAlum", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new MateriasAlumnosModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            IdMaterias  = int.Parse(row["IdMaterias"].ToString()),
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

         public int UpdateMateriasAlum(MateriasAlumnosModel materiasalum)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = materiasalum.Id });
                parametros.Add(new SqlParameter { ParameterName = "@IdMaterias", SqlDbType = SqlDbType.Int, Value = materiasalum.IdMaterias });
                parametros.Add(new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = materiasalum.Matricula });
                dac.ExecuteNonQuery("UpdateMateriasAlum", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DeleteMateriasAlum(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DeleteMateriasAlum", parametros);
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
