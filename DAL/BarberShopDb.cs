using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BarberShopDb:DbContext
    {
        public BarberShopDb():base("ConStr")
        {

        }

        public DbSet<Entidades.Usuarios>usuario { get; set; }
        public DbSet<Entidades.Servicios> servicio { get; set; }
        public DbSet<Entidades.Peluqueros> peluquero { get; set; }
        public DbSet<Entidades.Clientes> cliente { get; set; }
        public DbSet<Entidades.Reservaciones> reservacion { get; set; }
        public DbSet<Entidades.Facturaciones> facturar { get; set; }


    }
}
