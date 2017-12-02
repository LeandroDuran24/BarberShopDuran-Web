using BarberShop.UI.Formularios;
using Entidades;
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
        public static List<Facturas> Lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
                string cadena = "Credito";
                Lista = BLL.FacturarBLL.GetList(p => p.formaPago == cadena);

            }
          
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
           


            string cadena = "Credito";
            Lista= BLL.FacturarBLL.GetList(p => p.formaPago == cadena);
            GridView1.DataSource = Lista;
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