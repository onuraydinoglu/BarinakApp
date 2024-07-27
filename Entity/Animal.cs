using System.ComponentModel.DataAnnotations;

namespace Barinak.Entity
{
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }
        public string? AnimalName { get; set; }
        public string? Content { get; set; }
        public int Age { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<Breed> Breeds { get; set; } = new List<Breed>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}