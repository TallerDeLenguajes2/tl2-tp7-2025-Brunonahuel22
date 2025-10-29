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
    public IActionResult getProductos()
    {
        var lista = _repo.listarProductos();

        return Ok(lista);
    }
}