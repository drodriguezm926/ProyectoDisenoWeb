using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class IntermedioProductoTipoPrecio
    {
        public ProductoModel productoModel { get; set; }
        public TipoPrecioToProduct TipoPrecio { get; set; }
    }
}
