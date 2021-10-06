using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public class EspecialidadeModel
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

        //public static Response EspecialidadeSelect()
        //{
        //    string select = $"SELECT Especialidade from dbo.Medico";
        //    SqlCommand cmd = new SqlCommand(select, ConnectionString.Connection);

        //    try
        //    {
        //        ConnectionString.Connection.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        if(dr.Read())
        //        {
                    
        //        }
        //    }
        //}
    }
}
