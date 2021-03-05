using RecipeCabinet.Domain.Cabinet;


namespace RecipeCabinet.DataAccess.Cabinet
{
    public interface ICabinetRepository
    {
        public CabinetModel Create(CabinetModel ingredient);

        public CabinetModel GetById(int id);

        public CabinetModel Update(CabinetModel ingredient);

        public void Delete(int id);
    }
}
