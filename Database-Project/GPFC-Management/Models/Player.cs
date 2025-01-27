using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesGPFC.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        // Foreign key
        public int TeamId { get; set; }

        // Navigation property
        public Team? Team { get; set; }
    }
}