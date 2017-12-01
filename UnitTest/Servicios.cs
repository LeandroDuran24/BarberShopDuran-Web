using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class Servicios
    {
        Entidades.Servicios servicio = new Entidades.Servicios();

        [TestMethod]
        public void Guardar()
        {
            
           
            servicio.nombre = "Diseño";
            servicio.costo = 200;

    
            Assert.IsNotNull(BLL.TiposSeviciosBLL.Guardar(servicio));

        }
        [TestMethod]
        public void Modificar()
        {

            servicio.idServicio = 1;
            servicio.nombre = "Diseño Con raya";
            servicio.costo = 200;

            Assert.AreEqual(true, BLL.TiposSeviciosBLL.Modificar(servicio));
        }

        [TestMethod]
        public void Buscar()
        {
            bool busqueda = false;
            int id = 2;
            servicio = BLL.TiposSeviciosBLL.Buscar(p => p.idServicio == id);
            if (servicio != null)
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
            servicio.idServicio = 1;
            Assert.IsNotNull( BLL.TiposSeviciosBLL.Eliminar(servicio));
        }
    }
}
