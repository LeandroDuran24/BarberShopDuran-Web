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
            FechaTextBox1.Text = string.Format("{0:G}", DateTime.Now);


            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
        }

        Peluqueros peluquero = new Peluqueros();

        public Peluqueros llenarCampos()
        {
            peluquero.idPeluquero = Utilidades.TOINT(idTextbox.Text);
            peluquero.nombre = NombreTextbox.Text;
            peluquero.telefono = TelefonoTextBox.Text;
            peluquero.sexo = SexoTextBox.Text;
            peluquero.fecha = Convert.ToDateTime(FechaTextBox1.Text);

            return peluquero;
        }

        public void limpiar()
        {
            idTextbox.Text = "";
            NombreTextbox.Text = "";
            TelefonoTextBox.Text = "";
            SexoTextBox.Text = "";
            FechaTextBox1.Text = string.Format("{0:G}", DateTime.Now);
            NombreTextbox.Focus();
        }


        protected void Buscar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idTextbox.Text);
            peluquero = BLL.PeluqueroBll.Buscar(p => p.idPeluquero == id);

            if (peluquero != null)
            {
                NombreTextbox.Text = peluquero.nombre;
                TelefonoTextBox.Text = peluquero.telefono;
                SexoTextBox.Text = peluquero.sexo;
                FechaTextBox1.Text = Convert.ToString(peluquero.fecha);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No existe');</script>");
            }
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void guardar_Click(object sender, EventArgs e)
        {
            peluquero = llenarCampos();
            if (peluquero.idPeluquero > 0)
            {
                BLL.PeluqueroBll.Modificar(peluquero);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Modificado !');</script>");
            }
            else
            {
                BLL.PeluqueroBll.Guardar(peluquero);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Guardado !');</script>");
                limpiar();
                NombreTextbox.Focus();
            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idTextbox.Text);
            peluquero = BLL.PeluqueroBll.Buscar(p => p.idPeluquero == id);

            if (peluquero != null)
            {
                BLL.PeluqueroBll.Eliminar(peluquero);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Eliminado !');</script>");
            }
        }
    }
}