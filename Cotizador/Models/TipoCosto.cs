using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    public class TipoCosto
    {
        public int IDTipoCosto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }
    }
}