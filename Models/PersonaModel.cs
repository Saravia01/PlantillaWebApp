<<<<<<< Updated upstream
using System;
namespace reportesApi.Models
{
    public class PersonaModel
    {
        public int Id {get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Direccion { get; set; }
        public int Estatus { get; set; }
    }
}
=======
public class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public string Direccion { get; set; }
    public string Estatus { get; set; }
    public string UsuarioRegistra { get; set; }
    public DateTime FechaRegistro { get; set; }
}
>>>>>>> Stashed changes
