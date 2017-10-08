using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Formularios
{
    public partial class ServiciosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
        }

        Servicios Servicios = new Servicios();

        public void limpiar()
        {
            idTextbox.Text = "";
            NombreTextbox.Text = "";
            CostoTextBox1.Text = "";
            NombreTextbox.Focus();
        }

        public Servicios LLenar()
        {
            //Servicios.idServicio = Utilidades.TOINT(idTextbox.Text);
            Servicios.nombre = NombreTextbox.Text;
            Servicios.costo = Convert.ToInt32(CostoTextBox1.Text);
            return Servicios;

        }


        protected void Buscar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idTextbox.Text);
            Servicios = BLL.TiposSeviciosBLL.Buscar(p => p.idServicio == id);

            if (IsValid)
            {
                if (Servicios != null)
                {
                    NombreTextbox.Text = Servicios.nombre;
                    CostoTextBox1.Text = Convert.ToString(Servicios.costo);

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No existe !');");
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
                Servicios = LLenar();
                if (Servicios.idServicio != 0)
                {
                    BLL.TiposSeviciosBLL.Modificar(Servicios);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Modificado !');</script>");

                }
                else
                {
                    BLL.TiposSeviciosBLL.Guardar(Servicios);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Guardado !');</script>");
                    limpiar();
                    NombreTextbox.Focus();
                }
            }
            
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idTextbox.Text);
            Servicios = BLL.TiposSeviciosBLL.Buscar(p => p.idServicio == id);
            if (Servicios != null)
            {
                BLL.TiposSeviciosBLL.Eliminar(Servicios);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No existe !');");
            }
        }
    }
}