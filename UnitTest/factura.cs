using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class factura
    {
        Entidades.Facturas facturas = new Entidades.Facturas();

        [TestMethod]
        public void Guardar()
        {


            facturas.comentario = "nada";
            facturas.descuento = 0;
            facturas.fecha = DateTime.Now;
            facturas.formaPago = "Credito";
            facturas.idCliente = 1;
            facturas.total = 0;
            facturas.subTotal = 0;

            Assert.IsNotNull(BLL.FacturarBLL.Guardar(facturas));

        }
        [TestMethod]
        public void Modificar()
        {
            facturas.idFactura = 2;
            facturas.comentario = "nada Qlok";
            facturas.descuento = 0;
            facturas.fecha = DateTime.Now;
            facturas.formaPago = "Credito";
            facturas.idCliente = 1;
            facturas.total = 0;
            facturas.subTotal = 0;

            Assert.AreEqual(true, BLL.FacturarBLL.Modificar(facturas));
        }

        [TestMethod]
        public void Buscar()
        {
            bool busqueda = false;
            int id = 2;
            facturas = BLL.FacturarBLL.Buscar(p => p.idFactura == id);
            if (facturas != null)
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
            facturas.idFactura = 1;
            Assert.IsNotNull(BLL.FacturarBLL.Eliminar(facturas));
        }
    }
}
