using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Reservacion
    {
        Entidades.Reservaciones reservacion = new Entidades.Reservaciones();
        [TestMethod]
        public void Guardar()
        {


            reservacion.idCliente = 1;
            reservacion.idPeluquero = 1;
            reservacion.nombreCliente = "Leandro";
            reservacion.nombrePeluquero = "TOny";
           


            Assert.IsNotNull(BLL.ReservacionesBLL.Guardar(reservacion));

        }
        [TestMethod]
        public void Modificar()
        {
            reservacion.idReservacion = 1;
            reservacion.idCliente = 1;
            reservacion.idPeluquero = 1;
            reservacion.nombreCliente = "Leandro";
            reservacion.nombrePeluquero = "Tony";


            Assert.AreEqual(true, BLL.ReservacionesBLL.Modificar(reservacion));
        }

        [TestMethod]
        public void Buscar()
        {
            bool busqueda = false;
            int id = 2;
            reservacion = BLL.ReservacionesBLL.Buscar(p => p.idReservacion == id);
            if (reservacion != null)
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
            reservacion.idCliente = 1;
            Assert.IsNotNull(BLL.ReservacionesBLL.Eliminar(reservacion));
        }
    }
}
