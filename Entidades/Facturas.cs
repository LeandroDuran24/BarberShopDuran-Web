using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Facturas
    {
        [Key]
        public int idFactura{get; set; }
        public int idCliente { get; set; }
        public string formaPago { get; set; }
        public string comentario { get; set; }
        public int descuento { get; set; }
        public float subTotal { get; set; }
        public float  total { get; set; }
        public string usuario { get; set; }
        public DateTime fecha { get; set; }



        public virtual List<Servicios> servicioList { get; set; }

        public Facturas()
        {
           this.servicioList = new List<Servicios>();
        }

    }
}
