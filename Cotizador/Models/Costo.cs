using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    public class Costos
    {
        public int IDCosto { get; set; }
        public int TipoCosto { get; set; }
        public int IDProducto { get; set; }
        public Producto Producto { get; set; }
        public int IDComponente { get; set; }
        public Componente Componente { get; set; }
        public decimal Costo { get; set; }
        public DateTime InicioVigencia { get; set; }
        public DateTime FinVigencia { get; set; }
        public bool Activo { get; set; }

       
    }
}