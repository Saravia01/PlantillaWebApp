using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace reportesApi.Services
{
    public class MateriasService
    {
        public string connection;

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
                parametros.Add(new SqlParameter { ParameterName = "@NombreMateria", SqlDbType = SqlDbType.VarChar, Value = materias.NombreMateria});
                parametros.Add(new SqlParameter { ParameterName = "@ClaveMateria", SqlDbType = SqlDbType.VarChar, Value = materias.ClaveMateria});
                parametros.Add(new SqlParameter { ParameterName = "@IdCarrera", SqlDbType = SqlDbType.Int, Value = materias.IdCarrera});
                parametros.Add(new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.Int, Value = materias.Estatus});
                parametros.Add(new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.Date, Value = materias.FechaRegistro});
                parametros.Add(new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.Int, Value = materias.UsuarioRegistra});

                dac.ExecuteNonQuery("InsertMaterias", parametros);
                return 1;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return 0;    
            }

        }

        public List<MateriasModel> GetMaterias( int materias)
        {
            List<MateriasModel> lista = new List<MateriasModel>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            ArrayList parametros = new ArrayList();

            try
            {
                DataSet ds = dac.Fill("GetMaterias");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lista.Add(new MateriasModel{
                            Id = int.Parse(row["Id"].ToString()),
                            NombreMateria = row["NombreMateria"].ToString(),
                            ClaveMateria = row["ClaveMateria"].ToString(),
                            IdCarrera = int.Parse(row["IdCarrera"].ToString()),
                            Estatus = int.Parse(row["Estatus"].ToString()),
                            FechaRegistro = row["FechaRegistro"].ToString(),
                            UsuarioRegistra = int.Parse(row["UsuarioRegistra"].ToString())
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

        public string UpdateMaterias(MateriasModel pmaterias)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);

            try 
            {
                parametros.Add(new SqlParameter { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = pmaterias.Id});
                parametros.Add(new SqlParameter { ParameterName = "@pNombreMateria", SqlDbType = SqlDbType.VarChar, Value = pmaterias.NombreMateria});
                parametros.Add(new SqlParameter { ParameterName = "@pClaveMateria", SqlDbType = SqlDbType.VarChar, Value = pmaterias.ClaveMateria});
                parametros.Add(new SqlParameter { ParameterName = "@pIdCarrera", SqlDbType = SqlDbType.Int, Value = pmaterias.IdCarrera});
                parametros.Add(new SqlParameter { ParameterName = "@pEstatus", SqlDbType = SqlDbType.Int, Value = pmaterias.Estatus});
                parametros.Add(new SqlParameter { ParameterName = "@pFechaRegistro", SqlDbType = SqlDbType.Date, Value = pmaterias.FechaRegistro});
                parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = SqlDbType.Int, Value = pmaterias.UsuarioRegistra});

                dac.ExecuteNonQuery("UpdateMaterias", parametros);
                return "Correcto";
            }
            catch (Exception ex)
            {
                throw ex;   
            }

        }

        public string DeleteMaterias (MateriasModel Id)
        {
            ArrayList parametros = new ArrayList();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            List<CarreraModel> lista = new List<CarreraModel>();

            try 
            {
                parametros.Add(new SqlParameter {ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = Id.Id});

                dac.ExecuteNonQuery("DeleteMaterias", parametros);
                return "Correcto";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}