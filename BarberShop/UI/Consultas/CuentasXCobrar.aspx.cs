using BarberShop.UI.Formularios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Consultas
{
    public partial class CuentasXCobrar : System.Web.UI.Page
    {
        public static DataTable Tabla { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
                Tabla = new DataTable();
            }
          
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=tcp:leandroduran.database.windows.net,1433;Initial Catalog=BarberShopDuran;Persist Security Info=False;User ID=leandroDuran24;Password=Leandro24;MultipleActiveResultSets=False;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False";

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;

            comando.CommandText = "Select fac.idFactura,cli.nombre as Nombre,ser.nombre as Servicio, fac.formaPago,fac.comentario,fac.descuento,fac.subTotal,fac.total,fac.usuario,fac.fecha from facturas fac left join detalles det on fac.idFactura=det.idFactura left join servicios ser on ser.idServicio=det.idServicio left join clientes cli on cli.idCliente=fac.idCliente  where fac.formaPago='Credito'";


            SqlDataAdapter sql = new SqlDataAdapter(comando);

            sql.Fill(Tabla);

            GridView1.DataSource = Tabla;
            GridView1.DataBind();
        }



        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
           

            string id = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
            Response.Redirect("../Formularios/FacturarForm.aspx?parametro=" + id);

        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteCuentas.aspx");
        }
    }
}