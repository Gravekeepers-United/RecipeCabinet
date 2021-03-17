using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace RecipeCabinet.DataAccess.Common
{
    public class DatabaseContext : IDatabaseContext
    {
        private string _connectionString;
        private IConfiguration _configuration;
        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("RecipeCabinet");
            
        }

        public SqlDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.StoredProcedure, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(_connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                // When using CommandBehavior.CloseConnection, the connection will be closed when the 
                // IDataReader is closed.
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }

        public int ExecuteNonReader(string commandText, CommandType commandType = CommandType.StoredProcedure, params SqlParameter[] parameters)
        {
            SqlConnection conn = new SqlConnection(_connectionString);

            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                conn.Close();

                return affected;
            }
        }
    }
}
