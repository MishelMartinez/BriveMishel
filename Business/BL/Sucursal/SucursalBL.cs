using BriveExam.Clases;
using BriveExam.Data.Sucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Business.BL.Sucursal
{
    public class SucursalBL
    {

        private SucursalDL sucursalDL;


        public SucursalBL()
        {
            sucursalDL = new SucursalDL();
        }


        public List<SucursalCLS> GetBranchOfficesBM()
        {
            List<SucursalCLS> list = new List<SucursalCLS>();
            list = sucursalDL.GetSucursals();
            return list;



        }


        public void AddSucursal(SucursalCLS sucursal)
        {
            sucursalDL.AddSucursal(sucursal);
        }


        public SucursalCLS GetSucursalId(int Id)
        {
            return sucursalDL.GetSucursalId(Id);
        }

            public void EditarSucursal(SucursalCLS sucursal)
        {
            sucursalDL.EditarSucursal(sucursal);
        }

        public void EliminarSucursal(int Id)
        {
            sucursalDL.EliminarSucursal(Id);
        }
    }
}
