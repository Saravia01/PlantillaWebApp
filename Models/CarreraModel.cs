
namespace reportesApi.Models
{
    public class CarreraModel
    {
        public int Id { get; set; }
        public string Carreras { get; set; }
        public string Abreviatura { get; set; }
        public int UsuarioRegistro { get; set; }        
        public string FechaRegistro { get; set; }
        public int Estatus { get; set; }
    }
}
