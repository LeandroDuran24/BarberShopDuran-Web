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

            if (!Page.IsPostBack)
            {
                ScriptPaginas.Script();
                fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                fecha.Enabled = false;
            }

        }


        Usuarios user = new Usuarios();

        public Usuarios LlenarCampos()
        {
            user.idUsuario = Utilidades.TOINT(idTextbox.Text);
            user.nombre = NombreTextbox.Text;
            user.email = emailTextbox.Text;
            user.fecha = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

            if (DropDownList1.SelectedIndex == 0)
            {
                user.tipoEmail = "Usuario";
            }

            else if (DropDownList1.SelectedIndex == 1)
            {
                user.tipoEmail = "Administrador";
            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                user.tipoEmail = "Usuario";
            }


           

            user.clave = claveTextbox.Text;
            user.confirmar = confTextbox.Text;
            return user;
        }

        public void Limpiar()
        {
            idTextbox.Text = "";
            NombreTextbox.Text = "";
            emailTextbox.Text = "";
            fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

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
            int id = Utilidades.TOINT(idTextbox.Text);
            user = UsuariosBLL.Buscar(p => p.idUsuario == id);
            if (IsValid)
            {
                if (user != null)
                {
                    emailTextbox.Text = user.email;
                    NombreTextbox.Text = user.nombre;
                    DropDownList1.Text = user.tipoEmail;
                    claveTextbox.Text = user.clave;
                    confTextbox.Text = user.confirmar;
                    fecha.Text = Convert.ToString(user.fecha.ToString("dd/MM/yyyy"));



                }
                else
                {
                    Utilidades.MostrarToastr(this, "No Coinciden", "Error", "Error");
                }
            }



        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            user = LlenarCampos();
            if (user.idUsuario != 0)
            {
                if (user.clave != user.confirmar)
                {
                    Utilidades.MostrarToastr(this, "No Coinciden las Claves", "error", "error");
                    claveTextbox.Text = "";
                    confTextbox.Text = "";
                }
                else
                {
                    UsuariosBLL.Mofidicar(user);
                    Utilidades.MostrarToastr(this, "Modificado", "info", "info");
                }
                
            }
            else
            {
                if(user.clave!=user.confirmar)
                {
                    Utilidades.MostrarToastr(this, "No Coinciden las Claves", "error", "error");
                    claveTextbox.Text = "";
                    confTextbox.Text = "";
                }
                else
                {
                    UsuariosBLL.Guardar(user);

                    Utilidades.MostrarToastr(this, "Guardado", "success", "success");
                    Limpiar();
                    NombreTextbox.Focus();
                }
               

            }

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idTextbox.Text);
            user = UsuariosBLL.Buscar(p => p.idUsuario == id);

            if (user != null)
            {
                if (user.idUsuario != 1)
                {
                    UsuariosBLL.Eliminar(user);
                    Utilidades.MostrarToastr(this, "Eliminado", "success", "success");
                    Limpiar();
                    NombreTextbox.Focus();
                }

            }
        }

        protected void idTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }

}