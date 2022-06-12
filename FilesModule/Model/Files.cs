using System.Data.SqlClient;

namespace FilesModule.Model
{
    internal class Files
    {
        private readonly string CONNSTR = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DBTest;Integrated Security=True";
        private SqlConnection connection;
        
        public void TestConnection()
        {
            try
            {
                connection = new SqlConnection(CONNSTR);
                connection.Open();
                MessageBox.Show("Connection Succesfully Opened");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
