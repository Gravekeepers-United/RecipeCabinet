using RecipeCabinet.DataAccess.Common;
using RecipeCabinet.Domain.Cabinet;
using System.Data.SqlClient;

namespace RecipeCabinet.DataAccess.Cabinet
{
    public class CabinetRepository : ICabinetRepository
    {
        private IDatabaseContext _dbContext;

        public CabinetRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        // SPROCS
        private const string CABINET_CREATE_SPROC = "Cabinet_Create";
        private const string CABINET_GETBYID_SPROC = "Cabinet_GetById";
        private const string CABINET_UPDATE_SPROC = "Cabinet_Update";
        private const string CABINET_DELETE_SPROC = "Cabinet_Delete";


        public CabinetModel Create(CabinetModel cabinet)
        {
            SqlParameter itemParam = new SqlParameter("CabinetItem", cabinet.CabinetItem);
            SqlParameter quantityParam = new SqlParameter("Quantity", cabinet.Quantity);
            SqlParameter measurementParam = new SqlParameter("QuantityMeasurement", cabinet.QuantityMeasurement);
            SqlDataReader reader = _dbContext.ExecuteReader(CABINET_CREATE_SPROC, System.Data.CommandType.StoredProcedure, itemParam, quantityParam, measurementParam);
            while (reader.Read())
            {
                // This might not be right.
                cabinet.Id = int.Parse(reader["Id"].ToString());
            }
            return cabinet;
        }

        public CabinetModel GetById(int id)
        {
            CabinetModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(CABINET_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new CabinetModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    CabinetItem = int.Parse(reader["CabinetItem"].ToString()),
                    Quantity = double.Parse(reader["Quantity"].ToString()),
                    QuantityMeasurement = int.Parse(reader["QuantityMeasurement"].ToString())
                };
            }
            return model;
        }

        public CabinetModel Update(CabinetModel cabinet)
        {
            SqlParameter param = new SqlParameter("Id", cabinet.Id);
            SqlParameter itemParam = new SqlParameter("Name", cabinet.CabinetItem);
            SqlParameter quantityParam = new SqlParameter("Type", cabinet.Quantity);
            SqlParameter measurementParam = new SqlParameter("QuantityMeasurement", cabinet.QuantityMeasurement);
            _dbContext.ExecuteNonReader(CABINET_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, itemParam, quantityParam, measurementParam);

            return cabinet;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(CABINET_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
