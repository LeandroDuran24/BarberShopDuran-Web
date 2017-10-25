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
            ScriptPaginas.Script();
            GridViewDetalle.DataSource = null;

        }

        Facturaciones facturar = new Facturaciones();

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
        public void LlenarDataGridDetalle(Facturaciones nueva)
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
                        Page.ClientScript.RegisterStartupScript(GetType(), "scripts", "<script>alert('Añadido');</script>");

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "scripts", "<script>alert(' No Añadido');</script>");
                    }
                }
            }


            if (servicios != null && anadido == false)
            {

                facturar.servicioList.Add(servicios);
                LlenarDataGridDetalle(facturar);
            }
        }
    }
}