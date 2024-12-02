using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_SGI_BE.Models;
using P_SGI_BE.ViewModel;
using System.Runtime.CompilerServices;

namespace P_SGI_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : Controller
    {
        private readonly AplicationDbContext _context;
        public InventarioController(AplicationDbContext context) { _context = context; }
        [HttpGet("listado-inventario")]
        public async Task<IActionResult> ListaInventario(int idPropietario)
        {
            try
            {
                var listaInventario = await (from inv in _context.Inventario
                                             join pro in _context.Productos on inv.IdProducto equals pro.Id
                                             join tipPro in _context.TipoProducto on pro.IdTipoProducto equals tipPro.Id
                                             join me in _context.Medidas on pro.IdMedida equals me.Id
                                             where inv.IdPropietario == idPropietario
                                             select new
                                             {
                                                 inv.Id,
                                                 NombreProducto = pro.Nombre,
                                                 Cantidad = inv.Cantidad,
                                                 medida = me.Nombre,
                                                 TipoProducto = tipPro.Nombre
                                             }).ToListAsync();
                return Ok(listaInventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("facturas")]
        public async Task<IActionResult> ObtenerCompras(int idCliente)
        {
            try
            {
                var facturas = await (from cos in _context.Costos
                                      join usu in _context.Usuarios on cos.IdUsuario equals usu.Id
                                      where cos.IdPropietario == idCliente
                                      select new
                                      {
                                          cos.NumFactura,
                                          cos.valorTotal,
                                          cos.FechaCreacion,
                                          nombreUsuario = string.Concat(usu.Nombre, " ", usu.Apellido)
                                      }).ToArrayAsync();
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obtener-factura-lista")]
        public async Task<IActionResult> ObtenerFacturas(int idCliente)
        {
            try
            {
                var listaProductosFactura = await (from movi in _context.MovimientosInventarios
                                                   join pro in _context.Productos on movi.IdProducto equals pro.Id
                                                   select new
                                                   {
                                                       pro.Nombre,
                                                       movi.Cantidad,
                                                       movi.ValorTotal,
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
        [HttpGet("compras")]
        public async Task<IActionResult> ObtenerTotalDeCompras(int idCliente)
        {
            try
            {
                var totalCompras = await (from cos in _context.Costos
                                          where cos.IdPropietario == idCliente
                                          select cos.valorTotal).SumAsync();
                return Ok(totalCompras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obtener-factura")]
        public async Task<IActionResult> OtenerLastFactura(int idCliente)
        {
            try
            {
                var numeroFactura = await (from costos in _context.Costos
                                           where costos.IdPropietario == idCliente
                                           select costos.NumFactura)
                          .MaxAsync();
                return Ok(numeroFactura);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("agregar-costo-inventario")]
        public async Task<IActionResult> AgregarCosto(CostosViewModels costoModel)
        {
            try
            {
                var costo = new Costos
                {
                    NumFactura = costoModel.NumFactura,
                    FechaCreacion = DateTime.Now,
                    valorTotal = costoModel.valorTotal,
                    IdPropietario = costoModel.IdPropietario,
                    IdUsuario = costoModel.IdUsuario
                };
                _context.Costos.Add(costo);
                await _context.SaveChangesAsync();

                return Ok(costo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("agregar-movimiento-inventario")]
        public async Task<IActionResult> AgregarMovimientos(MovimientosInventarioViewModels movInventario)
        {
            try
            {
                var movimientoInventario = new MovimientosInventario
                {
                    Cantidad = movInventario.Cantidad,
                    IdProducto = movInventario.IdProducto,
                    IdPropietario = movInventario.IdPropietario,
                    IdUsuario = movInventario.IdUsuario,
                    ValorTotal = movInventario.ValorTotal,
                    NumFactura = movInventario.NumFactura,
                    FechaCreacion = DateTime.Now,
                };
                _context.MovimientosInventarios.Add(movimientoInventario);
                await _context.SaveChangesAsync();
                return Ok(movimientoInventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("agregar-inventario/{idProducto}")]
        public async Task<IActionResult> ActualizarInventario(int idProducto, InventarioViewModels inv)
        {
            try
            {
                if (idProducto != inv.IdProducto)
                {
                    return BadRequest();
                }
                var inventario = await _context.Inventario.FirstOrDefaultAsync(i => i.IdProducto == idProducto);
                if (inventario == null)
                {
                    // Si no hay un registro para ese producto, lo creamos
                    inventario = new Inventario
                    {
                        IdProducto = idProducto,
                        Cantidad = inv.Cantidad,
                        IdProveedor = inv.IdProveedor,
                        IdPropietario = inv.IdPropietario
                    };
                    _context.Inventario.Add(inventario);
                }
                else
                {
                    // Si ya existe un registro para ese producto, actualizamos la cantidad sumando la nueva cantidad
                    inventario.Cantidad += inv.Cantidad;
                    _context.Entry(inventario).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
                return Ok(inventario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("obtener-info-producto")]
        public async Task<IActionResult> obtenerInfoProducto(int idProducto, int idPropietario)
        {
            try
            {
                var producto = await (from pro in _context.Productos
                                      where pro.Id == idProducto
                                      && pro.IdPropietario == idPropietario
                                      select new
                                      {
                                          id = pro.Id,
                                          nombre = pro.Nombre,
                                          valor = pro.Valor,
                                          medida = pro.IdMedida,
                                          tipoProducto = pro.IdTipoProducto
                                      }).FirstOrDefaultAsync();
                return Ok(producto);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
