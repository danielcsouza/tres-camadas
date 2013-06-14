using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegraNegocios;

namespace Usuarios
{
    public partial class index : System.Web.UI.Page
    {
        DataTable ListaUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RegraNegocios.Usuarios objUsuario = new RegraNegocios.Usuarios();
                ListaUsuario = objUsuario.ListarTodosUsuarios();

                if (ListaUsuario.Rows.Count > 0)
                {
                    rptLista.DataSource = ListaUsuario;
                    rptLista.DataBind();
                }
                else
                {
                    lblNothing.Visible = true;
                    lblNothing.Text = "Não existem usuários cadastrados";
                }


            }
        }
    }
}