using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Reservaciones
    {
        [Key]
        public int idReservacion{ get; set; }
        public int idCliente { get; set; }
        public int idPeluquero { get; set; }
        public string nombreCliente { get; set; }
        public string nombrePeluquero { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
    }
}
