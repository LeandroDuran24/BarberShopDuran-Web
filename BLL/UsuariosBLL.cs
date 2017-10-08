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
    public class UsuariosBLL
    {

        public static Usuarios Guardar(Usuarios nuevo)
        {
            Usuarios retorno = null;
            using (var conn = new DAL.Repositorio<Usuarios>())
            {
                retorno = conn.Guardar(nuevo);
            }
            return retorno;
        }

        public static Usuarios Buscar(Expression<Func<Usuarios, bool>> tipo)
        {
            Usuarios Result = null;
            using (var repositorio = new Repositorio<Usuarios>())
            {
                Result = repositorio.Buscar(tipo);



            }
            return Result;
        }



        public static bool Mofidicar(Usuarios criterio)
        {
            bool mod = false;
            using (var db = new Repositorio<Usuarios>())
            {
                mod = db.Modificar(criterio);
            }

            return mod;

        }

        public static bool Eliminar(Usuarios existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Usuarios>())
            {
                eliminado = repositorio.Eliminar(existente);
            }

            return eliminado;

        }

        public static List<Usuarios> GetList(Expression<Func<Usuarios, bool>> criterio)
        {
            List<Usuarios> retorno = null;
            using (var conn = new Repositorio<Usuarios>())
            {
                try
                {
                    retorno = conn.GetList(criterio).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return retorno;
            }

        }

        public static List<Usuarios> GetListTodo()
        {
            List<Usuarios> retorno = null;
            using (var conn = new Repositorio<Usuarios>())
            {
                try
                {
                    retorno = conn.GetListTodo().ToList();

                }
                catch (Exception)
                {

                    throw;
                }
                return retorno;
            }

        }
    }
}
