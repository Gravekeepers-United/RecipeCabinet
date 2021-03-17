using System.Data.SqlClient;
using System;
using RecipeCabinet.Domain.Metadata;
using RecipeCabinet.DataAccess.Common;

namespace RecipeCabinet.DataAccess.Metadata
{
    public class MeasurementRepository : IMeasurementRepository
    {
        // SPROCS
        private const string MEASUREMENT_CREATE_SPROC = "Measurement_Create";
        private const string MEASUREMENT_GETBYID_SPROC = "Measurement_GetById";
        private const string MEASUREMENT_UPDATE_SPROC = "Measurement_Update";
        private const string MEASUREMENT_DELETE_SPROC = "Measurement_Delete";

        private IDatabaseContext _dbContext;

        public MeasurementRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public MeasurementModel Create(MeasurementModel measurement)
        {
            SqlParameter nameParam = new SqlParameter("Name", measurement.Name);
            SqlParameter imperialParam = new SqlParameter("Imperial", measurement.Imperial);
            SqlDataReader reader = _dbContext.ExecuteReader(MEASUREMENT_CREATE_SPROC, System.Data.CommandType.StoredProcedure, nameParam, imperialParam);
            while (reader.Read())
            {
                // This might not be right.
                measurement.Id = int.Parse(reader["Id"].ToString());
            }
            return measurement;
        }

        public MeasurementModel GetById(int id)
        {
            MeasurementModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(MEASUREMENT_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new MeasurementModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Imperial = bool.Parse(reader["Imperial"].ToString())
                };
            }
            return model;
        }

        public MeasurementModel Update(MeasurementModel measurement)
        {
            SqlParameter param = new SqlParameter("Id", measurement.Id);
            SqlParameter nameParam = new SqlParameter("Name", measurement.Name);
            SqlParameter imperialParam = new SqlParameter("Imperial", measurement.Imperial);
            _dbContext.ExecuteNonReader(MEASUREMENT_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, nameParam, imperialParam);

            return measurement;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(MEASUREMENT_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
}
