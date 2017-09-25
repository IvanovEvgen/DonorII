using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DonorII
{
    class ConnectionBD
    {
        public SqlConnection ConnBD()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ноут\Desktop\DonorII\DonorII\Database1.mdf;Integrated Security=True";
            return conn;
        }
    }
}
