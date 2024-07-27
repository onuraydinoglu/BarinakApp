using Barinak.Data;
using Barinak.Data.Abstract;
using Barinak.Entity;
using Barinak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barinak.Controllers
{
    public class AnimalsController : Controller
    {
        private IAnimalRepository _animalRepository;

        public AnimalsController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<IActionResult> Index(string breed)
        {
            IQueryable<Animal> animals = _animalRepository.Animals.Include(a => a.Breeds);

            if (!string.IsNullOrEmpty(breed))
            {
                animals = animals.Where(x => x.Breeds.Any(t => t.Url == breed));
            }

            return View(new AnimalViewModel { Animals = await animals.ToListAsync() });
        }

        public IActionResult Details(string url)
        {
            return View(_animalRepository.Animals.Include(x => x.Breeds).Include(x => x.Comments).ThenInclude(x => x.User).FirstOrDefault(p => p.Url == url));
        }
    }
}