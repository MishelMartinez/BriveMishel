using System;
using System.Collections.Generic;

#nullable disable

namespace BriveExam.Models
{
    public partial class Sucursal
    {
        public Sucursal()
        {
            Inventarios = new HashSet<Inventario>();
        }

        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }
    }
}
