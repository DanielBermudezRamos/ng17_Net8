using BE_dotnet_api.Model;

namespace BE_dotnet_api.data.Repositories
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetAllEmpleadosAsync();
        Task<Empleado> GetEmpleadoByIdAsync(int id);
        Task<bool> InsertEmpleadoAsync(Empleado empleado);
        Task<bool> UpdateEmpleadoAsync(int id, Empleado empleado);
        Task<bool> DeleteEmpleadoByIdAsync(int id);
    }
}
