using RecipeCabinet.Domain.Metadata;

namespace RecipeCabinet.DataAccess.Metadata
{
    internal interface IMetadataTypeRepository
    {
        public MetadataTypeModel Create(MetadataTypeModel metadataType);

        public MetadataTypeModel GetById(int id);

        public MetadataTypeModel Update(MetadataTypeModel metadataType);

        public void Delete(int id);
    }
}
}
