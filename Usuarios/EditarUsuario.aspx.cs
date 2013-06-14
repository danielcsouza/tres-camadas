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
    public partial class EditarUsuario : System.Web.UI.Page
    {
        DataTable DadosUsuario;
        bool retorno;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["cod"].ToString()))
                {
                    RegraNegocios.Usuarios objUsuario = new RegraNegocios.Usuarios();
                    DadosUsuario = objUsuario.ListarUsuario(Convert.ToInt32(Request.QueryString["cod"].ToString()));

                    if (DadosUsuario != null && DadosUsuario.Rows.Count > 0)
                    {
                        foreach (DataRow campo in DadosUsuario.Rows)
                        {
                            txtNome.Text = campo["usu_nome"].ToString();
                            txtLogin.Text = campo["usu_login"].ToString();
                            txtSenha.Text = campo["usu_login"].ToString();
                            hdtxtCodUsuario.Value = campo["usu_codigo"].ToString();
                        }
                    }

                }
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            RegraNegocios.Usuarios objUsuario = new RegraNegocios.Usuarios();
            retorno = objUsuario.EditarUsuario(Convert.ToInt32(hdtxtCodUsuario.Value.ToString()),
                txtNome.Text.ToString(), txtLogin.Text.ToString(), txtSenha.Text.ToString());

            if (retorno)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "mensagem('Dados alterados com sucesso','success');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "mensagem('Erro ao realizar alteração','error');", true);
            }
        }
    }
}