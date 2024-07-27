using Barinak.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barinak.ViewComponents
{

    public class BreedsMenu : ViewComponent
    {
        private IBreedRepository _breedRepository;

        public BreedsMenu(IBreedRepository breedRepository)
        {
            _breedRepository = breedRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _breedRepository.Breeds.ToListAsync());
        }
    }
}