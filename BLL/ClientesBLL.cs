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
    public class ClientesBLL
    {
        public static Entidades.Clientes Guardar(Clientes nuevo)
        {
            Clientes retorno = null;
            using (var conn = new Repositorio<Clientes>())
            {
                retorno = conn.Guardar(nuevo);
            }
            return retorno;
        }

        public static Clientes Buscar(Expression<Func<Clientes, bool>> criterio)
        {
            Clientes retorno = null;
            using (var conn = new Repositorio<Clientes>())
            {
                retorno = conn.Buscar(criterio);
            }
            return retorno;

        }

        public static bool Modificar(Clientes criterio)
        {
            bool retorno = false;
            using (var conn = new Repositorio<Clientes>())
            {
                retorno = conn.Modificar(criterio);
            }
            return retorno;
        }

        public static bool Eliminar(Clientes criterio)
        {
            bool retorno = false;
            using (var conn = new Repositorio<Clientes>())
            {
                retorno = conn.Eliminar(criterio);
            }
            return retorno;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = null;
            using (var conn = new Repositorio<Clientes>())
            {
                lista = conn.GetList(criterio).ToList();
            }
            return lista;
        }

        public static List<Clientes> GetListTodo()
        {
            List<Clientes> lista = null;
            using (var conn = new Repositorio<Clientes>())
            {
                lista = conn.GetListTodo().ToList();
            }

            return lista;
        }
    }
}
