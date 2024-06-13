using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class MateriaAlumnoService
    {
        private string connection;

        public MateriaAlumnoService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public async Task<IEnumerable<MateriaAlumno>> GetMateriaAlumnosAsync()
        {
            List<MateriaAlumno> materiaAlumnos = new List<MateriaAlumno>();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                DataSet ds = await dac.FillAsync("sp_GetMateriaAlumnos", null);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    materiaAlumnos.Add(new MateriaAlumno
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        IdMateria = int.Parse(row["IdMateria"].ToString()),
                        Matricula = row["Matricula"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return materiaAlumnos;
        }

        public async Task<MateriaAlumno> GetMateriaAlumnoByIdAsync(int id)
        {
            MateriaAlumno materiaAlumno = null;
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                DataSet ds = await dac.FillAsync("sp_GetMateriaAlumnoById", parametros);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    materiaAlumno = new MateriaAlumno
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        IdMateria = int.Parse(row["IdMateria"].ToString()),
                        Matricula = row["Matricula"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return materiaAlumno;
        }

        public async Task AddMateriaAlumnoAsync(MateriaAlumno materiaAlumno)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@IdMateria", SqlDbType = SqlDbType.Int, Value = materiaAlumno.IdMateria },
                    new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = materiaAlumno.Matricula }
                };
                await dac.ExecuteNonQueryAsync("sp_InsertMateriaAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateMateriaAlumnoAsync(MateriaAlumno materiaAlumno)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList
                {
                    new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = materiaAlumno.Id },
                    new SqlParameter { ParameterName = "@IdMateria", SqlDbType = SqlDbType.Int, Value = materiaAlumno.IdMateria },
                    new SqlParameter { ParameterName = "@Matricula", SqlDbType = SqlDbType.VarChar, Value = materiaAlumno.Matricula }
                };
                await dac.ExecuteNonQueryAsync("sp_UpdateMateriaAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteMateriaAlumnoAsync(int id)
        {
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList { new SqlParameter { ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value = id } };
                await dac.ExecuteNonQueryAsync("sp_DeleteMateriaAlumno", parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
