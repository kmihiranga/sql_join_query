using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NW_Pos
{
    class connectionDB
    {
        public static SqlConnection constring() {

            SqlConnection conn = new SqlConnection(@"Data Source=(local)\sqlexpress; Initial Catalog=cctv; User Id=sa; Password=Kalana@077#;");
            return conn;
        }
    }
}
