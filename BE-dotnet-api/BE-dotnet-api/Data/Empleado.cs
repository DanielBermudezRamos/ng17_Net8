namespace BE_dotnet_api.Data
{
    //  `Id`, `DNI`, `Nombre`, `Apellido`, `Direccion`, `Cargo_Id`, `SueldoHora_Default`, `Activo`
    public class Empleado
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}
