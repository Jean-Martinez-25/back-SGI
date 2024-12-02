namespace P_SGI_BE.ViewModel
{
    public class ServicioViewModels
    {
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int IdPropietario { get; set; }
    }
    public class RecetaViewModel
    {
        public int IdServicio { get; set; }
        public int IdProducto { get; set; }
        public double Cantidad { get; set; }
        public int IdPropietario { get; set; }
    }
    public class ventaViewModel 
    { 
        public int IdCliente { get; set; }
        public double Valor { get; set; }
        public int IdMetodoPago { get; set; }
        public int IdPropietario { get; set; }
        public string NumFactura { get; set; }
    }
    public class movimientoVentaModel
    {
        public int IdVenta { get; set; }
        public int IdServicio { get; set; }
        public double Valor { get; set; }
        public int Cantidad { get; set; }
        public int IdUsuario { get; set; }
        public int IdPropietario { get; set; }
        public string NumFactura { get; set; }
    }
}
