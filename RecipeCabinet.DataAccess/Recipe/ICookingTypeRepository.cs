using RecipeCabinet.Domain.Recipe;

namespace RecipeCabinet.DataAccess.Recipe
{
    internal interface ICookingTypeRepository
    {
        public CookingTypeModel Create(CookingTypeModel rating);

        public CookingTypeModel GetById(int id);

        public CookingTypeModel Update(CookingTypeModel rating);

        public void Delete(int id);
    }
}
}
