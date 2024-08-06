using System.ComponentModel.DataAnnotations;

namespace Barinak.Models
{
    public class AnimalCreateViewModel
    {
        public int AnimalId { get; set; }

        [Required]
        [Display(Name = "AnimalName")]
        public string? AnimalName { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string? Content { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string? Url { get; set; }

        public bool IsActive { get; set; }
    }
}