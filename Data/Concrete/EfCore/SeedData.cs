using Barinak.Entity;
using Microsoft.EntityFrameworkCore;

namespace Barinak.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BarinakContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Breeds.Any())
                {
                    context.Breeds.AddRange(
                        new Breed { BreedName = "Dog", Url = "dog", Color = BreedColors.primary },
                        new Breed { BreedName = "Cat", Url = "cat", Color = BreedColors.info },
                        new Breed { BreedName = "Bird", Url = "bird", Color = BreedColors.secondary },
                        new Breed { BreedName = "Fish", Url = "fish", Color = BreedColors.success }
                    );
                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "onuraydinoglu", Name = "Onur AYDINOGLU", Email = "info@onur.com", Password = "123456", Image = "1.jpg" },
                        new User { UserName = "nisanurışık", Name = "Nisa AYDINOGLU", Email = "info@nisa.com", Password = "123456", Image = "2.jpg" }
                    );
                    context.SaveChanges();
                }

                if (!context.Animals.Any())
                {
                    context.Animals.AddRange(
                        new Animal
                        {
                            AnimalName = "Buddy",
                            Content = "A friendly and approachable name, perfect for man's  ...",
                            Age = 3,
                            Url = "buddy",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Breeds = new List<Breed> { context.Breeds.First(b => b.BreedName == "Dog") },
                            Image = "ko1.png",
                            UserId = 1,
                            Comments = new List<Comment>{
                                new Comment {Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. ", PublishedOn = new DateTime(),UserId=1},
                                new Comment {Text = "Lorem Ipsum is simply dummy text of the printing ", PublishedOn = new DateTime(),UserId=2}
                            }
                        },
                        new Animal
                        {
                            AnimalName = "Whiskers",
                            Content = "This name highlights the prominent and ...",
                            Age = 2,
                            Url = "whiskers",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Breeds = new List<Breed> { context.Breeds.First(b => b.BreedName == "Cat") },
                            Image = "ke1.png",
                            UserId = 2
                        },
                        new Animal
                        {
                            AnimalName = "Tweety",
                            Content = "Inspired by the cheerful and melodic sounds birds ...",
                            Age = 2,
                            Url = "tweety",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Breeds = new List<Breed> { context.Breeds.First(b => b.BreedName == "Bird") },
                            Image = "ku1.png",
                            UserId = 1
                        },
                        new Animal
                        {
                            AnimalName = "Bubbles",
                            Content = "Reflecting the playful bubbles fish create as ...",
                            Age = 1,
                            Url = "bubbles",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Breeds = new List<Breed> { context.Breeds.First(b => b.BreedName == "Fish") },
                            Image = "ba1.png",
                            UserId = 1
                        },
                        new Animal
                        {
                            AnimalName = "Max",
                            Content = "A friendly and approachable name, perfect for man's  ...",
                            Age = 3,
                            Url = "max",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-15),
                            Breeds = new List<Breed> { context.Breeds.First(b => b.BreedName == "Dog") },
                            Image = "ko2.png",
                            UserId = 1,
                            Comments = new List<Comment>{
                                new Comment {Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. ", PublishedOn = new DateTime(),UserId=1},
                                new Comment {Text = "Lorem Ipsum is simply dummy text of the printing ", PublishedOn = new DateTime(),UserId=2}
                            }
                        },
                        new Animal
                        {
                            AnimalName = "Oliver",
                            Content = "This name highlights the prominent and ...",
                            Age = 2,
                            Url = "oliver",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Breeds = new List<Breed> { context.Breeds.First(b => b.BreedName == "Cat") },
                            Image = "ke2.png",
                            UserId = 2
                        },
                        new Animal
                        {
                            AnimalName = "Rio",
                            Content = "Inspired by the cheerful and melodic sounds birds ...",
                            Age = 2,
                            Url = "rio",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Breeds = new List<Breed> { context.Breeds.First(b => b.BreedName == "Bird") },
                            Image = "ku2.png",
                            UserId = 1
                        },
                        new Animal
                        {
                            AnimalName = "Finley",
                            Content = "Reflecting the playful bubbles fish create as ...",
                            Age = 1,
                            Url = "finley",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Breeds = new List<Breed> { context.Breeds.First(b => b.BreedName == "Fish") },
                            Image = "ba2.png",
                            UserId = 1
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}