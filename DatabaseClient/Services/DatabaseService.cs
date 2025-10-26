using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatabaseClient.Services
{
    internal class DatabaseService : IDisposable
    {

        private const string _connectionString =
             "Data Source=(localdb)\\MSSQLLocalDB;" +
             "Initial Catalog=CarDatabase;" + // Make sure to specify your DB
             "Integrated Security=True;" +
             "Persist Security Info=False;" +
             "Pooling=True;" +  // Better performance with connection pooling
             "MultipleActiveResultSets=True;" +  // Optional, allows multiple DataReaders
             "Encrypt=False;" +  // Disable encryption for local connections
             "TrustServerCertificate=True;" +  // Prevent certificate validation errors
             "Application Name=DatabaseClient;" +
             "Command Timeout=30;";

        private SqlConnection _sqlConnection;

        public DatabaseService()
        {
            _sqlConnection = new(_connectionString);

            OpenConnection();
        }

        public void OpenConnection()
        {
            try
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                    _sqlConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine($"Trying to open Connection. State: {_sqlConnection.State}");
        }

        public void CloseConnection()
        {
            if (_sqlConnection.State == ConnectionState.Open)
                _sqlConnection.Close();

            Console.WriteLine($"Trying to close Connection. State: {_sqlConnection.State}");
        }

        public void Dispose()
        {
            CloseConnection();
            _sqlConnection.Dispose();
        }

        public int ExecuteNonQuery(string procedureName, params SqlParameter[] parameters)
        {

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                // Add logging
                return -1;
            }

            using   SqlCommand cmd = new(procedureName, _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            
            return cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string procedureName, params SqlParameter[] parameters)
        {
            SqlCommand cmd = new(procedureName, _sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);

            return cmd.ExecuteReader();
        }

    }
}
