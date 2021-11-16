using System;
using System.Collections.Generic;

#nullable disable

namespace BriveExam.Models
{
    public partial class Inventario
    {
        public int IdInventario { get; set; }
        public int IdProducto { get; set; }
        public int IdSucursal { get; set; }
        public int Stock { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Sucursal IdSucursalNavigation { get; set; }
    }
}
