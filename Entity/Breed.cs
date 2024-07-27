using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Barinak.Entity
{
    public enum BreedColors
    {
        primary, secondary, warning, danger, info, success
    }
    public class Breed
    {
        [Key]
        public int BreedId { get; set; }
        public string? BreedName { get; set; }
        public string? Url { get; set; }
        public BreedColors? Color { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
}
