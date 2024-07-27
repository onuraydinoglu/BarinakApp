using Barinak.Entity;

namespace Barinak.Data.Abstract
{
    public interface IAnimalRepository
    {
        IQueryable<Animal> Animals { get; }
        void CreateAnimal(Animal animal);

    }
}