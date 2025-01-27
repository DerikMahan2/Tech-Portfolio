using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging; // Ensure ILogger is available
using RazorPagesGPFC.Models;
using System.Threading.Tasks;

namespace GPFC_Management.Pages.Matches
{
    // Class to handle the addition of new matches.
    public class AddMatchModel : PageModel
    {
        private readonly GPFCContext _context; // Database context for GPFC.
        private readonly ILogger<AddMatchModel> _logger; // Logger to log information or errors.

        // Constructor to initialize context and logger.
        public AddMatchModel(GPFCContext context, ILogger<AddMatchModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Match Match { get; set; } // Match object to bind form data.

        public SelectList Teams { get; set; } // List for team dropdown.

        // Method to populate the dropdown lists on GET request.
        public void OnGet()
        {
            Teams = new SelectList(_context.Teams, "TeamId", "TeamName"); // Populate teams dropdown.
        }

        // Asynchronous method to handle the match addition on POST request.
        public async Task<IActionResult> OnPostAsync()
        {
            // Log the HomeTeamId and AwayTeamId at the start of the method.
            _logger.LogInformation("Posting new match: HomeTeamId={HomeTeamId}, AwayTeamId={AwayTeamId}", Match.HomeTeamId, Match.AwayTeamId);

            if (!ModelState.IsValid) // Check if model state is valid.
            {
                // Log each validation error.
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        _logger.LogError("Validation error: {ErrorMessage}", error.ErrorMessage);
                    }
                }

                // Repopulate the dropdowns if needed.
                Teams = new SelectList(_context.Teams, "TeamId", "TeamName");
                return Page(); // Return to page if validation fails.
            }

            try
            {
                _context.Matches.Add(Match); // Add new match to database.
                await _context.SaveChangesAsync(); // Save changes to database.
                return RedirectToPage("./Index"); // Redirect to Index page after successful addition.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save the match"); // Log exception.
                ModelState.AddModelError(string.Empty, "An error occurred saving the match."); // Add error to model state.
                return Page(); // Return to page if exception occurs.
            }
        }
    }
}
