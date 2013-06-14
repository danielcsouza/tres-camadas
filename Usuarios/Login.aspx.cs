using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegraNegocios;

namespace Usuarios
{
    public partial class Login : System.Web.UI.Page
    {
        string retorno;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            RegraNegocios.Usuarios objUsuario = new RegraNegocios.Usuarios();
            retorno = objUsuario.AcessarSistema(txtLogin.Text.ToString(), txtSenha.Text.ToString());

            switch (retorno)
            {
                case "sucesso":
                    Response.Redirect("Home.aspx");
                    break;

                case "nao_encontrou":
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "mensagem('Usuario e /ou senha incorretos','error');", true);
                    break;

                case "vazio":
                    ClientScript.RegisterStartupScript(this.GetType(), "Mensagem", "mensagem('Não deixe campos vazios','erro');", true);
                    break;
            }


        }
    }
}