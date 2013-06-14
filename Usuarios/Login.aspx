<%@ Page Title="" Language="C#" MasterPageFile="~/modelo.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Usuarios.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudo" runat="server">
      <script type="text/javascript">
          $(document).ready(function () {
              $("#form").validate({
                  rules: {
                    <%=txtLogin.UniqueID %>:{required:true},
                    <%=txtSenha.UniqueID %>:{required:true}

                },
                messages: {
                    <%=txtLogin.UniqueID %>:{required:"Digite um login"},
                    <%=txtSenha.UniqueID %>:{required:"Escolha uma senha"}
                }
            });
        });
  </script>
  <div class="span12">
 <fieldset><legend>Acesso ao sistema</legend>
  <div class="control-group">
    <label class="control-label" for="Login">Login</label>
    <div class="controls">
       <asp:TextBox ID="txtLogin" runat="server" placeholder="Digite seu login de acesso"></asp:TextBox>
    </div>
  </div>
  <div class="control-group">
    <label class="control-label" for="Senha">Senha</label>
    <div class="controls">
       <asp:TextBox ID="txtSenha" runat="server" placeholder="Digite sua senha de acesso" TextMode="Password"></asp:TextBox>
    </div>
  </div>
   <div class="form-actions">
     <asp:Button ID="btnEnviar" runat="server" Text="Salvar" CssClass="btn btn-large btn-inverse" OnClick="btnEnviar_Click"/>
</div>

 </fieldset>
 </div>
</asp:Content>
