using Dapper;
using Dapper.Contrib.Extensions;
using Gefun.Repositorio.Configuracao;
using Gefun.Repositorio.VersaoBanco.Versao;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gefun.Repositorio.VersaoBanco.Atualizador
{
    public class AtualizadorDb
    {
        public bool ValidaBanco()
        {
            if (!BaseExiste())
            {
                CriarBanco();
                CriarTabelas();
            }
            return true;
        }

        private void CriarBanco()
        {
            using (var myConn = new SqlConnection("Data Source=BRENDEL-PC;user id=sa;password=saroot;"))
            {
                myConn.Open();
                var str = new StringBuilder();
                str.AppendLine("CREATE DATABASE [Gefun];");
                var myCommand = new SqlCommand(str.ToString(), myConn);
                try
                {
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao criar o banco de dados", ex);
                }
            }

            using (var con = DbContext.ObterConexao())
            {
                string query = @"CREATE TABLE [Parametro](
                    [Id] int IDENTITY(1,1) not null,
                    [Versao] DATETIME not null);
                ";
                con.Open();
                con.Execute(query);                
            }
        }

        private void CriarTabelas()
        {
            using (var myConn = DbContext.ObterConexao())
            {
                myConn.Open();                
                var myCommand = new SqlCommand(new _20220304111000_ScriptInicial().SQL(), myConn);
                try
                {
                    myCommand.ExecuteNonQuery();                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao criar Tabelas", ex);
                }
            }
            AtualizarVersaoBanco(new _20220304111000_ScriptInicial().GetType().Name.Split('_')[1]);
        }

        private void AtualizarVersaoBanco(string v)
        {
            using (var myConn = DbContext.ObterConexao())
            {
                myConn.Open();
                string str = $"UPDATE Parametro SET Versao = {v}";
                var myCommand = new SqlCommand(str, myConn);
                try
                {
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao criar Tabelas", ex);
                }
            }
        }

        private bool BaseExiste()
        {
            using (var myConn = new SqlConnection("Data Source=BRENDEL-PC;user id=sa;password=saroot;"))
            {               
                myConn.Open();                
                var str = $"SELECT * FROM sysdatabases where name = 'Gefun'";
                var myCommand = new SqlCommand(str, myConn);
                using (var reader = myCommand.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }


    }
}
