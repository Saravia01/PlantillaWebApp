
namespace reportesApi.Models
{
    public class MateriasModel
    {
        public int Id {get; set;}
        public string NombreMateria {get; set;}
        public string ClaveMateria {get; set;}
        public string idCarrera {get; set;}
        public int Estatus {get; set;}
        public int FechaRegistro {get; set;}
        public int UsuarioRegistra {get; set;}
    }
}