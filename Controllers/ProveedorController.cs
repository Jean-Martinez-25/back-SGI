using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using P_SGI_BE.Models;

namespace P_SGI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : Controller
    {
        private readonly AplicationDbContext _context;
        public ProveedorController(AplicationDbContext context) { _context = context; }

        [HttpGet("listado-proveedores")]
        public async Task<IActionResult> Get(int idCliente)
        {
            try
            {
                var listadoProveedores = await (from pro in _context.Proveedores
                                                where pro.IdPropietario == idCliente
                                                select new
                                                {
                                                    pro.Id,
                                                    Nombre = string.Concat(pro.Nombre, " ", pro.Apellido)
                                                }).ToArrayAsync();
                return Ok(listadoProveedores);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
