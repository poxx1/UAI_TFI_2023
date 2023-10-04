using System.Data.SqlClient;

namespace Servicios
{
    public class ConnectionSingleton
    {
        private static SqlConnection connection;

        private static SqlConnection constructor()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.IntegratedSecurity = true;

            if (System.Environment.MachineName.Contains("LAB"))
            {
                cs.DataSource = System.Environment.MachineName;
            }
            else
            {
                cs.DataSource = System.Environment.MachineName + @"\SQLEXPRESS";
                //En cualquier otra pc usar = "\SQLEXPRESS", tengo 2 sql por eso el 01
            }

            cs.InitialCatalog = "tfi";
            return new SqlConnection(cs.ConnectionString);

        }

        public static SqlConnection getConnection()
        {
            if (connection == null)
            {
                connection = constructor();
            }
            return connection;
        }
    }
}
