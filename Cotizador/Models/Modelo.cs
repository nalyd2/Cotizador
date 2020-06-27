using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    public class Modelo
    {
        public int IDModelo { get; set; }

        public int IDMarca { get; set; }
        public Marca Marca{ get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Sistema> Sistemas { get; set; }
    }
}