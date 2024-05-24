 public class MateriasModel
    {
        public int Id { get; set; }
        public string NombreMateria { get; set; }
        public int ClaveMateria { get; set; }
        public int IdCarrera { get; set; }
        public int Estatus { get; set; }  
        public string FechaRegistro { get; set; }
        public string UsuarioRegistra { get; set; }
    }