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
        public static SqlConnection ConnBD()
        {
            SqlConnection conn = new SqlConnection();
            //Женя
            conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ноут\Desktop\DonorII\DonorII\Database1.mdf;Integrated Security=True";

            //Ира
            //conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\irinafilchukova\Source\Repos\DonorII\DonorII\Database1.mdf;Integrated Security=True";

            return conn;
        }
    }
}
