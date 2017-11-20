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
            facturar.formaPago = DropDownListPago.SelectedValue.ToString();
            facturar.descuento = Utilidades.TOINT(DescuentoTextBox.Text);
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
            //Leandro pues yo no me explico.. eso esta raro porq todo esta nitido
            //para mi que es la magia de entity haciendo tollos.. yo lo q puedo dejar eso asi y ya enel q se ponga a probar 1 x 1
            //Vamos a preguntarle por el grupo

        }
        /*limpia los campos*/
        public void Limpiar()
        {
            facturaIdTextBox.Text = "";
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
            //int devuelta = 0;

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

            //devuelta = Utilidades.TOINT(RecibidoTextBox.Text) - Convert.ToInt16(total);
            //DevueltaTextBox.Text = devuelta.ToString();




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
            int total = 0;
            int recibido = 0;

            if (DropDownListPago.Text == "Contado")
            {
                total = Utilidades.TOINT(TotalTextBox.Text);
                recibido = Utilidades.TOINT(RecibidoTextBox.Text);
                if (total > recibido)
                {
                    Utilidades.MostrarToastr(this, "No se Puede Realizar Compra, Realice el Pago Correctamente", "info", "info");
                    RecibidoTextBox.Text = "";
                }
                else
                {
                    facturar = LlenarCampos();
                    if (facturar.idFactura!=0)
                    {
                        BLL.FacturarBLL.Modificar(facturar);
                        Utilidades.MostrarToastr(this, "Modificado", "info", "info");

                    }
                    else
                    {


                        BLL.FacturarBLL.Guardar(facturar);
                        Utilidades.MostrarToastr(this, "Guardado", "success", "success");
                        Limpiar();
                    }


                }

            }


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
                DescuentoTextBox.Text = Convert.ToString(fac.descuento);
                ComentarioTextBox.Text = fac.comentario;
                SubTextBox.Text = Convert.ToString(fac.subTotal);
                TotalTextBox.Text = Convert.ToString(fac.total);
                //GridViewDetalle.DataSource = fac.servicioList;
                //GridViewDetalle.DataBind();



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
            int id = Utilidades.TOINT(facturaIdTextBox.Text);
            facturar = BLL.FacturarBLL.Buscar(p => p.idFactura == id);

            if (facturar != null)
            {
                BLL.FacturarBLL.Eliminar(facturar);
                Utilidades.MostrarToastr(this, "Eliminado", "success", "success");
                Limpiar();
            }
            else
            {
                Utilidades.MostrarToastr(this, "error", "error", "error");
            }
        }

        protected void ImageButtonSearch_Click(object sender, ImageClickEventArgs e)
        {
            if (CodTextBox.Text != "")
            {
                int id = Utilidades.TOINT(CodTextBox.Text);
                Servicios servicio = BLL.TiposSeviciosBLL.Buscar(p => p.idServicio == id);

                if (servicio != null)
                {

                    ServTextBox.Text = servicio.nombre;
                    PrecioTextBox.Text = Convert.ToString(servicio.costo);


                }
                else
                {
                    Utilidades.MostrarToastr(this, "No Existe", "error", "error");
                    CodTextBox.Text = "";
                }
            }
            else
            {
                Utilidades.MostrarToastr(this, "Favor Llenar el Codigo", "error", "error");
                CodTextBox.Focus();
            }




        }
    }
}