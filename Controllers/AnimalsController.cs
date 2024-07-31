using System.Data;
using Barinak.Data;
using Barinak.Data.Abstract;
using Barinak.Entity;
using Barinak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace Barinak.Controllers
{
    public class AnimalsController : Controller
    {
        private IAnimalRepository _animalRepository;
        private ICommentRepository _commentRepository;

        public AnimalsController(IAnimalRepository animalRepository, ICommentRepository commentRepository)
        {
            _animalRepository = animalRepository;
            _commentRepository = commentRepository;
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

        [HttpPost]
        public JsonResult AddComment(int AnimalId, string Text)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                Text = Text,
                PublishedOn = DateTime.Now,
                AnimalId = AnimalId,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreateComment(entity);
            return Json(new
            {
                username,
                Text,
                entity.PublishedOn,
                avatar
            });
        }
    }
}