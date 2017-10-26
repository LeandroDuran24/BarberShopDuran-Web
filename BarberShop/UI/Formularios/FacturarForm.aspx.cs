using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Formularios
{
    public partial class FacturarForm : Page
    {
        DataTable dt = new DataTable();
        Facturas facturar;
        protected void Page_Load(object sender, EventArgs e)
        {
            facturar = new Facturas();
            if (!Page.IsPostBack)
            {
                this.LabelFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                this.LabelAtentido.Text = LogIn.LabelUsuario().nombres;
                this.LabelAtentido.Visible = true;

                ScriptPaginas.Script();
                GridViewDetalle.DataSource = null;
                LLenarComboCliente();


                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Nombre del Servicio"), new DataColumn("Costo") });

                ViewState["FacturarForm"] = dt;


            }


        }


        protected void BindGrid()
        {
            GridViewDetalle.DataSource = (DataTable)ViewState["FacturarForm"];
            GridViewDetalle.DataBind();
        }







        ///*llena la tabla al agregar algun servicio*/
        //public void LlenarDataGridDetalle(Facturas nueva)
        //{
        //    GridViewDetalle.DataSource = null;

        //    GridViewDetalle.DataSource = nueva.servicioList;
        //    GridViewDetalle.DataBind();

        //}

        /*al dar click envia los datos al llenarDataGridDetalle*/


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
            facturar.usuario = LogIn.LabelUsuario().nombres;

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
        }
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
                //LlenarDataGridDetalle(facturar);
                DataTable dt = (DataTable)ViewState["FacturarForm"];
                dt.Rows.Add(ServTextBox.Text, PrecioTextBox.Text);

                ViewState["FacturarForm"] = dt;
                this.BindGrid();

                CodTextBox.Text = "";
                ServTextBox.Text = "";
                PrecioTextBox.Text = "";


            }
        }
        protected void guardar_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                facturar = LlenarCampos();
                BLL.FacturarBLL.Guardar(facturar);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Se Guardo Correctamente');</script>");
                Limpiar();
            }

           
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

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

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
                LogIn.LabelUsuario().nombres = facturar.usuario;


            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "scripts", "<script>alert('No existe');</script>");
                Limpiar();
            }
        }
    }
}