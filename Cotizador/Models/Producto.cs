using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    public class Producto
    {
        public int IDProducto { get; set; }
        public int IDSistema { get; set; }
        public Sistema Sistema { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Cotizacion> Cotizacions { get; set; }
        public ICollection<Costos> Costos { get; set; }

    }
}