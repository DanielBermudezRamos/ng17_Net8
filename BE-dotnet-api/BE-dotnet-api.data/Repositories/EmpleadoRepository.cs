using BE_dotnet_api.Model;
using Dapper;
using MySql.Data.MySqlClient;

namespace BE_dotnet_api.data.Repositories
{
    public class EmpleadoRepository(MySQLConfiguration connectionString) : IEmpleadoRepository
    {
        private readonly MySQLConfiguration _connectionString = connectionString;

        protected MySqlConnection DbConnection()
        { 
            return new MySqlConnection(_connectionString.CadenaConexionMySql); 
        }
        // ------------------------------------------

        public async Task<bool> DeleteEmpleadoByIdAsync(int id)
        {
            var db = DbConnection();
            var sql = @"DELETE FROM empleados WHERE Id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

       public async Task<IEnumerable<Empleado>> GetAllEmpleadosAsync()
        {
            var db = DbConnection();
            var sql = @"SELECT Id, DNI, Nombre, Apellido, Direccion, Cargo_Id, SueldoHora_Default, Activo, Fch_Add, Fch_Up 
                        FROM empleados ";
            return await db.QueryAsync<Empleado>(sql, new {});
        }

        public async Task<Empleado> GetEmpleadoByIdAsync(int id)
        {
            var db = DbConnection();
            var sql = @"SELECT Id, DNI, Nombre, Apellido, Direccion, Cargo_Id, SueldoHora_Default, Activo, Fch_Add, Fch_Up 
                        FROM empleados 
                        WHERE Id = @Id";
            return await db.QueryFirstOrDefaultAsync<Empleado>(sql, new { Id = id });
        }

        public async Task<bool> InsertEmpleadoAsync(Empleado empleado)
        {
            var db = DbConnection();
            var sql = @"INSERT INTO empleados (DNI, Nombre, Apellido, Direccion, Cargo_Id, SueldoHora_Default) 
                        VALUES(@DNI, @Nombre, @Apellido, @Direccion, @Cargo_Id, @SueldoHora_Default);";
            var result = await db.ExecuteAsync(sql, new 
            {
                empleado.DNI,
                empleado.Nombre,
                empleado.Apellido,
                empleado.Direccion,
                empleado.Cargo_Id,
                empleado.SueldoHora_Default
            });
            return result > 0;
        }

        public async Task<bool> UpdateEmpleadoAsync(int id, Empleado empleado)
        {
            var db = DbConnection();
            var sql = @"UPDATE empleados SET
	                        DNI = @DNI, 
                            Nombre = @Nombre, 
                            Apellido = @Apellido, 
                            Direccion = @Direccion, 
                            Cargo_Id = @Cargo_Id, 
                            SueldoHora_Default = @SueldoHora_Default, 
                            Activo = @Activo
                        WHERE Id = @Id;";
            var result = await db.ExecuteAsync(sql, new
            {
                empleado.DNI,
                empleado.Nombre,
                empleado.Apellido,
                empleado.Direccion,
                empleado.Cargo_Id,
                empleado.SueldoHora_Default,
                empleado.Activo,
                id
            });
            return result > 0;
        }
    }
}
