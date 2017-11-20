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
        Reservaciones peluquero = new Reservaciones();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ScriptPaginas.Script();
                Limpiar();

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
            reservacion.fechaDesde = TimeSpan.Parse(FechaDesde.Text);
            reservacion.fechaHasta = TimeSpan.Parse(fechaHasta.Text);
            reservacion.fecha = Convert.ToDateTime(FechaTextbox.Text);
            return reservacion;


        }

        public void Limpiar()
        {
            idTextbox.Text = "";
            DropDownListCliente.DataSource = BLL.ClientesBLL.GetListTodo();
            DropDownListPeluquero.DataSource = "";
            FechaDesde.Text = "";
            fechaHasta.Text = "";
            FechaTextbox.Text = DateTime.Now.ToString("dd/MM/yyyy");



        }


        protected void guardar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                reservacion = LLenarCampos();
                if (reservacion.idReservacion != 0)
                {

                    BLL.ReservacionesBLL.Modificar(reservacion);
                    Utilidades.MostrarToastr(this, "Modificado", "info", "info");
                }
                else
                {
                    string pel = DropDownListPeluquero.SelectedItem.ToString();
                    peluquero = BLL.ReservacionesBLL.Buscar(p => p.nombrePeluquero == pel);

                    if (peluquero != null)
                    {
                        TimeSpan desde = TimeSpan.Parse(FechaDesde.Text);
                        Reservaciones desdeHr = BLL.ReservacionesBLL.Buscar(p => p.fechaDesde == desde);
                        if (desdeHr == null)
                        {
                            TimeSpan hasta = TimeSpan.Parse(fechaHasta.Text);
                            Reservaciones hastaHr = BLL.ReservacionesBLL.Buscar(p => p.fechaHasta == hasta);

                            if (hastaHr == null)
                            {
                                DateTime fecha = Convert.ToDateTime(FechaTextbox.Text);
                                Reservaciones fechas = BLL.ReservacionesBLL.Buscar(p => p.fecha == fecha);

                                if (fechas == null)
                                {
                                    BLL.ReservacionesBLL.Guardar(reservacion);
                                    Utilidades.MostrarToastr(this, "Guardado", "success", "success");
                                    Limpiar();
                                }
                                else if (hastaHr == null && desdeHr == null && fechas != null)
                                {
                                    BLL.ReservacionesBLL.Guardar(reservacion);
                                    Utilidades.MostrarToastr(this, "Guardado", "success", "success");
                                    Limpiar();

                                }
                                else
                                {
                                    Utilidades.MostrarToastr(this, "Ocupado", "Error", "Error");
                                    Limpiar();
                                }

                            }
                            else
                            {

                                Utilidades.MostrarToastr(this, "Ocupado", "Error", "Error");
                                Limpiar();
                            }
                        }
                        else
                        {
                            Utilidades.MostrarToastr(this, "Ocupado", "Error", "Error");
                            Limpiar();
                        }
                    }
                    else
                    {
                        BLL.ReservacionesBLL.Guardar(reservacion);
                        Utilidades.MostrarToastr(this, "Guardado", "success", "success");
                        Limpiar();
                    }





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

                    //DropDownListCliente.Text = reservacion.nombreCliente;
                    //DropDownListPeluquero.Text = reservacion.nombrePeluquero;
                    FechaDesde.Text = Convert.ToString(reservacion.fechaDesde);
                    fechaHasta.Text = Convert.ToString(reservacion.fechaHasta);
                    FechaTextbox.Text = Convert.ToString(reservacion.fecha);


                }
                else
                {
                    Utilidades.MostrarToastr(this, "No Existe", "Error", "Error");
                    Limpiar();
                }

            }
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}