using System.Data.SqlClient;

namespace CodeGenerator.Helpers.Connection
{
    public class ConnectionData
    {
        public bool Successfull { get; private set; }
        public string DatabaseName { get; private set; }
        public string Server { get; private set; }
        public string ConnectionString { get; private set; }

        public ConnectionData(string connectionString)
        {
            ConnectionString = connectionString;
            Successfull = !string.IsNullOrEmpty(ConnectionString);
            if(Successfull)
            {
                SetDatabaseNameAndServer(ConnectionString);
            }
        }

        public ConnectionData()
        {
            
        }

        private void SetDatabaseNameAndServer(string connectionString)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            DatabaseName = builder.InitialCatalog;
            Server = builder.DataSource; 
        }
    }
}