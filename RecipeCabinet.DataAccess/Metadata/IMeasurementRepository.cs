using RecipeCabinet.Domain.Metadata;

namespace RecipeCabinet.DataAccess.Metadata
{
    internal interface IMeasurementRepository
    {
        public MeasurementModel Create(MeasurementModel rating);

        public MeasurementModel GetById(int id);

        public MeasurementModel Update(MeasurementModel rating);

        public void Delete(int id);
    }
}
}
