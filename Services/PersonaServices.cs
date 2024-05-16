using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class PersonasService
    {
        private readonly string connection;

        public PersonasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int InsertPersona(PersonaModel persona)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_insert_persona", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = persona.Nombre });
                        cmd.Parameters.Add(new SqlParameter("@ApPaterno", SqlDbType.VarChar) { Value = persona.ApPaterno });
                        cmd.Parameters.Add(new SqlParameter("@ApMaterno", SqlDbType.VarChar) { Value = persona.ApMaterno });
                        cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = persona.Direccion });
                        cmd.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int) { Value = persona.Estatus });

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar persona: " + ex.Message);
                    return 0;
                }
            }
        }

        public int UpdatePersona(PersonaModel persona)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_update_persona", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = persona.ID });
                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = persona.Nombre });
                        cmd.Parameters.Add(new SqlParameter("@ApPaterno", SqlDbType.VarChar) { Value = persona.ApPaterno });
                        cmd.Parameters.Add(new SqlParameter("@ApMaterno", SqlDbType.VarChar) { Value = persona.ApMaterno });
                        cmd.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar) { Value = persona.Direccion });
                        cmd.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int) { Value = persona.Estatus });

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar persona: " + ex.Message);
                    return 0;
                }
            }
        }

        public int DeletePersona(int id)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_delete_persona", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = id });

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar persona: " + ex.Message);
                    return 0;
                }
            }
        }
    }
}
