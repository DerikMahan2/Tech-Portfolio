using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GPFC_Management.Pages.Teams
{
    public class DeletePlayerModel : PageModel
    {
        private readonly GPFCContext _context; // Database context
        private readonly ILogger _logger; // Logging object

        // Model Constructor. Used to bring in _context and logger from Dependency Injection
        public DeletePlayerModel(GPFCContext context, ILogger<DeletePlayerModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Drop down list of all the Players
        public SelectList players { get; set; } = default!;

        // PlayerId to delete. We bind this property because the user will select it in our form and submit it.
        [BindProperty]
        [Display(Name = "Player")]
        public int? PlayerId { get; set; }

        public IActionResult OnGet(int? id)
        {
            // Get all the Players to populate our SelectList drop down
            var teamsWithPlayers = _context.Players.Include(c => c.Team).Select(c => new
            {
                ID = c.PlayerId,
                Display = $"{c.Team!.TeamName}: {c.Name}"
            });
            _logger.LogInformation($"DeletePlayer OnGet() called. PlayerId = '{PlayerId}'. id = '{id}'");

            // Populate SelectList. This variable is brought into the Razor Page with the asp-items tag helper
            players = new SelectList(teamsWithPlayers.ToList(), "ID", "Display", id);
            return Page();
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation($"DeletePlayer OnPost() called. CourseId = '{PlayerId}'.");

            if (PlayerId == null)
            {
                return NotFound();
            }
            // Find the player in the database
            Player c = _context.Players.Find(PlayerId)!;

            if (c != null)
            {
                _context.Players.Remove(c); // Delete the player
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}