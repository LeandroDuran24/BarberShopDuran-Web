using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FacturarBLL
    {
        public static bool Guardar(Entidades.Facturas nuevo)
        {
            bool retono = false;
            using (var db = new BarberShopDb())
            {
                try
                {

                    foreach (var g in nuevo.servicioList)
                    {
                        db.Entry(g).State = System.Data.Entity.EntityState.Unchanged;
                    }


                    db.facturar.Add(nuevo);
                    db.SaveChanges();
                    retono = true;

                }
                catch (Exception)
                {

                    throw;
                }
                return retono;
            }

        }

        public static Entidades.Facturas Buscar(int id)
        {

            Entidades.Facturas nuevo;
            using (var db = new BarberShopDb())
            {
                try
                {
                    nuevo = db.facturar.Find(id);
                    nuevo.servicioList.Count();

                }
                catch (Exception)
                {

                    throw;
                }
                return nuevo;
            }
        }

        public static bool Eliminar(Entidades.Facturas id)
        {
            using (var db = new BarberShopDb())
            {
                try
                {
                    db.Entry(id).State = System.Data.Entity.EntityState.Deleted;
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public static List<Entidades.Facturas> GetListodo()
        {
            List<Entidades.Facturas> lista = new List<Entidades.Facturas>();
            using (var db = new BarberShopDb())
            {
                try
                {
                    lista = db.facturar.ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return lista;
            }
        }



    }
}
