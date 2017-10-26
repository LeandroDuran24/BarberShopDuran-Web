using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace BarberShop
{
    public static class Utilidades
    {

        public static int TOINT(string nombre)
        {
            int numero;
            int.TryParse(nombre, out numero);
            return numero;
        }



        public static void MostrarToastr(this Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                 String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }
    }
}