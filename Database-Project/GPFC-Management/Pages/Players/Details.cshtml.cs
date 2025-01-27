using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;

namespace GPFC_Management.Pages.Players
{
    // Class to handle the details viewing of a player.
    public class DetailsModel : PageModel
    {
        private readonly GPFCContext _context; // Database context for GPFC.

        // Constructor to initialize the database context.
        public DetailsModel(GPFCContext context)
        {
            _context = context;
        }

        public Player Player { get; set; } = default!; // Player object to bind data.

        // Method to retrieve player details on GET request.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) // Check if player ID is provided.
            {
                return NotFound(); // Return not found if ID is null.
            }

            // Query the database to fetch player details along with related Team data.
            var player = await _context.Players
                                       .Include(p => p.Team) // Eager load the team data related to the player.
                                       .FirstOrDefaultAsync(m => m.PlayerId == id); // Find player by ID.

            if (player == null) // Check if player exists.
            {
                return NotFound(); // Return not found if player does not exist.
            }
            else
            {
                Player = player; // Set the Player property to the retrieved player.
            }
            return Page(); // Return the page to display player details.
        }
    }
}
