using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Formularios
{
    public partial class FacturarForm : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrecioTextBox.Enabled = true;
            ServTextBox.Enabled = false;
            if (!Page.IsPostBack)
            {
                ScriptPaginas.Script();
                GridViewDetalle.DataSource = null;
                LLenarComboCliente();
               
            }


        }

        Facturas facturar = new Facturas();

        protected void Buscar_Click(object sender, EventArgs e)
        {

        }

        /*funcion para al dar enter en el codigo del producto busque el producto*/
        protected void CodTextBox_TextChanged(object sender, EventArgs e)
        {
            int idServicio = Utilidades.TOINT(CodTextBox.Text);
            Servicios servicio = BLL.TiposSeviciosBLL.Buscar(p => p.idServicio == idServicio);

            if (servicio != null)
            {
                ServTextBox.Text = servicio.nombre;
                PrecioTextBox.Text = Convert.ToString(servicio.costo);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "scripts", "<script>alert('No existe');</script>");
            }
        }

        /*llena la tabla al agregar algun servicio*/
        public void LlenarDataGridDetalle(Facturas nueva)
        {
            GridViewDetalle.DataSource = null;
            GridViewDetalle.DataSource = nueva.servicioList;
            GridViewDetalle.DataBind();

        }

        /*al dar click envia los datos al llenarDataGridDetalle*/
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

                facturar.servicioList.Add(servicios);
                LlenarDataGridDetalle(facturar);
            }
        }

        public Facturas LlenarCampos()
        {
            facturar.idCliente = Utilidades.TOINT(DropDownListClientes.SelectedValue.ToString());
            facturar.idFactura = Utilidades.TOINT(facturaIdTextBox.Text);
            facturar.formaPago = PagoTextBox.Text;
            facturar.descuento = Utilidades.TOINT(DescuentoTextBox.Text);
            facturar.itbis = Utilidades.TOINT(ItbisTextBox.Text);
            facturar.idServicio = Utilidades.TOINT(CodTextBox.Text);




            return facturar;
        }

        public void LLenarComboCliente()
        {
            List<Clientes> lista = BLL.ClientesBLL.GetListTodo();
            DropDownListClientes.DataSource = lista;
            DropDownListClientes.DataTextField = "nombre";
            DropDownListClientes.DataValueField = "idCliente";
            DropDownListClientes.DataBind();
        }

        protected void guardar_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                facturar = LlenarCampos();
                BLL.FacturarBLL.Guardar(facturar);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Se Guardo Correctamente');</script>");
            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Error');</script>");
            }
        }
    }
}