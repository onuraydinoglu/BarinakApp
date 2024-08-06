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


        public void EditAnimal(Animal animal)
        {
            var entity = _context.Animals.FirstOrDefault(i => i.AnimalId == animal.AnimalId);
            if (entity != null)
            {
                entity.AnimalName = animal.AnimalName;
                entity.Content = animal.Content;
                entity.Age = animal.Age;
                entity.Url = animal.Url;
                entity.IsActive = animal.IsActive;

                _context.SaveChanges();
            }
        }
    }
}