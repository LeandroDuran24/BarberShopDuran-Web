using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Consultas
{
    public partial class UsuariosCons : System.Web.UI.Page
    {
        public static List<Usuarios> lista { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            lista = BLL.UsuariosBLL.GetListTodo();
        }

        public void SeleccionarCombo()
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                if (TextBox1.Text == "")
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar Nombre", "error", "error");
                }
                else
                {
                    int id = Convert.ToInt32(TextBox1.Text);
                    lista = BLL.UsuariosBLL.GetList(p => p.idUsuario == id);
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
                    lista = BLL.UsuariosBLL.GetList(p => p.nombre == TextBox1.Text);

                }


            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                DateTime desde = Convert.ToDateTime(desdeFecha.Text);
                DateTime hasta = Convert.ToDateTime(desdeFecha.Text);

                if (desdeFecha.Text != "" && hastaFecha.Text != "")
                {
                    if (desde <= hasta)
                    {
                        lista = BLL.UsuariosBLL.GetList(p => p.fecha >= desde && p.fecha <= hasta);

                    }
                    else
                    {
                        Utilidades.MostrarToastr(this, "La Primera Fecha debe ser Menor que la Segunda Fecha", "error", "error");
                    }
                }
                else
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar las Fechas", "error", "error");
                }



            }
            else if (DropDownList1.SelectedIndex == 3)
            {

                lista = BLL.UsuariosBLL.GetListTodo();


            }
            GridView1.DataSource = lista;
            GridView1.DataBind();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SeleccionarCombo();
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteUsuarios.aspx");
        }
    }
}