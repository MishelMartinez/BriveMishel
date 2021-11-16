using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Clases
{
    public class ProductoCLS
    {
        [Display(Name = "Id Producto")]
        public int IdProducto { get; set; }

        [Display(Name = "Nombre Producto")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string NombreProducto { get; set; }

        [Display(Name = "SKU Producto")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Sku { get; set; }


    }
}
