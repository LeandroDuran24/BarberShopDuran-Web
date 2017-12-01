using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Clientes
    {
        Entidades.Clientes cliente = new Entidades.Clientes();
        [TestMethod]
        public void Guardar()
        {


            cliente.nombre = "Juan Melena";
            cliente.apellidos = "Maria";
            cliente.cedula = "402-82936777";
            cliente.fecha = DateTime.Now;
            cliente.direccion = "Cenovi";
           


            Assert.IsNotNull(BLL.ClientesBLL.Guardar(cliente));

        }
        [TestMethod]
        public void Modificar()
        {
            cliente.idCliente = 4;
            cliente.nombre = "Juan Melena";
            cliente.apellidos = "perez";
            cliente.cedula = "402-82936777";
            cliente.fecha = DateTime.Now;
            cliente.direccion = "Cenovi";

            Assert.AreEqual(true, BLL.ClientesBLL.Modificar(cliente));
        }

        [TestMethod]
        public void Buscar()
        {
            bool busqueda = false;
            int id = 2;
            cliente = BLL.ClientesBLL.Buscar(p => p.idCliente == id);
            if (cliente != null)
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
            cliente.idCliente = 1;
            Assert.IsNotNull(BLL.ClientesBLL.Eliminar(cliente));
        }
    }
}
