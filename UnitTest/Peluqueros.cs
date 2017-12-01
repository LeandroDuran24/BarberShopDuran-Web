using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Peluqueros
    {
        Entidades.Peluqueros peluquero = new Entidades.Peluqueros();
        [TestMethod]
        public void Guardar()
        {


            peluquero.nombre = "Juan Melena";
            peluquero.sexo = "Masculino";
            peluquero.telefono = "8293677767";
            peluquero.fecha = DateTime.Now;


            Assert.IsNotNull(BLL.PeluqueroBll.Guardar(peluquero));

        }
        [TestMethod]
        public void Modificar()
        {
            peluquero.idPeluquero = 2;
            peluquero.nombre = "Juan Melena Maria";
            peluquero.sexo = "Masculino";
            peluquero.telefono = "8293677767";
            peluquero.fecha = DateTime.Now;

            Assert.AreEqual(true, BLL.PeluqueroBll.Modificar(peluquero));
        }

        [TestMethod]
        public void Buscar()
        {
            bool busqueda = false;
            int id = 2;
            peluquero = BLL.PeluqueroBll.Buscar(p => p.idPeluquero == id);
            if (peluquero != null)
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
            peluquero.idPeluquero = 1;
            Assert.IsNotNull(BLL.PeluqueroBll.Eliminar(peluquero));
        }
    }
}
