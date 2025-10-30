using Microsoft.AspNetCore.Mvc;
using Tp7.Models;
using Tp7.Repository;

namespace Tp7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresupuestosController : ControllerBase
    {
        // 🔹 Instanciamos el repositorio
        private PresupuestosRepository _repo = new PresupuestosRepository();

        // 🔹 POST /presupuestos/crear
        [HttpPost("crear")]
        public IActionResult CrearPresupuesto([FromBody] Presupuestos p)
        {
            if (p == null || string.IsNullOrWhiteSpace(p.nombreDestinatario))
                return BadRequest("Faltan datos del presupuesto.");

            p.FechaCreacion = DateTime.Now;
            var nuevoPresupuesto = _repo.CrearPresupuesto(p);

            return Ok(nuevoPresupuesto);
        }

        // 🔹 GET /presupuestos
        [HttpGet]
        public IActionResult ListarPresupuestos()
        {
            var lista = _repo.ListarPresupuestos();
            return Ok(lista);
        }

        // 🔹 GET /presupuestos/{id}
        [HttpGet("{id}")]
        public IActionResult ObtenerPresupuestoPorId(int id)
        {
            var presupuesto = _repo.ObtenerPresupuestoPorId(id);

            if (presupuesto == null)
                return NotFound($"No se encontró el presupuesto con ID {id}");

            return Ok(presupuesto);
        }

        // 🔹 POST /presupuestos/{id}/agregarProducto
        [HttpPost("{id}/agregarProducto")]
        public IActionResult AgregarProducto(int id, int idProducto, int cantidad)
        {
            if (cantidad <= 0)
                return BadRequest("La cantidad debe ser mayor a 0.");

            _repo.AgregarProductoAPresupuesto(id, idProducto, cantidad);
            return Ok("Producto agregado correctamente al presupuesto.");
        }

        // 🔹 DELETE /presupuestos/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarPresupuesto(int id)
        {
            int filas = _repo.EliminarPresupuesto(id);

            if (filas == 0)
                return NotFound($"No se encontró el presupuesto con ID {id}");

            return Ok("Presupuesto eliminado correctamente.");
        }
    }
}
