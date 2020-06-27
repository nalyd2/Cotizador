using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Cotizador.Models
{
    public class Cotizacion
    {
        public int IDCotizacion { get; set; }
        public int Numero { get; set; }
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public int IDProducto { get; set; }
        public Producto Producto { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Creada { get; set; }
        public DateTime Modificada { get; set; }
        public DateTime Vigencia { get; set; }
        public bool Activo { get; set; }

        public ICollection<CotizacionDet> CotizacionDets { get; set; }
    }
}