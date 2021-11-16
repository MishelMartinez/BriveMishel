using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Clases
{
    public class SucursalCLS
    {
        [Display(Name = "Id Sucursal")]
        public int IdSucursal { get; set; }

        [Display(Name = "Nombre Sucursal")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string NombreSucursal { get; set; }

        [Display(Name = "Dirección Sucursal")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono Sucursal")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [MinLength(10, ErrorMessage = "Ingrese telefono correctamente")]
        public string Telefono { get; set; }
    }
}
