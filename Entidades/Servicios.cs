using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entidades
{
    public class Servicios
    {
        [Key]
        public int idServicio { get; set; }
        public string nombre { get; set; }
        public int costo { get; set; }
    }
}