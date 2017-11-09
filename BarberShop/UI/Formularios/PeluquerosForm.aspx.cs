using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Formularios
{
    public partial class PeluquerosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
               // FechaTextBox1.Text = string.Format("{0:G}", DateTime.Now);
                ScriptPaginas.Script();

            }
 
        }

        Peluqueros peluquero = new Peluqueros();

        public Peluqueros llenarCampos()
        {
            peluquero.idPeluquero = Utilidades.TOINT(idTextbox.Text);
            peluquero.nombre = NombreTextbox.Text;
            peluquero.telefono = TelefonoTextBox.Text;
           if(DropDownList1.SelectedIndex==0)
            {
                peluquero.sexo = "Masculino";
            }
           else if(DropDownList1.SelectedIndex==1)
            {
                peluquero.sexo = "Femenino";
            }
           
            peluquero.fecha = Convert.ToDateTime(FechaTextBox1.Text);

            return peluquero;
        }

        public void limpiar()
        {
            idTextbox.Text = "";
            NombreTextbox.Text = "";
            TelefonoTextBox.Text = "";
            DropDownList1.Text = "";
            FechaTextBox1.Text = string.Format("{0:G}", DateTime.Now);
            NombreTextbox.Focus();
        }


        protected void Buscar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idTextbox.Text);
            peluquero = BLL.PeluqueroBll.Buscar(p => p.idPeluquero == id);

            if(IsValid)
            {
                if (peluquero != null)
                {
                    NombreTextbox.Text = peluquero.nombre;
                    TelefonoTextBox.Text = peluquero.telefono;
                    DropDownList1.Text = peluquero.sexo;
                    FechaTextBox1.Text = Convert.ToString(peluquero.fecha);
                }
                else
                {
                    Utilidades.MostrarToastr(this, "No Existe", "error", "error");
                }
            }
           
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                peluquero = llenarCampos();
                if (peluquero.idPeluquero > 0)
                {
                    BLL.PeluqueroBll.Modificar(peluquero);
                    Utilidades.MostrarToastr(this, "Modificado", "success", "success");
                }
                else
                {
                    BLL.PeluqueroBll.Guardar(peluquero);
                    Utilidades.MostrarToastr(this, "Guardado", "success", "success");
                    limpiar();
                    NombreTextbox.Focus();
                }
            }
           
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idTextbox.Text);
            peluquero = BLL.PeluqueroBll.Buscar(p => p.idPeluquero == id);

            if (peluquero != null)
            {
                BLL.PeluqueroBll.Eliminar(peluquero);
                Utilidades.MostrarToastr(this, "Eliminado", "info", "info");
            }
        }
    }
}