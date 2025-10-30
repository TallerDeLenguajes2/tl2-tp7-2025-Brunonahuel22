using Microsoft.AspNetCore.Mvc;

using Tp7.Repository;
using Tp7.Models;
namespace Tp7.Controllers;


[ApiController]
[Route("[controller]")]
public class ProductosControllers : ControllerBase
{

    // tengo que traer el objeto desde repo para usar los metodos desde aqui
    private ProductoRepository _repo = new ProductoRepository();

    [HttpGet]
    public IActionResult GetProductos()
    {
        var lista = _repo.listarProductos();

        return Ok(lista);
    }

    [HttpGet("get/{id}")]

    public IActionResult GetForId(int id)
    {
        Productos productoEncontrado = _repo.obtenerDetallePorId(id);
        return Ok(productoEncontrado);
    }

    [HttpPost("crear")]
    public IActionResult PostProducto([FromBody] Productos p)
    {
        Productos productoNuevo;
        productoNuevo = _repo.crearProducto(p);
        return Ok(productoNuevo);
    }

    [HttpPut("{id}")]
    public IActionResult ModificarProducto(int id, [FromBody] Productos producto)
    {
        int filas = _repo.ModificarProductoExistente(id, producto);

        if (filas == 0)
        {
            return NotFound($"No se encontró el producto con ID {id}");
        }


        return Ok("Producto actualizado correctamente");
    }

    [HttpDelete("{id}")]
    public IActionResult EliminarProducto(int id)
    {
        int filas = _repo.EliminarProducto(id);

        if (filas == 0)
            return NotFound($"No se encontró el producto con ID {id}");

        return Ok("Producto eliminado correctamente");
    }


}