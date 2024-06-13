using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class MateriaService
    {
        private string connection;

        public MateriaService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<Materia>> GetMateriasAsync()
        {
            List<Materia> materias = new List<Materia>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetMaterias", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    materias.Add(new Materia
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        NombreMateria = row["NombreMateria"].ToString(),
                        Abreviatura = row["Abreviatura"].ToString(),
                        IdCarrera = int.Parse(row["IdCarrera"].ToString()),
                        Estatus = row["Estatus"].ToString(),
                        UsuarioRegistra = row["UsuarioRegistra"].ToString(),
                        FechaRegistro = DateTime.Parse(row["FechaRegistro"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return materias;
        }

        public async Task<Materia> GetMateriaByIdAsync(int id)
        {
            Materia materia = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetMateriaById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    materia = new Materia
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        NombreMateria = row["NombreMateria"].ToString(),
                        Abreviatura = row["Abreviatura"].ToString(),
                        IdCarrera = int.Parse(row["IdCarrera"].ToString()),
                        Estatus = row["Estatus"].ToString(),
                        UsuarioRegistra = row["UsuarioRegistra"].ToString(),
                        FechaRegistro = DateTime.Parse(row["FechaRegistro"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return materia;
        }

        public async Task AddMateriaAsync(Materia materia)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@NombreMateria", SqlDbType = SqlDbType.VarChar, Value = materia.NombreMateria },
                    new SqlParameter { ParameterName = "@Abreviatura", SqlDbType = SqlDbType.VarChar, Value = materia.Abreviatura },
                    new SqlParameter { ParameterName = "@IdCarrera", SqlDbType = SqlDbType.Int, Value = materia.IdCarrera },
                    new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = materia.Estatus },
                    new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = materia.UsuarioRegistra },
                    new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.DateTime, Value = materia.FechaRegistro }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertMateria", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateMateriaAsync(Materia materia)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = materia.Id },
                    new SqlParameter { ParameterName = "@NombreMateria", SqlDbType = SqlDbType.VarChar, Value = materia.NombreMateria },
                    new SqlParameter { ParameterName = "@Abreviatura", SqlDbType = SqlDbType.VarChar, Value = materia.Abreviatura },
                    new SqlParameter { ParameterName = "@IdCarrera", SqlDbType = SqlDbType.Int, Value = materia.IdCarrera },
                    new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = materia.Estatus },
                    new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = materia.UsuarioRegistra },
                    new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.DateTime, Value = materia.FechaRegistro }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdateMateria", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteMateriaAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeleteMateria", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
