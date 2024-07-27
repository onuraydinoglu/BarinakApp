using Barinak.Data.Abstract;
using Barinak.Entity;

namespace Barinak.Data.Concrete
{
    public class EfBreedRepository : IBreedRepository
    {
        private BarinakContext _context;
        public EfBreedRepository(BarinakContext context)
        {
            _context = context;
        }
        public IQueryable<Breed> Breeds => _context.Breeds;

        public void CreateBreed(Breed breed)
        {
            _context.Breeds.Add(breed);
            _context.SaveChanges();
        }
    }
}