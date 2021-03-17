using RecipeCabinet.Domain.Metadata;

namespace RecipeCabinet.DataAccess.Metadata
{
    internal interface IMetadataTaggingRepository
    {
        public MetadataTaggingModel Create(MetadataTaggingModel metadataTagging);

        public MetadataTaggingModel GetById(int id);

        public MetadataTaggingModel Update(MetadataTaggingModel metadataTagging);

        public void Delete(int id);
    }
}
}
