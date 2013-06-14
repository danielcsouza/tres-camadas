<h1>Sistema de Cadastro de Usuário Simples<br>
3 Camadas ( 3 -tier ) em C#  e SQL Server</h1>

-----

Exemplo simples da arquitetura em 3 camadas ( 3 tier ) feito em C# . 
Para fins de estudo e modelo para outros.<br>
Um <b>CRUD</b> simples usando a arquitetura de 3 camadas.<br>
Para testar você pode forcar o repositório ou baixar os arquivos<br>
<br>

<h3>Procedimentos</h3>

<ol>
<li>Crie um banco de dados no SQL Server com o nome que desejar</li>
<li>Crie a tabela USUARIOS com o arquivo tabela.sql ou com o comando abaixo</li>
<blockquote>

CREATE TABLE [dbo].[USUARIOS](
  [usu_codigo] [int] IDENTITY(1,1) NOT NULL,
	[usu_nome] [varchar](150) NOT NULL,
	[usu_login] [varchar](100) NOT NULL,
	[usu_senha] [varchar](255) NOT NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[usu_codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

</blockquote>
<li>Altere o arquivo Acesso.cs no projeto AcessoDados para a configuração do seu banco de dados e usuario</li>
<li>Abra o projeto no seu Visual Studio e pronto!</li>
<li>Bom proveito e bons estudos</li>
</ol>

Sobre o desenvolvimento em camadas http://pt.wikipedia.org/wiki/Modelo_em_tr%C3%AAs_camadas


