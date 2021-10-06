using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteSaúde.Models
{
    public static class ConnectionString
    {
        public static SqlConnection Connection { get; } = new SqlConnection("Data Source=BUE205D13;Initial Catalog=BDTurmaTarde;Persist Security Info=True;User ID=guest01;Password=@Senac2021");

    }
}
