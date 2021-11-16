using System;
using System.Collections.Generic;

#nullable disable

namespace BriveExam.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Sku { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
