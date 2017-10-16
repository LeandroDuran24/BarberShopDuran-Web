using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Formularios
{
    public partial class ReservacionForm : System.Web.UI.Page
    {
        Reservaciones reservacion = new Reservaciones();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ScriptPaginas.Script();
                this.FechaDesde.Text = string.Format("{0:G}", DateTime.Now);
                this.fechaHasta.Text = string.Format("{0:G}", DateTime.Now);
                LLenarComboCliente();
                LLenarComboPeluquero();



            }

        }

        public void LLenarComboCliente()
        {
            DropDownListCliente.DataSource = BLL.ClientesBLL.GetListTodo();
            DropDownListCliente.DataTextField = "nombre";
            DropDownListCliente.DataValueField = "idCliente";
            DropDownListCliente.DataBind();

        }

        public void LLenarComboPeluquero()
        {
            DropDownListPeluquero.DataSource = BLL.PeluqueroBll.GetListTodo();
            DropDownListPeluquero.DataTextField = "nombre";
            DropDownListPeluquero.DataValueField = "idPeluquero";
            DropDownListPeluquero.DataBind();

        }

        public Reservaciones LLenarCampos()
        {
            reservacion.idReservacion = Utilidades.TOINT(idTextbox.Text);
            reservacion.idCliente = Utilidades.TOINT(DropDownListCliente.SelectedValue.ToString());
            reservacion.idPeluquero = Utilidades.TOINT(DropDownListPeluquero.SelectedValue.ToString());
            reservacion.nombreCliente = DropDownListCliente.SelectedItem.ToString();
            reservacion.nombrePeluquero = DropDownListPeluquero.SelectedItem.ToString();
            reservacion.fechaDesde = Convert.ToDateTime(FechaDesde.Text);
            reservacion.fechaHasta = Convert.ToDateTime(fechaHasta.Text);
            return reservacion;
        }

        public void Limpiar()
        {
            idTextbox.Text = "";
            DropDownListCliente.DataSource = BLL.ClientesBLL.GetListTodo();
            DropDownListPeluquero.DataSource = "";
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                reservacion = LLenarCampos();
                if (reservacion.idReservacion != 0)
                {

                    BLL.ReservacionesBLL.Modificar(reservacion);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Se Ha Modificado Correctamente');</script>");
                }
                else
                {

                    BLL.ReservacionesBLL.Guardar(reservacion);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Se Guardo Correctamente');</script>");
                    Limpiar();


                }
            }
        }

        protected void Buscar_Click1(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idTextbox.Text);
            reservacion = BLL.ReservacionesBLL.Buscar(p => p.idReservacion == id);
            if (IsValid)
            {
                if (reservacion != null)
                {
                    DropDownListCliente.Text = reservacion.nombreCliente;
                    DropDownListPeluquero.Text = reservacion.nombrePeluquero;
                    FechaDesde.Text = Convert.ToString(reservacion.fechaDesde);
                    fechaHasta.Text = Convert.ToString(reservacion.fechaHasta);


                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No existe ese Registro');</script>");
                }
            }
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}