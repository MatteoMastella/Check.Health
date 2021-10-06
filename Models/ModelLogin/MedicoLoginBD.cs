using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public class MedicoLoginBD
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
        public static Response Select(string email, string senha, out MedicoLogin medico)
        {
            medico = new MedicoLogin();
            string select = $"SELECT * from dbo.Medico WHERE Email = '{email}' and  Senha = '{senha}'";
            SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);

            try
            {
                ConnectionString.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    medico.IdMedico = Convert.ToInt32(dr[0]);
                }
                if (medico.IdMedico != 0)
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
