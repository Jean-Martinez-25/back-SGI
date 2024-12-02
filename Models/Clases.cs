using System.ComponentModel.DataAnnotations.Schema;

namespace P_SGI_BE.Models
{
    public class Propietarios
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreEmpresa { get; set; }
    }
    public class Usuarios
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set;}
        public string Usuario { get; set; }
        public string Password { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
        [ForeignKey("IdPropietario")]
        public TipoUsuario TipoUsuario { get; set; }
    }
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class Servicios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
    public class Recetas
    {
        public int Id { get; set; }
        public int IdServicio { get; set; }
        public int IdProducto { get; set; }
        public double Cantidad { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdServicio")]
        public Servicios Servicios { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
        [ForeignKey("IdProducto")]
        public Productos Productos { get; set; }
    }
    public class MetodoPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
    public class Medidas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
    public class TipoProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
    public class Proveedores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set;}
        public int IdMedida { get; set; }
        public double Valor { get; set; }
        public int IdTipoProducto { get; set; }
        public int IdPropietario { get; set; }
        [ForeignKey("IdTipoProducto")]
        public TipoProducto TipoProducto { get; set; }
        [ForeignKey("IdMedida")]
        public Medidas Medidas { get; set; }
        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }

    }
    public class Ventas
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public double Valor { get; set; }
        public int IdMetodoPago { get; set; }
        public string FechaCreacion { get; set; }
        public int IdPropietario { get; set; }
        public string NumFactura { get; set; }

        [ForeignKey("IdCliente")]
        public Clientes Clientes { get; set; }

        [ForeignKey("IdMetodoPago")]
        public MetodoPago MetodoPago { get; set; }

        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
    public class Inventario
    {
        public int Id { get; set; }
        public int IdProducto { get; set;}
        public double Cantidad { get; set; }
        public int IdProveedor { get; set; }
        public int IdPropietario { get; set; }

        [ForeignKey("IdProducto")]
        public Productos Productos { get; set; }

        [ForeignKey("IdProveedor")]
        public Proveedores Proveedores { get; set; }

        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }

    }
    public class MovimientosVenta
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdServicio { get; set; }
        public double Valor { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdPropietario { get; set; }
        public string NumFactura { get; set; }

        [ForeignKey("IdVenta")]
        public Ventas Ventas { get; set; }

        [ForeignKey("IdServicio")]
        public Servicios Servicios { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios Usuarios { get; set; }

        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
    public class MovimientosInventario
    {
        public int Id { get; set; }
        public double Cantidad { get; set; }
        public int IdProducto { get; set; }
        public double ValorTotal { get; set; }
        public int NumFactura { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdPropietario { get; set; }

        [ForeignKey("IdProducto")]
        public Productos Productos { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuarios Usuarios { get; set; }

        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
    public class Costos
    {
        public int Id { get; set; }
        public int NumFactura { get; set; }
        public double valorTotal { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int IdUsuario { get; set; }
        public int IdPropietario { get; set; }


        [ForeignKey("IdUsuario")]
        public Usuarios Usuarios { get; set; }

        [ForeignKey("IdPropietario")]
        public Propietarios Propietarios { get; set; }
    }
}
