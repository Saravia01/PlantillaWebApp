using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;

namespace reportesApi.Services
{
    public class MateriasService
    {
        private  string connection;
        
        
        public MateriasService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public int InsertMaterias(MateriasModel materias)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@NombreMateria", SqlDbType = SqlDbType.VarChar, Value = materias.NombreMateria });
                parametros.Add(new SqlParameter { ParameterName = "@ClaveMateria", SqlDbType = SqlDbType.VarChar, Value = materias.ClaveMateria});
                parametros.Add(new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = materias.UsuarioRegistra });
                parametros.Add(new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.VarChar, Value = materias.FechaRegistro });
                parametros.Add(new SqlParameter { ParameterName = "@IdCarrera", SqlDbType = SqlDbType.VarChar, Value = materias.IdCarrera });
                dac.ExecuteNonQuery("InsertMaterias", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public List<MateriasModel> GetMaterias()
        {

            
            List<MateriasModel> lista = new List<MateriasModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();
            try
            {
            
                DataSet ds = dac.Fill("GetMaterias", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new MateriasModel{
                            Id  = int.Parse(row["Id"].ToString()),
                            NombreMateria  = row["NombreMateria"].ToString(),
                            ClaveMateria = row["ClaveMateria"].ToString(),
                            UsuarioRegistra = row["UsuarioRegistra"].ToString(),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            Estatus = int.Parse(row["Estatus"].ToString()),
                            IdCarrera = int.Parse(row["IdCarrera"].ToString()),

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

         public int UpdateMaterias(MateriasModel materias)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = 1 });
                parametros.Add(new SqlParameter { ParameterName = "@NombreMateria", SqlDbType = SqlDbType.VarChar, Value = materias.NombreMateria });
                parametros.Add(new SqlParameter { ParameterName = "@ClaveMateria", SqlDbType = SqlDbType.VarChar, Value = materias.ClaveMateria });
                parametros.Add(new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = materias.UsuarioRegistra });
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = 1 });
                parametros.Add(new SqlParameter { ParameterName = "@IdCarrera", SqlDbType = SqlDbType.VarChar, Value = materias.IdCarrera });
                dac.ExecuteNonQuery("UpdateMaterias", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;
            }
            
        }

        public int DelateCarreras(int Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                parametros.Add(new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.VarChar, Value = Id });
                dac.ExecuteNonQuery("DelateMaterias", parametros);
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