using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public class UsuarioLoginBD
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
        public static Response Select(string email, string senha, out UsuarioLogin user)
        {
            user = new UsuarioLogin();
            string select = $"SELECT * from dbo.Paciente WHERE Email = '{email}' and  Senha = '{senha}'";
            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);

            try
            {
                ConnectionString.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    user.idPaciente = Convert.ToInt32(dr[0]);
                }
                if (user.idPaciente != 0)
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
            catch (Exception e)
            {
                return ExceptionGet(e);
            }
        }
    }
}
