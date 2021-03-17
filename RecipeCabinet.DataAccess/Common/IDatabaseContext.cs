using System.Data;
using System.Data.SqlClient;

namespace RecipeCabinet.DataAccess.Common
{
    public interface IDatabaseContext
    {
        public SqlDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.StoredProcedure, params SqlParameter[] parameters);
        public int ExecuteNonReader(string commandText, CommandType commandType = CommandType.StoredProcedure, params SqlParameter[] parameters);
    }
}
