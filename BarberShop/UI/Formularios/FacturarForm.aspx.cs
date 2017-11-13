using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Formularios
{
    public partial class FacturarForm : Page
    {

        Facturas facturar = new Facturas();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {


                //this.LabelFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                //this.LabelAtentido.Text = LogIn.LabelUsuario().nombre;
                //this.LabelAtentido.Visible = true;

                ScriptPaginas.Script();
                GridViewDetalle.DataSource = null;
                LLenarComboCliente();

                Session["DetalleServicios"] = new List<Servicios>();



            }


        }

        /*llenar las instancia*/
        public Facturas LlenarCampos()
        {
            facturar.idCliente = Utilidades.TOINT(DropDownListClientes.SelectedValue.ToString());
            facturar.idFactura = Utilidades.TOINT(facturaIdTextBox.Text);
            facturar.formaPago = PagoTextBox.Text;
            facturar.descuento = Utilidades.TOINT(DescuentoTextBox.Text);
            facturar.comentario = ComentarioTextBox.Text;
            facturar.subTotal = Utilidades.TOINT(SubTextBox.Text);
            facturar.total = Utilidades.TOINT(TotalTextBox.Text);
            //facturar.usuario = LogIn.LabelUsuario().nombre;
            //facturar.fecha = Convert.ToDateTime(LabelFecha.Text);
            facturar.servicioList = (List<Servicios>)Session["DetalleServicios"];


            return facturar;
        }
        /*llenar el comboBox del cliente*/
        public void LLenarComboCliente()
        {
            List<Clientes> lista = BLL.ClientesBLL.GetListTodo();
            DropDownListClientes.DataSource = lista;
            DropDownListClientes.DataTextField = "nombre";
            DropDownListClientes.DataValueField = "idCliente";
            DropDownListClientes.DataBind();

        }
        /*limpia los campos*/
        public void Limpiar()
        {
            facturaIdTextBox.Text = "";
            PagoTextBox.Text = "";
            ComentarioTextBox.Text = "";
            DescuentoTextBox.Text = "";
            CodTextBox.Text = "";
            ServTextBox.Text = "";
            PrecioTextBox.Text = "";
            SubTextBox.Text = "";
            TotalTextBox.Text = "";
            RecibidoTextBox.Text = "";
            DevueltaTextBox.Text = "";

            GridViewDetalle.DataSource = null;
            GridViewDetalle.DataBind();

            ;
        }

        /*calcular el monto total del costo de los servicios*/
        public void CalcularMonto()
        {
            decimal subTotal = 0m;
            decimal descuento = 0;
            decimal total = 0;
            int porciento = 100;

            if (GridViewDetalle.Rows.Count > 0)
            {
                foreach (GridViewRow precio in GridViewDetalle.Rows)
                {
                    subTotal += Convert.ToDecimal(precio.Cells[2].Text);
                    SubTextBox.Text = subTotal.ToString();
                }
            }
            descuento = (Convert.ToDecimal(DescuentoTextBox.Text) / porciento) * Convert.ToDecimal(SubTextBox.Text);
            total = subTotal - descuento;
            TotalTextBox.Text = total.ToString();

        }


        /*boton que agrega los servicios al grid*/
        protected void ButtonAgregarServiciosGrid_Click1(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(CodTextBox.Text);
            Servicios servicios = BLL.TiposSeviciosBLL.Buscar(p => p.idServicio == id);
            bool anadido = false;

            if (servicios != null)
            {
                foreach (var service in facturar.servicioList)
                {
                    if (service.idServicio == servicios.idServicio)
                    {
                        anadido = true;

                    }
                    else
                    {
                        anadido = false;
                    }

                }
            }

            if (servicios != null && anadido == false)
            {
                facturar.servicioList = (List<Servicios>)Session["DetalleServicios"];

                facturar.servicioList.Add(servicios);
                Session["DetalleServicios"] = facturar.servicioList;



                GridViewDetalle.DataSource = (List<Servicios>)Session["DetalleServicios"];
                GridViewDetalle.DataBind();



                CalcularMonto();

                CodTextBox.Text = "";
                ServTextBox.Text = "";
                PrecioTextBox.Text = "";
                CodTextBox.Focus();




            }
            else if (servicios != null && anadido == true)
            {
                Utilidades.MostrarToastr(this, "Ya Esta Agregado", "info", "info");
            }
        }

        /*boton guardar*/
        protected void guardar_Click(object sender, EventArgs e)
        {


            facturar = LlenarCampos();

            BLL.FacturarBLL.Guardar(facturar);
            Utilidades.MostrarToastr(this, "Guardado", "success", "success");
            Limpiar();


        }

        /*boton para limpiar*/
        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /*boton buscar*/
        protected void Buscar_Click(object sender, EventArgs e)
        {
            Facturas fac = new Facturas();
            int id = Utilidades.TOINT(facturaIdTextBox.Text);
            fac = BLL.FacturarBLL.Buscar(p => p.idFactura == id);

            if (fac != null)
            {
                PagoTextBox.Text = fac.formaPago;
                DescuentoTextBox.Text = Convert.ToString(fac.descuento);
                ComentarioTextBox.Text = fac.comentario;
                SubTextBox.Text = Convert.ToString(fac.subTotal);
                TotalTextBox.Text = Convert.ToString(fac.total);
                
                Utilidades.MostrarToastr(this, " Existe", "error", "error");

            }
            else
            {
                Utilidades.MostrarToastr(this, "No Existe", "error", "error");
                Limpiar();
            }
        }

        protected void ButtonAgregarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Formularios/ClientesForm.aspx");
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            //int id = Utilidades.TOINT(facturaIdTextBox.Text);
            //facturar = BLL.FacturarBLL.Buscar(p=> p.idFactura==id);

            //if (facturar != null)
            //{
            //    BLL.FacturarBLL.Eliminar(facturar);
            //    Utilidades.MostrarToastr(this, "Eliminado", "success", "success");
            //}
        }
    }
}