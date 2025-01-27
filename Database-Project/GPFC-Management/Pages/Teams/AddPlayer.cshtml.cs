using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GPFC_Management.Pages.Teams
{
    // Class to handle the functionality of the Add Player page.
    public class AddPlayerModel : PageModel
    {
        private readonly ILogger<AddPlayerModel> _logger; // Logger for capturing runtime logs.
        private readonly GPFCContext _context; // Database context for GPFC.

        [BindProperty]
        public Player Player { get; set; } = default!; // Player object to bind form data.

        public SelectList TeamsDropDown { get; set; } = default!; // List for teams dropdown.

        // Constructor to initialize context and logger.
        public AddPlayerModel(GPFCContext context, ILogger<AddPlayerModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Method to prepare the teams dropdown when the GET request is made.
        public void OnGet()
        {
            TeamsDropDown = new SelectList(_context.Teams.ToList(), "TeamId", "TeamName"); // Populate teams dropdown.
        }

        // Method to handle POST request on form submission.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) // Check if model state is valid.
            {
                return Page(); // Return to page if validation fails.
            }

            _context.Players.Add(Player); // Add new player to database.
            _context.SaveChanges(); // Save changes to database.

            return RedirectToPage("./Index"); // Redirect to Index page.
        }
    }
}
