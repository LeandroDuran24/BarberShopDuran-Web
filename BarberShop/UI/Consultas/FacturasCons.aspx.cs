using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Consultas
{
    public partial class FacturasCons : System.Web.UI.Page
    {

        public static List<Facturas> lista { get; set; }
        public static DataTable tabla { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lista = BLL.FacturarBLL.GetListodo();
                tabla = new DataTable();
            }

        }


        public void SeleccionarCombo()
        {
            if (DropDownList1.SelectedIndex == 0)
            {
                lista = null;
            }
            else if (DropDownList1.SelectedIndex == 1)
            {
                if (TextBox1.Text == "")
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar Id", "error", "error");
                    lista = null;
                }
                else
                {
                    //int id = Convert.ToInt32(TextBox1.Text);
                    //lista = BLL.FacturarBLL.GetList(p => p.idFactura == id);

                    SqlConnection conexion = new SqlConnection();
                    conexion.ConnectionString = @"Data Source=tcp:leandroduran.database.windows.net,1433;Initial Catalog=BarberShopDuran;Persist Security Info=False;User ID=leandroDuran24;Password=Leandro24;MultipleActiveResultSets=False;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False";

                    SqlCommand comando = new SqlCommand();
                    comando.Connection = conexion;

                    comando.CommandText = "Select fac.idFactura,cli.nombre as Nombre,ser.nombre as Servicio, fac.formaPago,fac.comentario,fac.descuento,fac.subTotal,fac.total,fac.usuario,fac.fecha from facturas fac left join detalles det on fac.idFactura=det.idFactura left join servicios ser on ser.idServicio=det.idServicio left join clientes cli on cli.idCliente=fac.idCliente  where fac.idFactura= " + Convert.ToInt32(TextBox1.Text);


                    SqlDataAdapter sql = new SqlDataAdapter(comando);

                    sql.Fill(tabla);

                    GridView1.DataSource = tabla;
                    GridView1.DataBind();

                }


            }

            else if (DropDownList1.SelectedIndex == 2)
            {


                if (desdeFecha.Text != "" && hastaFecha.Text != "")
                {
                    DateTime desde = Convert.ToDateTime(desdeFecha.Text);
                    DateTime hasta = Convert.ToDateTime(hastaFecha.Text);
                    if (desde <= hasta)
                    {

                        //lista = BLL.FacturarBLL.GetList(p => p.fecha >= desde && p.fecha <= hasta);
                        SqlConnection conexion = new SqlConnection();
                        conexion.ConnectionString = @"Data Source=tcp:leandroduran.database.windows.net,1433;Initial Catalog=BarberShopDuran;Persist Security Info=False;User ID=leandroDuran24;Password=Leandro24;MultipleActiveResultSets=False;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False";

                        SqlCommand comando = new SqlCommand();
                        comando.Connection = conexion;
                        string query= @"Select fac.idFactura,cli.nombre as Nombre,ser.nombre as Servicio, fac.formaPago,fac.comentario,fac.descuento,fac.subTotal,fac.total,fac.usuario,fac.fecha from facturas fac left join detalles det on fac.idFactura=det.idFactura left join servicios ser on ser.idServicio=det.idServicio left join clientes cli on cli.idCliente=fac.idCliente where fac.fecha>=@desde and fac.fecha<=@hasta";
                        comando.CommandText = query;
                        comando.Parameters.Add("@desde", SqlDbType.DateTime).Value = desdeFecha.Text;
                        comando.Parameters.Add("@hasta", SqlDbType.DateTime).Value =hastaFecha.Text;
                        SqlDataAdapter sql = new SqlDataAdapter(comando);

                        sql.Fill(tabla);

                        GridView1.DataSource = tabla;
                        GridView1.DataBind();



                    }
                    else
                    {
                        Utilidades.MostrarToastr(this, "La Primera Fecha debe ser Menor que la Segunda Fecha", "error", "error");
                        lista = null;
                    }
                }
                else
                {
                    Utilidades.MostrarToastr(this, "Debes Insertar las Fechas", "error", "error");
                    lista = null;
                }



            }
            else if (DropDownList1.SelectedIndex == 3)
            {

                //lista = BLL.FacturarBLL.GetListodo();
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = @"Data Source=tcp:leandroduran.database.windows.net,1433;Initial Catalog=BarberShopDuran;Persist Security Info=False;User ID=leandroDuran24;Password=Leandro24;MultipleActiveResultSets=False;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False";

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;

                comando.CommandText = "Select fac.idFactura,cli.nombre as Nombre,ser.nombre as Servicio, fac.formaPago,fac.comentario,fac.descuento,fac.subTotal,fac.total,fac.usuario,fac.fecha from facturas fac left join detalles det on fac.idFactura=det.idFactura left join servicios ser on ser.idServicio=det.idServicio left join clientes cli on cli.idCliente=fac.idCliente";


                SqlDataAdapter sql = new SqlDataAdapter(comando);

                sql.Fill(tabla);

                GridView1.DataSource = tabla;
                GridView1.DataBind();


            }
            //GridView1.DataSource = lista;
            //GridView1.DataBind();


        }



        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            SeleccionarCombo();
        }

        protected void ButtonImprimir_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteFacturas.aspx");
        }
    }
}