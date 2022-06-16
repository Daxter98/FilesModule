using System.Data.SqlClient;

namespace FilesModule.Model
{
    internal class Files
    {
        private static readonly string CONNSTR = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DBTest;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(CONNSTR);
        }


        public static Boolean InsertFile(SqlConnection cn, byte[] data, string ext)
        {
            string query = "INSERT INTO Archivo(data, extension) VALUES(@data, @extn)";
            SqlCommand cmd = new(query, cn);

            cmd.Parameters.Add("@data", System.Data.SqlDbType.VarBinary).Value = data;
            cmd.Parameters.Add("@extn", System.Data.SqlDbType.VarChar).Value = ext;

            try
            {
                cn.Open();

                return cmd.ExecuteNonQuery() > 0;
            }
            catch(SqlException ex)
            {
                // Only for Debuggin purposes - Comment the line below when using in production
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                // If a conn object is used one time, use Dispose. Using will enforce this behavior. Else use Close() when using multiple instances. 
                cn.Dispose();
            }
        }
    }
}
