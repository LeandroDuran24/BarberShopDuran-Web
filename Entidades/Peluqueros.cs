using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Peluqueros
    {
        [Key]
        public int idPeluquero { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string sexo { get; set; }
        public DateTime fecha { get; set; }
       
    }
}