using RecipeCabinet.Domain.Metadata;

namespace RecipeCabinet.DataAccess.Metadata
{
    internal interface IImageRepository
    {
        public ImageModel Create(ImageModel rating);

        public ImageModel GetById(int id);

        public ImageModel Update(ImageModel rating);

        public void Delete(int id);
    }
}
}
