using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesGPFC.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string TeamName { get; set; } = string.Empty;

        [Required]
        public string CoachName { get; set; } = string.Empty;

        [Required]
        public string Division { get; set; } = string.Empty;
        public List<Player> Players { get; set; } = new List<Player>();
    }
}