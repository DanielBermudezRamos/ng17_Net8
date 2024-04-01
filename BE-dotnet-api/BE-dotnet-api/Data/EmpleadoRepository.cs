namespace BE_dotnet_api.Data
{
    public class EmpleadoRepository
    {
        private readonly AppDbContext _appDbContext;
        public EmpleadoRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }
        public async Task AddEmpleado(Empleado empleado)
        {
            await _appDbContext.Set<Empleado>().AddAsync(empleado);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
