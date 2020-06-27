using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cotizador.Models
{
    public class Sistema
    {
        public int IDSistema { get; set; }
        public int IDModelo { get; set; }
        public Modelo Modelo { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }
    
        public ICollection<Componente> Componentes { get; set; }

        public ICollection<Producto> Productos { get; set; }

    }
}