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
        public static Reservaciones Guardar(Reservaciones nuevo)
        {
            Reservaciones retorno = null;
            using (var conn = new Repositorio<Reservaciones>())
            {
                retorno = conn.Guardar(nuevo);
            }
            return retorno;
        }

        public static Reservaciones Buscar(Expression<Func<Reservaciones, bool>> criterio)
        {
            Reservaciones retorno = null;
            using (var conn = new Repositorio<Reservaciones>())
            {
                retorno = conn.Buscar(criterio);
            }
            return retorno;

        }

        public static bool Modificar(Reservaciones criterio)
        {
            bool retorno = false;
            using (var conn = new Repositorio<Reservaciones>())
            {
                retorno = conn.Modificar(criterio);
            }
            return retorno;
        }

        public static bool Eliminar(Reservaciones criterio)
        {
            bool retorno = false;
            using (var conn = new Repositorio<Reservaciones>())
            {
                retorno = conn.Eliminar(criterio);
            }
            return retorno;
        }

        public static List<Reservaciones> GetList(Expression<Func<Reservaciones, bool>> criterio)
        {
            List<Reservaciones> lista = null;
            using (var conn = new Repositorio<Reservaciones>())
            {
                lista = conn.GetList(criterio).ToList();
            }
            return lista;
        }

        public static List<Reservaciones> GetListTodo()
        {
            List<Reservaciones> lista = null;
            using (var conn = new Repositorio<Reservaciones>())
            {
                lista = conn.GetListTodo().ToList();
            }

            return lista;
        }
    }
}
