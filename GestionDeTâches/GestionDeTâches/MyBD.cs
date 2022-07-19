using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace GestionDeTâches
{
    internal class MyBD
    {
        SqlConnection con = new SqlConnection(@"Data Source=PC-MK-LEADER;Initial Catalog=TagData;Integrated Security=True");

        public SqlConnection GetConnexion
        {
            get { return con; }
        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
