using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    public class CotizacionDet
    {
        public int IDCotizacionDet { get; set; }
        public int IDCotizacion { get; set; }
        public Cotizacion Cotizacion { get; set; }
        public Int16 Linea { get; set; }
        public int Componente { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public bool Activo { get; set; }
    }
}