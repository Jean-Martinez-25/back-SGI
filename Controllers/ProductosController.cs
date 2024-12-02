using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_SGI_BE.Models;
using P_SGI_BE.ViewModel;

namespace P_SGI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AplicationDbContext _context;
        public ProductosController(AplicationDbContext context) { _context = context; }
        [HttpGet("listado-tipo-productos")]
        public async Task<IActionResult> GetTipoProducto(int idCliente) 
        {
            try
            {
                var listaTipoProductos = await (from TipoProducto in _context.TipoProducto
                                                where TipoProducto.IdPropietario == idCliente
                                                select new
                                                {
                                                    TipoProducto.Id,
                                                    TipoProducto.Nombre,
                                                }).ToListAsync();
                return Ok(listaTipoProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("listado-medidas")]
        public async Task<IActionResult> GetMedidas()
        {
            try
            {
                var listadoMedidas = await _context.Medidas.ToListAsync();
                return Ok(listadoMedidas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("listado-productos")]
        public async Task<IActionResult> GetProductos(int idCliente)
        {
            try
            {
                var listaProductos = await (from productos in _context.Productos
                                            join medidas in _context.Medidas on productos.IdMedida equals medidas.Id
                                            join tipoProducto in _context.TipoProducto on productos.IdTipoProducto equals tipoProducto.Id
                                            where productos.IdPropietario == idCliente
                                            select new
                                            {
                                                productos.Id,
                                                productos.Nombre,
                                                Medida = medidas.Nombre,
                                                productos.Valor,
                                                TipoProducto = tipoProducto.Nombre
                                            }).ToListAsync();
                return Ok(listaProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AgregarProducto(ProductosViewModel productoView)
        {
            try
            {
                var producto = new Productos
                {
                    Nombre = productoView.Nombre,
                    IdMedida = productoView.IdMedida,
                    Valor = productoView.Valor,
                    IdTipoProducto = productoView.IdTipoProducto,
                    IdPropietario = productoView.IdPropietario
                };
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("listado-productos-editar")]
        public async Task<IActionResult> TiposProductos(int idPropietario)
        {
            try
            {
                var productosInventario = await (from pro in _context.Productos
                                                 join tip in _context.TipoProducto on pro.IdTipoProducto equals tip.Id
                                                 where pro.IdPropietario == idPropietario
                                                 select new
                                                 {
                                                     id = pro.Id,
                                                     producto = pro.Nombre,
                                                     tipo = tip.Nombre,
                                                     valor = pro.Valor
                                                 }).ToListAsync();
                return Ok(productosInventario);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("editar-producto")]
        public async Task<IActionResult> EditarProducto(ProductosViewModel pro)
        {
            try
            {
                // Validar entrada: Modelo recibido
                if (pro == null)
                {
                    return BadRequest(new { message = "No se proporcionó información del producto. Revisa e intenta nuevamente. 😢", creado = false });
                }

                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(pro.Nombre))
                {
                    return BadRequest(new { message = "El campo 'Nombre' es obligatorio. Revisa e intenta nuevamente. 😢", creado = false });
                }

                if (pro.Valor <= 0)
                {
                    return BadRequest(new { message = "El campo 'Valor' debe ser mayor que 0. Revisa e intenta nuevamente. 😢", creado = false });
                }

                // Buscar el producto en la base de datos
                var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Id == pro.Id);
                if (producto == null)
                {
                    return NotFound(new { message = "El producto especificado no existe. 😢", creado = false });
                }

                // Actualizar propiedades del producto
                producto.Nombre = pro.Nombre;
                producto.Valor = pro.Valor;

                // Guardar cambios
                await _context.SaveChangesAsync();

                // Respuesta exitosa
                return Ok(new { message = "Producto actualizado correctamente 🙌.", creado = true });
            }
            catch (Exception ex)
            {
                // Manejo de errores con un mensaje descriptivo
                return StatusCode(500, new { message = $"Ocurrió un error al actualizar el producto: {ex.Message}. 😢", creado = false });
            }
        }

    }
}
