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
        public static List<Servicios> lista1 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Servicios servicio = new Servicios();
            //GridView1.DataSource = BLL.TiposSeviciosBLL.GetListTodo();
            //GridView1.DataBind();
            lista1 = BLL.TiposSeviciosBLL.GetListTodo();
        }

        public void SeleccionarCombo()
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                int id = Convert.ToInt32(TextBox1.Text);
                lista1 = BLL.TiposSeviciosBLL.GetList(p => p.idServicio == id);
                GridView1.DataSource = lista1;
                GridView1.DataBind();
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                if (TextBox1.Text == "")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Debe de Insertar el Nombre');</script>");
                }
                else
                {
                    lista1 = BLL.TiposSeviciosBLL.GetList(p => p.nombre == TextBox1.Text);
                   
                }


            }
            else if (DropDownList1.SelectedIndex == 2)
            {

                lista1 = BLL.TiposSeviciosBLL.GetListTodo();
              

            }

            GridView1.DataSource = lista1;
            GridView1.DataBind();
        }



        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            SeleccionarCombo();
        }
    }
}