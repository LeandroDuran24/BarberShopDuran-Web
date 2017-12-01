using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Usuarios
    {
        Entidades.Usuarios usuario = new Entidades.Usuarios();
        [TestMethod]
        public void Guardar()
        {


            usuario.nombre = "Maria";
            usuario.tipoEmail = "Admin";
            usuario.fecha = DateTime.Now;
            usuario.confirmar = "12345";
            usuario.clave = "12345";
            usuario.email = "Maria12";


            Assert.IsNotNull(BLL.UsuariosBLL.Guardar(usuario));

        }
        [TestMethod]
        public void Modificar()
        {
            usuario.idUsuario = 2;
            usuario.nombre = "Maria";
            usuario.tipoEmail = "Admin";
            usuario.fecha = DateTime.Now;
            usuario.confirmar = "12345";
            usuario.clave = "12345";
            usuario.email = "Maria12";


            Assert.IsNotNull(BLL.UsuariosBLL.Mofidicar(usuario));
        }

        [TestMethod]
        public void Buscar()
        {
            bool busqueda = false;
            int id = 2;
            usuario = BLL.UsuariosBLL.Buscar(p => p.idUsuario == id);
            if (usuario != null)
            {
                busqueda = true;
            }
            else
            {
                busqueda = false;
            }

            Assert.IsTrue(busqueda);
        }

        [TestMethod]
        public void Eliminar()
        {
            bool busqueda = false;
            usuario.idUsuario = 2;
            Assert.IsNotNull(BLL.UsuariosBLL.Eliminar(usuario));
        }
    }
}
