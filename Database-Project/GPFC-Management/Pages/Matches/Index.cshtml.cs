using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesGPFC.Models;

namespace GPFC_Management.Pages.Matches
{
    // Class to handle the display of matches on the Index page.
    public class IndexModel : PageModel
    {
        private readonly GPFCContext _context; // Database context for GPFC.

        public int PageSize = 10; // Number of matches per page.
        public int TotalMatches { get; set; } // Total number of matches.
        public int CurrentPage { get; set; } = 1; // Default to the first page.

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } // Search string to filter matches.

        [BindProperty(SupportsGet = true)]
        public string MatchSort { get; set; } // Sort order for displaying matches.

        public IList<Match> Matches { get; set; } // List to store match data.

        // Constructor to initialize the database context.
        public IndexModel(GPFCContext context)
        {
            _context = context;
        }

        // Asynchronous method to handle GET request with paging and sorting.
        public async Task OnGetAsync(int? currentPage, string sortOrder)
        {
            IQueryable<Match> matchIQ = from m in _context.Matches
                                        .Include(m => m.AwayTeam)
                                        .Include(m => m.HomeTeam)
                                        select m; // Query to select all matches with team details.

            if (!string.IsNullOrEmpty(SearchString)) // Apply search filter if provided.
            {
                matchIQ = matchIQ.Where(m => m.AwayTeam.TeamName.Contains(SearchString)
                                        || m.HomeTeam.TeamName.Contains(SearchString));
            }

            switch (sortOrder) // Apply sorting based on sort order.
            {
                case "date_desc":
                    matchIQ = matchIQ.OrderByDescending(m => m.MatchTime); // Sort by match time in descending order.
                    break;
                default:
                    matchIQ = matchIQ.OrderBy(m => m.MatchTime); // Sort by match time in ascending order.
                    break;
            }

            TotalMatches = await matchIQ.CountAsync(); // Count the total filtered matches.

            if (currentPage.HasValue) // Check if a specific page is requested.
            {
                CurrentPage = currentPage.Value; // Set the current page.
            }

            Matches = await matchIQ.Skip((CurrentPage - 1) * PageSize) // Skip matches for previous pages.
                                   .Take(PageSize) // Take only the number of matches for the current page.
                                   .ToListAsync(); // Execute the query and convert to list.
        }
    }
}
