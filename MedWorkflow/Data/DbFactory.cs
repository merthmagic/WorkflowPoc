using System;
using System.Configuration;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace MedWorkflow.Data
{
    public class DbFactory
    {
        public static IDbConnection GetConnection()
        {
            var connString = ConfigurationManager.ConnectionStrings["msc"].ConnectionString;
            return new OracleConnection(connString);
        }

        public static DbContext GetDbContext()
        {
            var conn = GetConnection();
            conn.Open();
            var trans = conn.BeginTransaction();
            return new DbContext(conn,trans);
        }
    }
}