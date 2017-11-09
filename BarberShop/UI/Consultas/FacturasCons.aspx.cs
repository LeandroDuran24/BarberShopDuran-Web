using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Consultas
{
    public partial class FacturasCons : System.Web.UI.Page
    {

        public static List<Facturas> lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                lista = BLL.FacturarBLL.GetListodo();
            }

        }


        public void SeleccionarCombo()
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                int id = Convert.ToInt32(TextBox1.Text);
                lista = BLL.FacturarBLL.GetList(p => p.idFactura == id);

            }
           
            //else if (DropDownList1.SelectedIndex == 2)
            //{
            //    DateTime desde = Convert.ToDateTime(desdeFecha.Text);
            //    DateTime hasta = Convert.ToDateTime(desdeFecha.Text);

            //    if (desdeFecha.Text != "" && hastaFecha.Text != "")
            //    {
            //        if (desde <= hasta)
            //        {
            //            lista = BLL.FacturarBLL.GetList(p => p.fecha >= desde && p.fecha <= hasta);

            //        }
            //        else
            //        {
            //            Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('La Primera Fecha debe ser Menor a la Segunda Fecha');</script>");
            //        }
            //    }
            //    else
            //    {
            //        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Debe de Insertar el Intervalo de Fecha');</script>");
            //    }



            //}
            else if (DropDownList1.SelectedIndex == 3)
            {

                lista = BLL.FacturarBLL.GetListodo();


            }
            GridView1.DataSource = lista;
            GridView1.DataBind();


        }



        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            SeleccionarCombo();
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {

        }
    }
}