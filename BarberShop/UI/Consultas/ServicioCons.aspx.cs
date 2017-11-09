using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Consultas
{
    public partial class ServicioCons : System.Web.UI.Page
    {
        public static List<Servicios> lista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Servicios servicio = new Servicios();
          
            lista = BLL.TiposSeviciosBLL.GetListTodo();
        }

        public void SeleccionarCombo()
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                if(TextBox1.Text=="")
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar Id", "error", "error");
                }
                else
                {
                    int id = Convert.ToInt32(TextBox1.Text);
                    lista = BLL.TiposSeviciosBLL.GetList(p => p.idServicio == id);
                   
                }
               
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                if (TextBox1.Text == "")
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar Nombre", "error", "error");
                }
                else
                {
                    lista = BLL.TiposSeviciosBLL.GetList(p => p.nombre == TextBox1.Text);
                   
                }


            }
            else if (DropDownList1.SelectedIndex == 2)
            {

                lista = BLL.TiposSeviciosBLL.GetListTodo();
              

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
            Response.Redirect("../Reportes/ReporteServicios.aspx");
        }
    }
}