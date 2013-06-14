using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegraNegocios;

namespace Usuarios
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NomeUsuario"] != null)
                {
                    lblTexto.Text = "Olá <b>" + Session["NomeUsuario"] + "</b>, seja bem vindo<br><br>";

                }
            }
        }
    }
}