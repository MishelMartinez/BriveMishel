using BriveExam.Clases;
using BriveExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriveExam.Data.Sucursal
{
    public class SucursalDL
    {

        public List<SucursalCLS> GetSucursals()
        {
            List<SucursalCLS> list = new List<SucursalCLS>();
            using (briveExamContext db = new briveExamContext())
            {
                list = (from branch in db.Sucursals
                        select new SucursalCLS
                        {
                            IdSucursal = branch.IdSucursal,
                            NombreSucursal = branch.NombreSucursal,
                            Direccion = branch.Direccion,
                            Telefono = branch.Telefono

                        }).ToList();

            }

            return list;
        }


        public void AddSucursal(SucursalCLS sucursal)
        {
            using (briveExamContext db = new briveExamContext())
            {
                BriveExam.Models.Sucursal model = new Models.Sucursal ();

                model.NombreSucursal = sucursal.NombreSucursal;
                model.Direccion = sucursal.Direccion;
                model.Telefono = sucursal.Telefono;

                db.Sucursals.Add(model);
                db.SaveChanges();

            }
        }



        public SucursalCLS GetSucursalId(int Id)
        {
            SucursalCLS sucursal = new SucursalCLS();
            using (briveExamContext db = new briveExamContext())
            {
                sucursal = (from s in db.Sucursals
                            where s.IdSucursal == Id
                            select new SucursalCLS
                            {
                                IdSucursal = s.IdSucursal,
                                NombreSucursal = s.NombreSucursal,
                                Direccion = s.Direccion,
                                Telefono = s.Telefono,
                                
                            }).First();
            }

            return sucursal;

        }
        public void EditarSucursal(SucursalCLS sucursal)
        {
            using (briveExamContext db = new briveExamContext())
            {
                BriveExam.Models.Sucursal model = db.Sucursals.Where(s => s.IdSucursal == sucursal.IdSucursal).First();
                model.NombreSucursal = sucursal.NombreSucursal;
                model.Direccion = sucursal.Direccion;
                model.Telefono = sucursal.Telefono;
                db.SaveChanges();
            }
        }

        public void EliminarSucursal(int Id)
        {
            using (briveExamContext db = new briveExamContext())
            {
                BriveExam.Models.Sucursal model = db.Sucursals.Where(s => s.IdSucursal == Id).First();
                db.Sucursals.Remove(model);
                db.SaveChanges();

            }
        }
    
    
    }
}
