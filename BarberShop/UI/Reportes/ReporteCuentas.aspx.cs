using BarberShop.UI.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarberShop.UI.Reportes
{
    public partial class ReporteCuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer.Reset();
                ReportViewer.LocalReport.ReportPath = Server.MapPath(@"CuentasCobrar.rdlc");
                ReportViewer.LocalReport.DataSources.Clear();

                ReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetFacturas",
                   CuentasXCobrar.Lista));

                ReportViewer.LocalReport.Refresh();
            }
        }
    }
}