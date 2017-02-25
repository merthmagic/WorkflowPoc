using System;
using System.Data;

namespace MedWorkflow.Data
{
    public class DbContext:IDisposable
    {
        private readonly IDbConnection _connection;

        private readonly IDbTransaction _transaction;

        public DbContext(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        public IDbTransaction Transaction
        {
            get { return _transaction; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposing) return;

            if(_connection != null && _connection.State != ConnectionState.Closed)
                _connection.Dispose();
        }
    }
}