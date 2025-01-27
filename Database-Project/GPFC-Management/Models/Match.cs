using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesGPFC.Models
{
    public class Match
{
    public int MatchId { get; set; }

    [Required(ErrorMessage = "Home team is required.")]
    public int HomeTeamId { get; set; }

    [Required(ErrorMessage = "Away team is required.")]
    public int AwayTeamId { get; set; }

    [Required]
    public DateTime MatchTime { get; set; }

    [ForeignKey("HomeTeamId")]
    public Team ?HomeTeam { get; set; }

    [ForeignKey("AwayTeamId")]
    public Team ?AwayTeam { get; set; }
}


}