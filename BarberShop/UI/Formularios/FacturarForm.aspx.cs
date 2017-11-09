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
        
        Facturas facturar;
        protected void Page_Load(object sender, EventArgs e)
        {
            facturar = new Facturas();
            if (!this.IsPostBack)
            {
                this.LabelFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                this.LabelAtentido.Text = LogIn.LabelUsuario().nombre;
                this.LabelAtentido.Visible = true;

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
            facturar.itbis = Utilidades.TOINT(ItbisTextBox.Text);
            facturar.comentario = ComentarioTextBox.Text;
            facturar.subTotal = Utilidades.TOINT(SubTextBox.Text);
            facturar.total = Utilidades.TOINT(TotalTextBox.Text);
            facturar.usuario = LogIn.LabelUsuario().nombre;
            facturar.fecha = Convert.ToDateTime(LabelFecha.Text);
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
            ItbisTextBox.Text = "";
            SubTextBox.Text = "";
            TotalTextBox.Text = "";
            RecibidoTextBox.Text = "";
            DevueltaTextBox.Text = "";
            GridViewDetalle.DataSource = null;
            GridViewDetalle.DataBind();
        }

        /*calcular el monto total del costo de los servicios*/
        public void CalcularMonto()
        {
            decimal subTotal = 0.000m;

            if (GridViewDetalle.Rows.Count > 0)
            {
                foreach (GridViewRow precio in GridViewDetalle.Rows)
                {
                    subTotal += Convert.ToDecimal(precio.Cells[0].Text);
                    SubTextBox.Text = subTotal.ToString();
                }
            }

            for (int i = 0; i < GridViewDetalle.Rows.Count; i++)
            {
                subTotal += Utilidades.TOINT(GridViewDetalle.Rows[i].Cells[i + 1].Text);
                SubTextBox.Text = subTotal.ToString();
            }
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

                }
            }

            if (servicios != null && anadido == false)
            {
                facturar.servicioList = (List<Servicios>)Session["DetalleServicios"];

                facturar.servicioList.Add(servicios);
                Session["DetalleServicios"] = facturar.servicioList;

                GridViewDetalle.DataSource = (List<Servicios>)Session["DetalleServicios"];
                GridViewDetalle.DataBind();


                // CalcularMonto();

                CodTextBox.Text = "";
                ServTextBox.Text = "";
                PrecioTextBox.Text = "";



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
            int id = Utilidades.TOINT(facturaIdTextBox.Text);
            facturar = BLL.FacturarBLL.Buscar(id);

            if (facturar != null)
            {

                PagoTextBox.Text = facturar.formaPago;
                DescuentoTextBox.Text = Convert.ToString(facturar.descuento);
                ItbisTextBox.Text = Convert.ToString(facturar.itbis);
                ComentarioTextBox.Text = Convert.ToString(facturar.comentario);
                SubTextBox.Text = Convert.ToString(facturar.subTotal);
                TotalTextBox.Text = Convert.ToString(facturar.total);
                LogIn.LabelUsuario().nombre = facturar.usuario;

                GridViewDetalle.DataSource = facturar.servicioList;
                GridViewDetalle.DataBind();
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
    }
}