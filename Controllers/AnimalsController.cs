using System.Data;
using Barinak.Data;
using Barinak.Data.Abstract;
using Barinak.Entity;
using Barinak.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


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
            var animals = _animalRepository.Animals.Where(i => i.IsActive);

            if (!string.IsNullOrEmpty(breed))
            {
                animals = animals.Where(x => x.Breeds.Any(t => t.Url == breed));
            }

            return View(new AnimalViewModel { Animals = await animals.ToListAsync() });
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _animalRepository.Animals.Include(x => x.User).Include(x => x.Breeds).Include(x => x.Comments).ThenInclude(x => x.User).FirstOrDefaultAsync(p => p.Url == url));
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

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(AnimalCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _animalRepository.CreateAnimal(
                    new Animal
                    {
                        AnimalName = model.AnimalName,
                        Content = model.Content,
                        Age = model.Age,
                        Url = model.Url,
                        UserId = int.Parse(userId ?? ""),
                        Image = "ko1.png",
                        IsActive = false
                    }
                );
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var role = User.FindFirstValue(ClaimTypes.Role);

            var animals = _animalRepository.Animals;

            if (string.IsNullOrEmpty(role))
            {
                animals = animals.Where(i => i.UserId == userId);
            }

            return View(await animals.ToListAsync());
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = _animalRepository.Animals.FirstOrDefault(i => i.AnimalId == id);

            if (animal == null)
            {
                return NotFound();
            }

            return View(
                new AnimalCreateViewModel
                {
                    AnimalId = animal.AnimalId,
                    AnimalName = animal.AnimalName,
                    Content = animal.Content,
                    Age = animal.Age,
                    Url = animal.Url,
                    IsActive = animal.IsActive
                });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(AnimalCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entityUpdate = new Animal
                {
                    AnimalId = model.AnimalId,
                    AnimalName = model.AnimalName,
                    Content = model.Content,
                    Age = model.Age,
                    Url = model.Url,
                    IsActive = model.IsActive
                };

                if (User.FindFirstValue(ClaimTypes.Role) == "admin")
                {
                    entityUpdate.IsActive = model.IsActive;
                }
                _animalRepository.EditAnimal(entityUpdate);
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}
