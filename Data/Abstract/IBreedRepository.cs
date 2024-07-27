using Barinak.Entity;

namespace Barinak.Data.Abstract
{
    public interface IBreedRepository
    {
        IQueryable<Breed> Breeds { get; }
        void CreateBreed(Breed breed);

    }
}