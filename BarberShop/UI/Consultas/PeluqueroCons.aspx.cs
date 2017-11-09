﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Consultas
{
    public partial class PeluqueroCons : System.Web.UI.Page
    {
        public static List<Peluqueros> lista { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Peluqueros peluquero = new Peluqueros();

            lista = BLL.PeluqueroBll.GetListTodo();
        }

        public void SeleccionarCombo()
        {
            if (DropDownList1.SelectedIndex == 0)
            {

                if (TextBox1.Text == "")
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar Nombre", "error", "error");
                }
                else
                {
                    int id = Convert.ToInt32(TextBox1.Text);
                    lista = BLL.PeluqueroBll.GetList(p => p.idPeluquero == id);
                }


            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                if (TextBox1.Text == "")
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar Nombre", "error", "error");
                }
                else
                {
                    lista = BLL.PeluqueroBll.GetList(p => p.nombre == TextBox1.Text);

                }


            }
            else if (DropDownList1.SelectedIndex == 2)
            {
                DateTime desde = Convert.ToDateTime(desdeFecha.Text);
                DateTime hasta = Convert.ToDateTime(desdeFecha.Text);

                if (desdeFecha.Text != "" && hastaFecha.Text != "")
                {
                    if (desde <= hasta)
                    {
                        lista = BLL.PeluqueroBll.GetList(p => p.fecha >= desde && p.fecha <= hasta);

                    }
                    else
                    {
                        Utilidades.MostrarToastr(this, "La Primera Fecha debe ser Menor que la Segunda Fecha", "error", "error");
                    }
                }
                else
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar las Fechas", "error", "error");
                }



            }
            else if (DropDownList1.SelectedIndex == 3)
            {

                lista = BLL.PeluqueroBll.GetListTodo();


            }
            GridView1.DataSource = lista;
            GridView1.DataBind();
        }


        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            SeleccionarCombo();
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/Reportepeluqueros.aspx");
        }
    }
}