using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class CarreraService
    {
        private string connection;

        public CarreraService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<Carrera>> GetCarrerasAsync()
        {
            List<Carrera> carreras = new List<Carrera>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetCarreras", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    carreras.Add(new Carrera
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        NombreCarrera = row["NombreCarrera"].ToString(),
                        Abreviatura = row["Abreviatura"].ToString(),
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
            return carreras;
        }

        public async Task<Carrera> GetCarreraByIdAsync(int id)
        {
            Carrera carrera = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetCarreraById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    carrera = new Carrera
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        NombreCarrera = row["NombreCarrera"].ToString(),
                        Abreviatura = row["Abreviatura"].ToString(),
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
            return carrera;
        }

        public async Task AddCarreraAsync(Carrera carrera)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@NombreCarrera", SqlDbType = SqlDbType.VarChar, Value = carrera.NombreCarrera },
                    new SqlParameter { ParameterName = "@Abreviatura", SqlDbType = SqlDbType.VarChar, Value = carrera.Abreviatura },
                    new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = carrera.Estatus },
                    new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = carrera.UsuarioRegistra },
                    new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.DateTime, Value = carrera.FechaRegistro }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertCarrera", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateCarreraAsync(Carrera carrera)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = carrera.Id },
                    new SqlParameter { ParameterName = "@NombreCarrera", SqlDbType = SqlDbType.VarChar, Value = carrera.NombreCarrera },
                    new SqlParameter { ParameterName = "@Abreviatura", SqlDbType = SqlDbType.VarChar, Value = carrera.Abreviatura },
                    new SqlParameter { ParameterName = "@Estatus", SqlDbType = SqlDbType.VarChar, Value = carrera.Estatus },
                    new SqlParameter { ParameterName = "@UsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = carrera.UsuarioRegistra },
                    new SqlParameter { ParameterName = "@FechaRegistro", SqlDbType = SqlDbType.DateTime, Value = carrera.FechaRegistro }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdateCarrera", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteCarreraAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeleteCarrera", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
