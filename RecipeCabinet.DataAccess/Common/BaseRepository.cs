using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCabinet.DataAccess.Common
{
    abstract public class BaseRepository
    {
        private string _connectionString;
        private IConfiguration _configuration;
        public BaseRepository(IConfiguration configuration)
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
