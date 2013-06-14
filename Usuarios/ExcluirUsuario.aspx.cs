using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegraNegocios;

namespace Usuarios
{
    public partial class ExcluirUsuario : System.Web.UI.Page
    {
        bool sucesso;
        int CodUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["cod"].ToString()))
                {
                    int.TryParse(Request.QueryString["cod"].ToString(), out CodUsuario);

                    if (CodUsuario > 0)
                    {
                        RegraNegocios.Usuarios objUsuario = new RegraNegocios.Usuarios();
                        sucesso = objUsuario.ExcluirUsuario(CodUsuario);

                        if (sucesso)
                        {
                            Response.Redirect("index.aspx");
                        }
                        else
                        {
                           ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "mensagem('Erro ao excluuir usuario','error');", true);
                        }
                    }
                }
            }
        }
    }
}