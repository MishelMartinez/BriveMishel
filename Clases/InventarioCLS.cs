using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Clases
{
    public class InventarioCLS
    {
        [Display(Name = "Id Inventario")]
        public int IdInventario { get; set; }

        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        [Display(Name = "Sucursal")]
        public int IdSucursal { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [Range(1, 1000, ErrorMessage = "Stock entre 1 a 1000")]
        public int Stock { get; set; }

        [Display(Name = "Nombre del Producto")]
        public string NombreProducto { get; set; }

        [Display(Name = "Nombre de la sucursal")]
        public string NombreSucursal { get; set; }

        public String selectSucursal { get; set; }




        

    }
}
