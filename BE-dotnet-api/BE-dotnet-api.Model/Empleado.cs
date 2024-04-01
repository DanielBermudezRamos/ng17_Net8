namespace BE_dotnet_api.Model
{    
    public class Empleado
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Cargo_Id { get; set; }
        public int SueldoHora_Default { get; set; }
        public bool Activo { get; set; }
    }
}
