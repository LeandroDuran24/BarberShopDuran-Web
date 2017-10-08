using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Formularios
{
    public partial class ClientesForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           FechaTextBox5.Text = string.Format("{0:G}", DateTime.Now);
            

            ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
            myScriptResDef.Path = "~/Scripts/jquery-1.4.2.min.js";
            myScriptResDef.DebugPath = "~/Scripts/jquery-1.4.2.js";
            myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.min.js";
            myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.2.js";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);
        }

        Clientes cliente = new Clientes();

        public Clientes llenarCampos()
        {
            cliente.idCliente = Utilidades.TOINT(idClienteTextbox.Text);
            cliente.nombre = NombreClienteTextbox.Text;
            cliente.apellidos = ApellidosTextBox1.Text;
            cliente.cedula = CedulaTextBox3.Text;
            cliente.direccion = DireccionTextBox2.Text;
            cliente.email = EmailTextBox4.Text;
            cliente.fecha = Convert.ToDateTime(FechaTextBox5.Text);

            return cliente;
        }

        public void limpiar()
        {
            idClienteTextbox.Text = "";
            NombreClienteTextbox.Text = "";
            ApellidosTextBox1.Text = "";
            DireccionTextBox2.Text = "";
            CedulaTextBox3.Text = "";
            EmailTextBox4.Text = "";
            FechaTextBox5.Text = string.Format("{0:G}", DateTime.Now);
            NombreClienteTextbox.Focus();
        }

     

        protected void Buscar_Click(object sender, EventArgs e)
        {
            
            if(IsValid)
            {
                int id = Utilidades.TOINT(idClienteTextbox.Text);
                cliente = BLL.ClientesBLL.Buscar(p => p.idCliente == id);

                if (cliente != null)
                {
                    NombreClienteTextbox.Text = cliente.nombre;
                    ApellidosTextBox1.Text = cliente.apellidos;
                    DireccionTextBox2.Text = cliente.direccion;
                    CedulaTextBox3.Text = cliente.cedula;
                    EmailTextBox4.Text = cliente.email;
                    FechaTextBox5.Text = Convert.ToString(cliente.fecha);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('No existe ese Registro');</script>");
                }
            }

            
        }

        protected void Nuevo_Click2(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            if(IsValid)
            {
                cliente = llenarCampos();
                if (cliente.idCliente > 0)
                {
                    BLL.ClientesBLL.Modificar(cliente);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Modificado !');</script>");
                }
                else
                {
                    BLL.ClientesBLL.Guardar(cliente);
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Guardado !');</script>");
                    limpiar();

                }
            }

            
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            int id = Utilidades.TOINT(idClienteTextbox.Text);
            cliente = BLL.ClientesBLL.Buscar(p => p.idCliente == id);

            if (cliente != null)
            {
                BLL.ClientesBLL.Eliminar(cliente);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Eliminado !');</script>");
            }
        }
    }
}