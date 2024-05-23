using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using reportesApi.DataContext;
using reportesApi.Models;

namespace reportesApi.Services
{
    public class CarrerasService
    {
        private readonly string connection;

        public CarrerasService(IMarcatelDatabaseSetting settings)
        {
            connection = settings.ConnectionString;
        }

        public int InsertCarrera(CarrerasModel carrera)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertCarrera", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Abreviatura", SqlDbType.VarChar) { Value = carrera.Abreviatura });
                        cmd.Parameters.Add(new SqlParameter("@FechaRegistro", SqlDbType.Date) { Value = carrera.FechaRegistro });
                        cmd.Parameters.Add(new SqlParameter("@UsuarioRegistra", SqlDbType.Int) { Value = carrera.UsuarioRegistra });
                        cmd.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int) { Value = carrera.Estatus });

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar carrera: " + ex.Message);
                    return 0;
                }
            }
        }

        public int UpdateCarrera(CarrerasModel carrera)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateCarrera", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = carrera.Id });
                        cmd.Parameters.Add(new SqlParameter("@Abreviatura", SqlDbType.VarChar) { Value = carrera.Abreviatura });
                        cmd.Parameters.Add(new SqlParameter("@FechaRegistro", SqlDbType.Date) { Value = carrera.FechaRegistro });
                        cmd.Parameters.Add(new SqlParameter("@UsuarioRegistra", SqlDbType.Int) { Value = carrera.UsuarioRegistra });
                        cmd.Parameters.Add(new SqlParameter("@Estatus", SqlDbType.Int) { Value = carrera.Estatus });

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar carrera: " + ex.Message);
                    return 0;
                }
            }
        }

        public int DeleteCarrera(int id)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DeleteCarrera", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al eliminar carrera: " + ex.Message);
                    return 0;
                }
            }
        }

        public List<CarrerasModel> GetCarreras()
        {
            List<CarrerasModel> carreras = new List<CarrerasModel>();

            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetCarreras", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CarrerasModel carrera = new CarrerasModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Abreviatura = reader["Abreviatura"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]).ToString("dd/MM/yyyy"),
                                    UsuarioRegistra = Convert.ToInt32(reader["UsuarioRegistra"]),
                                    Estatus = Convert.ToInt32(reader["Estatus"])
                                };

                                carreras.Add(carrera);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener carreras: " + ex.Message);
                }
            }

            return carreras;
        }

        public CarrerasModel GetCarreraById(int id)
        {
            CarrerasModel carrera = null;

            using (SqlConnection conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetCarreraById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                carrera = new CarrerasModel
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Abreviatura = reader["Abreviatura"].ToString(),
                                    FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]).ToString("dd/MM/yyyy"),
                                    UsuarioRegistra = Convert.ToInt32(reader["UsuarioRegistra"]),
                                    Estatus = Convert.ToInt32(reader["Estatus"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener carrera: " + ex.Message);
                }
            }

            return carrera;
        }
    }
}
