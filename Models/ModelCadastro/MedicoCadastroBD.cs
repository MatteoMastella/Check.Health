using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SiteSaúde.Models
{
    public class MedicoCadastroBD
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

        public static Response Insert(MedicoCadastro medico)
        {
            string insert = $"INSERT into dbo.Medico(Nome, Cpf, Email, Senha, Tel, Especialidade) values ('{medico.Nome}', '{medico.Cpf}','{medico.Email}','{medico.Senha}','{medico.Tel}','{medico.Especialidade}')";

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
