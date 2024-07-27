using System.ComponentModel.DataAnnotations;

namespace Barinak.Entity
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public DateTime PublishedOn { get; set; }
        public int AnimalId { get; set; }
        public Animal Animals { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}