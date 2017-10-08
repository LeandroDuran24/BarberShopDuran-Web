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
    public class TiposSeviciosBLL
    {
        public static Servicios Guardar(Servicios servicio)
        {
            Servicios retorno = null;
            using (var conn = new Repositorio<Servicios>())
            {
                retorno = conn.Guardar(servicio);
            }
            return retorno;
        }

        public static bool Modificar(Servicios servicio)
        {
            bool retorno = false;
            using (var conn = new Repositorio<Servicios>())
            {
                retorno = conn.Modificar(servicio);
            }
            return retorno;
        }

        public static bool Eliminar(Servicios servicio)
        {
            bool retorno = false;
            using (var conn = new Repositorio<Servicios>())
            {
                retorno = conn.Eliminar(servicio);
            }
            return retorno;
        }

        public static Servicios Buscar(Expression<Func<Servicios, bool>> servicio)
        {
            Servicios retorno = null;
            using (var conn = new Repositorio<Servicios>())
            {
                retorno = conn.Buscar(servicio);
            }
            return retorno;
        }

        public static List<Servicios> GetListTodo()
        {
            List<Servicios> lista = new List<Servicios>();
            using (var conn = new Repositorio<Servicios>())
            {
                lista = conn.GetListTodo().ToList();
            }
            return lista;
        }

        public static List<Servicios> GetList(Expression<Func<Servicios, bool>> servicio)
        {
            List<Servicios> lista = new List<Servicios>();
            using (var conn = new Repositorio<Servicios>())
            {
                lista = conn.GetList(servicio).ToList();
            }
            return lista;
        }
    }
}
