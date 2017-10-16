using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptPaginas.Script();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user = BLL.UsuariosBLL.Buscar(p => p.email == EmailTextBox.Text);

            if (user != null)
            {
                if (user.clave == PassTextBox1.Text)
                {
                    FormsAuthentication.RedirectFromLoginPage(user.email, true);

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "toastr_message", "toastr.error('Contraseña no Coincide Con Email...!', 'Error')", true);
                    Limpiar();

                }
            }
            else
            {

                
                Page.ClientScript.RegisterStartupScript(this.GetType(),"toastr_message", "toastr.error('No Existe', 'Error')", true);
                Limpiar();
            }

        }

        public void Limpiar()
        {
            EmailTextBox.Text = "";
            PassTextBox1.Text = "";
            EmailTextBox.Focus();

        }
    }
}