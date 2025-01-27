using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using RazorPagesGPFC.Models;

namespace GPFC_Management.Pages;

// Class to handle the functionality of the Index page.
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;   // Logger for capturing runtime logs.
    private readonly GPFCContext _context;          // Database context for GPFC.

    // List to store team data retrieved from the database.
    public IList<Team> Teams { get; set; }

    // Constructor to initialize logging and database context.
    public IndexModel(ILogger<IndexModel> logger, GPFCContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Method to handle GET request, loads all teams into the Teams list.
    public void OnGet()
    {
        Teams = _context.Teams.ToList();  // Query all teams from the database and convert to list.
    }
}
