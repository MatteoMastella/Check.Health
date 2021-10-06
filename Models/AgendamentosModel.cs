using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public class Class1
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

        public static Response AgendamentoSelect(string nome, string especialidade)
        {
            string select = $"SELECT *  from dbo.Medico WHERE Nome = '{nome}' and Especialidade ='{especialidade}'";
            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);

            try
            {
                ConnectionString.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    nome = dr[1].ToString();
                    especialidade = dr[6].ToString();
                }

                if (nome != null && especialidade != null)
                {
                    return new Response
                    {
                        Executed = true
                    };
                }
                else
                {
                    throw new Exception();

                }
                ConnectionString.Connection.Close();
            }
            catch(Exception e)
            {
                return ExceptionGet(e);
            }
               
        }
    }
}


