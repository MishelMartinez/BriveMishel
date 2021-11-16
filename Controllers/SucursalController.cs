using BriveExam.Business.BL.Sucursal;
using BriveExam.Clases;
using BriveExam.Data.Sucursal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Controllers
{
    public class SucursalController : Controller
    {
        private SucursalBL sucursalBL;


        public SucursalController()
        {
            sucursalBL = new SucursalBL();
        }
        public IActionResult Index()
        {
            List<SucursalCLS> list = sucursalBL.GetBranchOfficesBM();

            return View(list);
        }

        #region Agregar Sucursal
        public IActionResult Agregar()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Agregar(SucursalCLS sucursal)
        {
            if (!ModelState.IsValid)
            {


                return View(sucursal);
            }
            else
            {
                sucursalBL.AddSucursal(sucursal);
            }

            return RedirectToAction("Index");
        }


        #endregion

        #region Editar


        public IActionResult Editar(int Id)

        {
            if (Id > 0)
            {
                SucursalCLS sucursal = sucursalBL.GetSucursalId(Id);

                return View(sucursal);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Editar(SucursalCLS sucursal)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(sucursal);
                }
                else
                {
                    if (sucursal.IdSucursal > 0)
                    {
                       sucursalBL.EditarSucursal(sucursal);
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
                        sucursalBL.EliminarSucursal(Id);
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
