﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Consultas
{
    public partial class ReservacionCons : System.Web.UI.Page
    {
        public static List<Reservaciones> lista { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Reservaciones reservacion = new Reservaciones();
            GridView1.DataSource = BLL.ReservacionesBLL.GetListTodo();
            GridView1.DataBind();
            lista = BLL.ReservacionesBLL.GetListTodo();
        }

        public void SeleccionarCombo()
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                int id = Convert.ToInt32(TextBox1.Text);
                lista = BLL.ReservacionesBLL.GetList(p => p.idReservacion == id);

            }
          
            else if (DropDownList1.SelectedIndex == 1)
            {
                DateTime desde = Convert.ToDateTime(desdeFecha.Text);
                DateTime hasta = Convert.ToDateTime(desdeFecha.Text);

                if (desdeFecha.Text != "" && hastaFecha.Text != "")
                {
                    if (desde <= hasta)
                    {
                        lista = BLL.ReservacionesBLL.GetList(p => p.fechaDesde >= desde && p.fechaHasta <= hasta);

                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('La Primera Fecha debe ser Menor a la Segunda Fecha');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "scripts", "<script>alert('Debe de Insertar el Intervalo de Fecha');</script>");
                }



            }
            else if (DropDownList1.SelectedIndex == 3)
            {

                lista = BLL.ReservacionesBLL.GetListTodo();


            }
            GridView1.DataSource = lista;
            GridView1.DataBind();


        }



        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            SeleccionarCombo();
        }
    }
}