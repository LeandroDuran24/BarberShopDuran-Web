using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Facturaciones
    {
        [Key]
        public int FacturaId { get; set; }



        public virtual List<Servicios> servicioList { get; set; }

        public Facturaciones()
        {
           servicioList = new List<Servicios>();
        }
    }
}
