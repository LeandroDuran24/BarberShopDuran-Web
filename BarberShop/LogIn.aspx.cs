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
        public static Usuarios usuarioLabel = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ScriptPaginas.Script();
                EmailTextBox.Focus();

               
            }

        }

        public static Usuarios LabelUsuario()
        {
            return usuarioLabel;
        }


        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios user = new Usuarios();
            user = BLL.UsuariosBLL.Buscar(p => p.email == EmailTextBox.Text);
            usuarioLabel = user;

            if (user != null)
            {
                if (user.clave == PassTextBox1.Text)
                {

                    FormsAuthentication.RedirectFromLoginPage(user.email, true);

                }
                else
                {
                    Utilidades.MostrarToastr(this, "No Coinciden", "error", "error");

                    Limpiar();



                }
            }
            else
            {


                Utilidades.MostrarToastr(this, "No Exite Usuario", "error", "error");
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