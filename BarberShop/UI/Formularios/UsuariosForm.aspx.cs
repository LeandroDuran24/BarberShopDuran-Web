using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Formularios
{
    public partial class UsuariosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.fecha.Text = string.Format("{0:G}", DateTime.Now);



            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
        }


        Usuarios user = new Usuarios();

        public Usuarios LlenarCampos()
        {
            user.idUsuario = Utilidades.TOINT(idTextbox.Text);
            user.nombres = NombreTextbox.Text;
            user.email = emailTextbox.Text;
            user.fecha = Convert.ToDateTime(fecha.Text);
            user.tipoEmail = tipoTextbox.Text;
            user.clave = claveTextbox.Text;
            user.confirmar = confTextbox.Text;
            return user;
        }

        public void Limpiar()
        {
            idTextbox.Text = "";
            NombreTextbox.Text = "";
            emailTextbox.Text = "";
            tipoTextbox.Text = "";
            claveTextbox.Text = "";
            confTextbox.Text = "";
            RequiredFieldValidator1.Text = "";
            RequiredFieldValidator2.Text = "";
            RequiredFieldValidator3.Text = "";
            RequiredFieldValidator4.Text = "";
            RequiredFieldValidator5.Text = "";

            NombreTextbox.Focus();

        }


        protected void Buscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTextbox.Text);
            user = UsuariosBLL.Buscar(p => p.idUsuario == id);

            if (user != null)
            {
                emailTextbox.Text = user.email;
                NombreTextbox.Text = user.nombres;
                claveTextbox.Text = user.clave;
                confTextbox.Text = user.confirmar;
                tipoTextbox.Text = user.tipoEmail;

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No existe ese Registro');</script>");
            }


        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (user.idUsuario != 0)
                {

                    UsuariosBLL.Mofidicar(user);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Se Ha Modificado Correctamente');</script>");
                }
                else
                {
                    user = LlenarCampos();
                    UsuariosBLL.Guardar(user);

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Se Guardo Correctamente');</script>");
                    Limpiar();
                    NombreTextbox.Focus();

                }
            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idTextbox.Text);
            user = UsuariosBLL.Buscar(p => p.idUsuario == id);

            if (user != null)
            {
                if (user.idUsuario != 1)
                {
                    UsuariosBLL.Eliminar(user);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Se ha Eliminado Correctamente');</script>");
                    Limpiar();
                    NombreTextbox.Focus();
                }

            }
        }
    }
}