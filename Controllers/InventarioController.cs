using BriveExam.Business.BL.Inventario;
using BriveExam.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Controllers
{
    public class InventarioController : Controller
    {
        private InventarioBL inventarioBL;

        public InventarioController()
        {
            inventarioBL = new InventarioBL();
        }

        public void GetTable()
        {
            List<InventarioCLS> list = inventarioBL.GetInventorio();
            ViewBag.listTable = list;
        }

         public IActionResult Index(InventarioCLS inventario)
        {
            if(inventario.selectSucursal == null)
            {
                GetTable();
                GetSucursales();
               
               
            }
            else
            {
                GetTableParameters(inventario);
            }
            return View(inventario);
        }

        void GetTableParameters(InventarioCLS inventario)
        {
            List<InventarioCLS> list = inventarioBL.GetInventorio();
            List<InventarioCLS> listTem = new List<InventarioCLS>();

            listTem = list.Where(p => p.IdSucursal == int.Parse(inventario.selectSucursal)).ToList();
            ViewBag.listTable = listTem;
            GetSucursales();

        }

        #region Agregar
        public IActionResult Agregar()
        {
            GetSucursales();
            GetProductos();
            return View();
        }

        public void GetSucursales()
        {
            List<SucursalCLS> list = inventarioBL.GetSucursals();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in list)
            {
                listItems.Insert(0, new SelectListItem
                {
                    Text = x.NombreSucursal,
                    Value = x.IdSucursal.ToString()
                });
            }


            listItems.Insert(0, new SelectListItem
            {
                Text = "Seleccionar",
                Value = ""
            });

            ViewBag.listBranch = listItems;
        }


        public void GetProductos()
        {
            List<ProductoCLS> list = inventarioBL.GetProductos();
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var x in list)
            {
                listItems.Insert(0, new SelectListItem
                {
                    Text = x.NombreProducto,
                    Value = x.IdProducto.ToString()
                });
            }


            listItems.Insert(0, new SelectListItem
            {
                Text = "Seleccionar",
                Value = ""
            });

            ViewBag.listProducts = listItems;
        }


        [HttpPost]

        public IActionResult Agregar(InventarioCLS model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    GetSucursales();
                    GetProductos();

                    return View(model);
                }
                else
                {
                    inventarioBL.AddInventario(model);
                }
            }
            catch
            {
                return View(model);
            }

            return RedirectToAction("Index");

        }

        #endregion

        #region Editar
        public IActionResult Editar(int Id)

        {
            if (Id > 0)
            {
                GetSucursales();
                GetProductos();
                InventarioCLS inventario = inventarioBL.GetInventarioId(Id);

                return View(inventario);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(InventarioCLS inventario)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(inventario);
                }
                else
                {
                    if (inventario.IdProducto > 0)
                    {
                        inventarioBL.EditarInventario(inventario);
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
                    inventarioBL.EliminarInventario(Id);
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
