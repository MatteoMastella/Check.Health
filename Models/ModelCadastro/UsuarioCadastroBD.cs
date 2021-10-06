using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public class UsuarioCadastroBD
    {
        public static Response ExceptionGet(Exception e)
        {
            if (ConnectionString.Connection.State == System.Data.ConnectionState.Open)
            {
                ConnectionString.Connection.Close();
            }

            return new Response
            {
                Executed = false,
                ErrorMessage = e.Message,
                Exception = e
            };
        }

        public static Response Insert(UsuarioCadastro user)
        {
            string insert = $"INSERT into dbo.Paciente(Nome, Cpf, Email, Senha, Tel) values ('{user.Nome}', '{user.Cpf}','{user.Email}','{user.Senha}','{user.Tel}')";

            SqlCommand cmd = new SqlCommand(insert, ConnectionString.Connection);
            try
            {
                ConnectionString.Connection.Open();
                cmd.ExecuteNonQuery();
                ConnectionString.Connection.Close();
                return new Response
                {
                    Executed = true
                };
            }
            catch (Exception e)
            {
                return ExceptionGet(e);
            }

        }
    }
}
