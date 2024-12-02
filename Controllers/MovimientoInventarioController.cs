using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_SGI_BE.Models;

namespace P_SGI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoInventarioController : Controller
    {
        private readonly AplicationDbContext _context;
        public MovimientoInventarioController(AplicationDbContext context) { _context = context; }
        [HttpGet("listado-compras")]
        public async Task<IActionResult> GetCompras(int idPropietario)
        {
            try
            {
                var movimientos = await (from movIn in _context.MovimientosInventarios
                                         join pro in _context.Productos on movIn.IdProducto equals pro.Id
                                         select new
                                         {
                                             NumFactura = movIn.NumFactura,
                                             Producto = pro.Nombre,
                                             Cantidad = movIn.Cantidad,
                                             Total = movIn.ValorTotal,
                                             Fecha = movIn.FechaCreacion
                                         }).ToListAsync();
                if (movimientos.Any())
                {
                    return Ok(new { existe = true, data = movimientos });
                }
                else
                {
                    return Ok(new { existe = false, mensaje = $"No hay registros de movimientos." });
                }
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("compras-diarias")]
        public async Task<IActionResult> GetComprasDiarias(string fecha, int idPropietario)
        {
            try
            {
                var movimientos = await (from movIn in _context.MovimientosInventarios
                                         join pro in _context.Productos on movIn.IdProducto equals pro.Id
                                         where movIn.FechaCreacion.ToString().Contains(fecha)
                                            && movIn.IdPropietario == idPropietario
                                         orderby movIn.FechaCreacion
                                         select new
                                         {
                                             NumFactura = movIn.NumFactura,
                                             Producto = pro.Nombre,
                                             Cantidad = movIn.Cantidad,
                                             Total = movIn.ValorTotal,
                                             Fecha = movIn.FechaCreacion
                                         }).ToListAsync();


                if (movimientos.Any())
                {
                    return Ok(new { existe = true, data = movimientos });
                }
                else
                {
                    return Ok(new { existe = false, mensaje = $"No hay registros de movimientos en la fecha {fecha}." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        [HttpGet("consumo-inventario-diario")]
        public async Task<IActionResult> GetConsumoDiario(string fecha, int idPropietario)
        {
            try
            {
                var movimientos = await (from mv in _context.MovimientosVentas
                                join v in _context.Ventas on mv.IdVenta equals v.Id
                                join r in _context.Recetas on mv.IdServicio equals r.IdServicio
                                join p in _context.Productos on r.IdProducto equals p.Id
                                where mv.FechaCreacion.ToString().Contains(fecha)
                                    && mv.IdPropietario == idPropietario
                                select new
                                {
                                    NumFactura = mv.NumFactura,
                                    Producto = p.Nombre,
                                    Cantidad = r.Cantidad,
                                    Total = p.Valor * r.Cantidad,
                                    Fecha = mv.FechaCreacion
                                }).ToListAsync();

                if (movimientos.Any())
                {
                    return Ok(new { existe = true, data = movimientos });
                }
                else
                {
                    return Ok(new { existe = false, mensaje = $"No hay registros de movimientos en la fecha {fecha}." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        [HttpGet("compras-diarias-producto")]
        public async Task<IActionResult> GetComprasDiariasProducto(string? fecha, int idPropietario, int idProducto)
        {
            try
            {
                var movimientosQuery = from movIn in _context.MovimientosInventarios
                                       join pro in _context.Productos on movIn.IdProducto equals pro.Id
                                       where movIn.IdPropietario == idPropietario
                                            && movIn.IdProducto == idProducto
                                       orderby movIn.FechaCreacion
                                       select new
                                       {
                                           NumFactura = movIn.NumFactura,
                                           Producto = pro.Nombre,
                                           Cantidad = movIn.Cantidad,
                                           Total = movIn.ValorTotal,
                                           Fecha = movIn.FechaCreacion
                                       };

                // Si la fecha no se envía, no filtrar por fecha
                if (!string.IsNullOrEmpty(fecha))
                {
                    movimientosQuery = movimientosQuery.Where(mov => mov.Fecha.ToString().Contains(fecha));
                }

                var movimientos = await movimientosQuery.ToListAsync();

                if (movimientos.Any())
                {
                    return Ok(new { existe = true, data = movimientos });
                }
                else
                {
                    var producto = await (from pro in _context.Productos
                                          where pro.Id == idProducto
                                          select pro.Nombre).FirstOrDefaultAsync();
                    if (!string.IsNullOrEmpty(fecha))
                    {
                        return Ok(new { existe = false, mensaje = $"No se encontraron registros de movimientos en la fecha {fecha} para el producto {producto}." });
                    }
                    else
                    {
                        return Ok(new { existe = false, mensaje = $"No se han encontrado movimientos para el producto {producto}." });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
        [HttpGet("consumo-diario-producto")]
        public async Task<IActionResult> GetConsumoDiarioProducto(string? fecha, int idPropietario, int idProducto)
        {
            try
            {
                var movimientosQuery = from mv in _context.MovimientosVentas
                                  join v in _context.Ventas on mv.IdVenta equals v.Id
                                  join r in _context.Recetas on mv.IdServicio equals r.IdServicio
                                  join p in _context.Productos on r.IdProducto equals p.Id
                                  where p.Id == idProducto
                                       && mv.IdPropietario == idPropietario
                                  select new
                                  {
                                      NumFactura = mv.NumFactura,
                                      Producto = p.Nombre,
                                      Cantidad = r.Cantidad,
                                      Total = p.Valor * r.Cantidad,
                                      Fecha = mv.FechaCreacion
                                  };

                // Si la fecha no se envía, no filtrar por fecha
                if (!string.IsNullOrEmpty(fecha))
                {
                    movimientosQuery = movimientosQuery.Where(mov => mov.Fecha.ToString().Contains(fecha));
                }

                var movimientos = await movimientosQuery.ToListAsync();

                if (movimientos.Any())
                {
                    return Ok(new { existe = true, data = movimientos });
                }
                else
                {
                    var producto = await (from pro in _context.Productos
                                          where pro.Id == idProducto
                                          select pro.Nombre).FirstOrDefaultAsync();
                    if (!string.IsNullOrEmpty(fecha))
                    {
                        return Ok(new { existe = false, mensaje = $"No se encontraron registros de movimientos en la fecha {fecha} para el producto {producto}." });
                    }
                    else
                    {
                        return Ok(new { existe = false, mensaje = $"No se han encontrado movimientos para el producto {producto}." });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
