using BriveExam.Business.BL.Product;
using BriveExam.Clases;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Controllers
{
    public class ProductoController : Controller
    {
        private ProductBL productoBL;


        public ProductoController()
        {
            productoBL = new ProductBL();
        }

        public IActionResult Index()
        {
            List<ProductoCLS> list = productoBL.GetProductos();

            return View(list);
        }

        #region Agregar Sucursal
        public IActionResult Agregar()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Agregar(ProductoCLS producto)
        {
            if (!ModelState.IsValid)
            {


                return View(producto);
            }
            else
            {
                productoBL.AddProducto(producto);
            }

            return RedirectToAction("Index");
        }


        #endregion

        #region Editar


        public IActionResult Editar(int Id)

        {
            if (Id > 0)
            {
                ProductoCLS producto = productoBL.GetProductoId(Id);

                return View(producto);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Editar(ProductoCLS producto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(producto);
                }
                else
                {
                    if (producto.IdProducto > 0)
                    {
                        productoBL.EditarProducto(producto);
                    }
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        #endregion


        #region Eliminar

        [HttpPost]
        public IActionResult Borrar(int Id)
        {
            try
            {

                if (Id > 0)
                {
                    productoBL.EliminarProducto(Id);
                }


            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }

        #endregion

    }
}
