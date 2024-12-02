using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_SGI_BE.Models;
using P_SGI_BE.ViewModel;

namespace P_SGI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : Controller
    {
        private readonly AplicationDbContext _context;
        public VentaController(AplicationDbContext context) { _context = context; }

        [HttpGet("consumo-servicio/{id}")]
        public async Task<IActionResult> listaConsumo(int id)
        {
            try
            {
                var listaConsumo = await (from receta in _context.Recetas
                                          where receta.IdServicio == id
                                          select new
                                          {
                                              receta.Cantidad,
                                              receta.IdProducto
                                          }).ToArrayAsync();
                return Ok(listaConsumo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("actualizar-inventario/{idProducto}")]
        public async Task<IActionResult> ActualizarInventario(int idProducto, double cantidad)
        {
            try
            {
                var inventario = await _context.Inventario.FirstOrDefaultAsync(i => i.IdProducto == idProducto);
                inventario.Cantidad -= cantidad;
                _context.Entry(inventario).State = EntityState.Modified;

                await _context.SaveChangesAsync();
                return Ok(inventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obtener-factura-ventas")]
        public async Task<IActionResult> ObtenerFacturasVentas(int idCliente, string? fechaConsulta, int? idMetodoPagoOpcional)  // Added fechaFinConsulta parameter
        {
            try
            {
                DateTime? fechaConsultaDate = null;
                if (!string.IsNullOrEmpty(fechaConsulta))
                {
                    bool isValidDate = DateTime.TryParse(fechaConsulta, out DateTime parsedDate);
                    if (isValidDate)
                    {
                        fechaConsultaDate = parsedDate;
                    }
                    else
                    {
                        return BadRequest("El formato de la fecha es inválido.");
                    }
                }

                var query = from ve in _context.Ventas
                            join cli in _context.Clientes on ve.IdCliente equals cli.Id
                            join met in _context.MetodoPago on ve.IdMetodoPago equals met.Id
                            where ve.IdPropietario == idCliente
                            select new
                            {
                                nombreCliente = string.Concat(cli.Nombre, " ", cli.Apellido),
                                metodoPago = met.Nombre,
                                ve.IdMetodoPago,
                                ve.Valor,
                                ve.FechaCreacion,
                                ve.NumFactura
                            };

                if (fechaConsultaDate.HasValue)
                {
                    string fechaConsultaStr = fechaConsultaDate.Value.ToString("yyyy-MM-dd");
                    query = query.Where(ve => ve.FechaCreacion.StartsWith(fechaConsultaStr));
                }

                if (idMetodoPagoOpcional.HasValue)
                {
                    query = query.Where(ve => ve.IdMetodoPago == idMetodoPagoOpcional);
                }

                var listaVentas = await query.ToListAsync();

                if (listaVentas.Count == 0)
                {
                    return NotFound("No se encontraron ventas para los criterios especificados.");
                }

                return Ok(listaVentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obtener-factura-movimiento")]
        public async Task<IActionResult> ObtenerFacturasMovimiento(int idCliente)
        {
            try
            {
                var listaProductosFactura = await (from movi in _context.MovimientosVentas
                                                   join serv in _context.Servicios on movi.IdServicio equals serv.Id
                                                   select new
                                                   {
                                                       serv.Nombre,
                                                       movi.Cantidad,
                                                       movi.Valor,
                                                       movi.NumFactura,
                                                       movi.FechaCreacion
                                                   }).ToListAsync();
                return Ok(listaProductosFactura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obtener-ventas")]
        public async Task<IActionResult> totalVentas(int idCliente)
        {
            try
            {
                var totalVentas = await (from ven in _context.Ventas
                                          where ven.IdPropietario == idCliente
                                          select ven.Valor).SumAsync();
                return Ok(totalVentas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("agregar-movimiento-venta")]
        public async Task<IActionResult> agregarMovimiento(movimientoVentaModel movimiento)
        {
            try
            {
                var newMovimiento = new MovimientosVenta
                {
                    Cantidad = movimiento.Cantidad,
                    FechaCreacion = DateTime.Now,
                    IdPropietario = movimiento.IdPropietario,
                    Valor = movimiento.Valor,
                    IdServicio = movimiento.IdServicio,
                    IdUsuario = movimiento.IdUsuario,
                    IdVenta = movimiento.IdVenta,
                    NumFactura = movimiento.NumFactura
                };
                _context.MovimientosVentas.Add(newMovimiento);
                await _context.SaveChangesAsync();
                return Ok(newMovimiento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("agregar-venta")]
        public async Task<IActionResult> agregarVenta(ventaViewModel venta)
        {
            try
            {
                var newVenta = new Ventas
                {
                    IdCliente = venta.IdCliente,
                    IdMetodoPago = venta.IdMetodoPago,
                    IdPropietario = venta.IdPropietario,
                    FechaCreacion = DateTime.Now.ToString(),
                    Valor = venta.Valor,
                    NumFactura = venta.NumFactura

                };
                _context.Ventas.Add(newVenta);
                await _context.SaveChangesAsync();
                return Ok(newVenta.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
