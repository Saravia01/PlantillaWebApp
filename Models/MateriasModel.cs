using System;
namespace reportesApi.Models
{
    public class MateriasModel
    {
        public int Id { get; set; }
        public string NombreMateria { get; set; }
        public string ClaveMateria { get; set; }
        public int IdCarrera { get; set; }
        public string UsuarioRegistra { get; set; }        
        public int Estatus { get; set; }
        public string FechaRegistro { get; set; }
    }
}
