using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcessoDados
{
    public class Acesso
    {
        /// <summary>
        /// Propriedade de String de Conexao com Banco
        /// </summary>
        public static string StringConexao
        {
            get
            {
                return @"Data Source=.\sqlexpress;Initial Catalog=USUARIOS;User ID=user;Password=senha";
            }
        }
    }
}
