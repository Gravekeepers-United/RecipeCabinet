using System.Data.SqlClient;
using System;
using RecipeCabinet.Domain.Metadata;
using RecipeCabinet.DataAccess.Common;

namespace RecipeCabinet.DataAccess.Metadata
{
    public class MetadataTypeRepository : IMetadataTypeRepository
    {
        // SPROCS
        private const string METADATATYPE_CREATE_SPROC = "MetadataType_Create";
        private const string METADATATYPE_GETBYID_SPROC = "MetadataType_GetById";
        private const string METADATATYPE_UPDATE_SPROC = "MetadataType_Update";
        private const string METADATATYPE_DELETE_SPROC = "MetadataType_Delete";

        private IDatabaseContext _dbContext;

        public MetadataTypeRepository(IDatabaseContext sqlDatabaseContext)
        {
            _dbContext = sqlDatabaseContext;
        }

        public MetadataTypeModel Create(MetadataTypeModel metadataType)
        {
            SqlParameter nameParam = new SqlParameter("Name", metadataType.Name);
            SqlDataReader reader = _dbContext.ExecuteReader(METADATATYPE_CREATE_SPROC, System.Data.CommandType.StoredProcedure, nameParam);
            while (reader.Read())
            {
                // This might not be right.
                metadataType.Id = int.Parse(reader["Id"].ToString());
            }
            return metadataType;
        }

        public MetadataTypeModel GetById(int id)
        {
            MetadataTypeModel model = null;
            SqlParameter param = new SqlParameter("Id", id);
            SqlDataReader reader = _dbContext.ExecuteReader(METADATATYPE_GETBYID_SPROC, System.Data.CommandType.StoredProcedure, param);
            while (reader.Read())
            {
                model = new MetadataTypeModel
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString()
                };
            }
            return model;
        }

        public MetadataTypeModel Update(MetadataTypeModel metadataType)
        {
            SqlParameter param = new SqlParameter("Id", metadataType.Id);
            SqlParameter nameParam = new SqlParameter("Name", metadataType.Name);
            _dbContext.ExecuteNonReader(METADATATYPE_UPDATE_SPROC, System.Data.CommandType.StoredProcedure, param, nameParam);

            return metadataType;
        }

        public void Delete(int id)
        {
            SqlParameter param = new SqlParameter("Id", id);
            _dbContext.ExecuteNonReader(METADATATYPE_DELETE_SPROC, System.Data.CommandType.StoredProcedure, param);
        }
    }
}
}
