using Barinak.Data.Abstract;
using Barinak.Entity;

namespace Barinak.Data.Concrete
{
    public class EfAnimalRepository : IAnimalRepository
    {
        private BarinakContext _context;
        public EfAnimalRepository(BarinakContext context)
        {
            _context = context;
        }
        public IQueryable<Animal> Animals => _context.Animals;

        public void CreateAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }
    }
}