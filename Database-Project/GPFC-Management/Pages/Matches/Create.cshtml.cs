using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesGPFC.Models;

namespace GPFC_Management.Pages.Matches
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesGPFC.Models.GPFCContext _context;

        public CreateModel(RazorPagesGPFC.Models.GPFCContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AwayTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamName");
            ViewData["HomeTeamId"] = new SelectList(_context.Teams, "TeamId", "TeamName");
            return Page();
        }

        [BindProperty]
        public Match Match { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Matches.Add(Match);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
