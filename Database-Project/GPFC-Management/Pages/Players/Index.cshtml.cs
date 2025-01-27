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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesGPFC.Models.GPFCContext _context;

        public int PageSize = 10; // Number of items per page
        public int TotalPlayers { get; set; }
        public int CurrentPage { get; set; } = 1; // Default to the first page

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PlayerSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }

        public IList<Player> Players { get; set; }

        public IndexModel(RazorPagesGPFC.Models.GPFCContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int? currentPage, string sortOrder)
        {
            CurrentFilter = SearchString; // Set current filter to the current search string.
            PlayerSort = sortOrder; // Set the current sorting order.

            // Begin with a queryable that selects all players.
            IQueryable<Player> playerIQ = from p in _context.Players
                                          select p;

            // If a search string is not null or empty, filter players by name or team name.
            if (!string.IsNullOrEmpty(SearchString))
            {
                playerIQ = playerIQ.Where(p => p.Name.Contains(SearchString)
                                               || p.Team.TeamName.Contains(SearchString));
            }

            // Sort the players based on the sort order provided.
            switch (sortOrder)
            {
                case "name_desc":
                    playerIQ = playerIQ.OrderByDescending(p => p.Name); // Order by name descending.
                    break;
                case "Age":
                    playerIQ = playerIQ.OrderBy(p => p.Age); // Order by age ascending.
                    break;
                case "age_desc":
                    playerIQ = playerIQ.OrderByDescending(p => p.Age); // Order by age descending.
                    break;
                default:
                    playerIQ = playerIQ.OrderBy(p => p.Name); // Default order by name ascending.
                    break;
            }

            TotalPlayers = await playerIQ.CountAsync(); // Count the total players after filters are applied.

            // Set the current page number, default to first page if not specified.
            if (currentPage.HasValue)
            {
                CurrentPage = currentPage.Value;
            }

            // Execute the filtered and sorted query, including team details, and paginate the results.
            Players = await playerIQ
                .Include(p => p.Team) // Include team data for each player.
                .Skip((CurrentPage - 1) * PageSize) // Skip the players of previous pages.
                .Take(PageSize) // Take only the number of players for the current page.
                .ToListAsync(); // Asynchronously convert the IQueryable to a List.
        }
    }
}
