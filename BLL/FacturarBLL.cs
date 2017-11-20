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
        public static Facturas Guardar(Facturas nuevo)
        {
            Facturas retorno = null;
            using (var conn = new Repositorio<Facturas>())
            {
                retorno = conn.Guardar(nuevo);

            }
            return retorno;
        }

        public static Facturas Buscar(Expression<Func<Facturas, bool>> criterio)
        {
            Facturas retorno = null;
            using (var conn = new Repositorio<Facturas>())
            {
                retorno = conn.Buscar(criterio);
                if (retorno != null)
                    retorno.servicioList.Count();
            }
            return retorno;

        }

        public static bool Eliminar(Facturas criterio)
        {
            bool retorno = false;
            using (var conn = new Repositorio<Facturas>())
            {
                retorno = conn.Eliminar(criterio);
            }
            return retorno;
        }

        public static bool Modificar(Facturas existente)
        {
            bool retorno = false;
            using (var db = new Repositorio<Facturas>())
            {
                retorno = db.Modificar(existente);
            }
            return retorno;
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

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> criterio)
        {
            List<Facturas> lista = null;
            using (var conn = new Repositorio<Facturas>())
            {
                lista = conn.GetList(criterio).ToList();
            }
            return lista;
        }




    }
}
