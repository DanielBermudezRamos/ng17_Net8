using BE_dotnet_api.data.Repositories;
using BE_dotnet_api.Model;
using Microsoft.AspNetCore.Mvc;

namespace BE_dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRespository;

        public EmpleadosController(IEmpleadoRepository empleadoRespository)
        {
            _empleadoRespository = empleadoRespository;
        }
        // ----------------------------------------------
        [HttpGet]
        public async Task<IActionResult> GetAllEmpleados()
        {
            return Ok(await _empleadoRespository.GetAllEmpleadosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleadoById(int id)
        {
            return Ok(await _empleadoRespository.GetEmpleadoByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> InsertEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var created = await _empleadoRespository.InsertEmpleadoAsync(empleado);

            return Created("created",created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmpleado([FromBody] Empleado empleado)
        {
            if (empleado == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _empleadoRespository.UpdateEmpleadoAsync(empleado.Id, empleado);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> deleteEmpleado(int id)
        {
            await _empleadoRespository.DeleteEmpleadoByIdAsync(id);

            return NoContent();
        }

    }
}
