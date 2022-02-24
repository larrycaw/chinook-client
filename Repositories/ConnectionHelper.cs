using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chinook_client.Repositories
{
    public class ConnectionHelper
    {
        /// <summary>
        /// SQL Server configuration
        /// </summary>
        /// <returns>Connection string</returns>
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            //connectionStringBuilder.DataSource = @"ISAK-DESKTOP\SQLEXPRESS";
            connectionStringBuilder.DataSource = @"DESKTOP-KAM7GHR\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate = true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}
