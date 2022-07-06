using System.Data.SqlClient;

namespace FilesModule.Model
{
    internal class Files
    {
        private static readonly string CONNSTR = "Data Source=52.165.164.221;Initial Catalog=CIDEIN;Persist Security Info=True;User ID=dba_emadrigals;Password=Daxter0626@16";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(CONNSTR);
        }


        public static bool InsertFile(SqlConnection cn, byte[] data, string nombre)
        {
            string query = "INSERT INTO Archivo(nombre, data) VALUES(@nombre, @data)";
            SqlCommand cmd = new(query, cn);

            cmd.Parameters.Add("@data", System.Data.SqlDbType.VarBinary).Value = data;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;

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
