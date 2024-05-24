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
                        cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar) { Value = persona.ApellidoPaterno });
                        cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar) { Value = persona.ApellidoMaterno });
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

                        cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = persona.Id });
                        cmd.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar) { Value = persona.Nombre });
                        cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", SqlDbType.VarChar) { Value = persona.ApellidoPaterno });
                        cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar) { Value = persona.ApellidoMaterno });
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

        // El método GetPersonas debe estar fuera de los otros métodos, al mismo nivel
        public List<PersonaModel> GetPersonas()
        {
            List<PersonaModel> personas = new List<PersonaModel>();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_get_personas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PersonaModel persona = new PersonaModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Nombre = reader["Nombre"].ToString(),
                                    ApellidoPaterno = reader["ApellidoPaterno"].ToString(),
                                    ApellidoMaterno = reader["ApellidoMaterno"].ToString(),
                                    Direccion = reader["Direccion"].ToString(),
                                    Estatus = (reader["Estatus"]).ToString(),
                                };

                                personas.Add(persona);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener personas: " + ex.Message);
                }
            }

            return personas;
        }
    }
}

