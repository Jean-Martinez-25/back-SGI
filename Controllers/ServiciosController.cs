using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_SGI_BE.Models;
using P_SGI_BE.ViewModel;

namespace P_SGI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : Controller
    {
        private readonly AplicationDbContext _context;
        public ServiciosController(AplicationDbContext context) { _context = context; }
        
        [HttpPost("agregar-servicio")]
        public async Task<IActionResult> AgregarServicio(ServicioViewModels servicio)
        {
            try
            {
                var newReceta = new Servicios
                {
                    Nombre = servicio.Nombre,
                    Precio = servicio.Precio,
                    IdPropietario = servicio.IdPropietario,
                };
                _context.Servicios.Add(newReceta);
                await _context.SaveChangesAsync();
                return Ok(newReceta.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("editar-servicio/{id}")]
        public async Task<IActionResult> Actualizar(int id, ServicioViewModels service)
        {
            try
            {
                var servicioItem = await _context.Servicios.FindAsync(id);
                servicioItem.Nombre = service.Nombre;
                servicioItem.Precio = service.Precio;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("listado-servicios")]
        public async Task<IActionResult> ListaServicios(int idCliente) 
        {
            try
            {
                var listaServicios = await (from servicios in _context.Servicios
                                            where servicios.IdPropietario == idCliente
                                            select new
                                            {
                                                servicios.Id,
                                                servicios.Nombre,
                                                servicios.Precio,
                                                servicios.IdPropietario
                                            }).ToListAsync();
                return Ok(listaServicios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("agregar-receta")]
        public async Task<IActionResult> AgregarReceta(RecetaViewModel receta)
        {
            try
            {
                var newReceta = new Recetas
                {
                    IdProducto = receta.IdProducto,
                    IdServicio = receta.IdServicio,
                    Cantidad = receta.Cantidad,
                    IdPropietario = receta.IdPropietario
                };
                _context.Recetas.Add(newReceta);
                await _context.SaveChangesAsync();
                return Ok(newReceta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
