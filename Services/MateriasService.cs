using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class MateriasService
    {
        private  string connection;
        
        
        public MateriasService(IMarcatelDatabaseSetting settings)
        {
             connection = settings.ConnectionString;
        }

        public MateriasModel InsertMateria(MateriasModel materia)
        {
            
            UsuarioModel usuario = new UsuarioModel();
            ConexionDataAccess dac = new ConexionDataAccess(connection);
            try
            {
                ArrayList parametros = new ArrayList();
                parametros.Add(new SqlParameter { ParameterName = "@pNombreMateria", SqlDbType = SqlDbType.VarChar, Value = materia.NombreMateria });
                parametros.Add(new SqlParameter { ParameterName = "@pClaveMateria", SqlDbType = SqlDbType.VarChar, Value = materia.ClaveMateria});
                parametros.Add(new SqlParameter { ParameterName = "@pidCarrera", SqlDbType = SqlDbType.VarChar, Value = materia.idCarrera });
                parametros.Add(new SqlParameter { ParameterName = "@pFechaRegistro", SqlDbType = SqlDbType.VarChar, Value = materia.FechaRegistro });
                 parametros.Add(new SqlParameter { ParameterName = "@pUsuarioRegistra", SqlDbType = SqlDbType.VarChar, Value = materia.UsuarioRegistra });
                dac.ExecuteNonQuery("insert_Materias", parametros);

                return materia;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
