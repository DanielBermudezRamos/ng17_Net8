using Microsoft.EntityFrameworkCore;

namespace BE_dotnet_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Empleado> Empleados { get; set; }
    }
}
