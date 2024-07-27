using System.ComponentModel.DataAnnotations;

namespace Barinak.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Image { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}