using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;

namespace GPFC_Management.Pages.Matches
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesGPFC.Models.GPFCContext _context;

        public DetailsModel(RazorPagesGPFC.Models.GPFCContext context)
        {
            _context = context;
        }

        public Match Match { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Match = await _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .FirstOrDefaultAsync(m => m.MatchId == id);

            if (Match == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
