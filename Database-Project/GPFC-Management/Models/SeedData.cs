using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RazorPagesGPFC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GPFCContext(
                serviceProvider.GetRequiredService<DbContextOptions<GPFCContext>>()))
            {
                // Check if any teams exist, if yes, the DB has been seeded
                if (context == null || context.Teams == null)
                {
                    throw new ArgumentException("Null RazorPagesGPFCContext");
                }

                if (context.Teams.Any())
                {
                    return;
                }

                var teams = new[]
                {
                    new Team { TeamName = "U8 Boys Team A", CoachName = "John Doe", Division = "U8" },
                    new Team { TeamName = "U8 Boys Team B", CoachName = "Henry Smith", Division = "U8" },
                    new Team { TeamName = "U8 Girls Team A", CoachName = "Mary Johnson", Division = "U8" },
                    new Team { TeamName = "U8 Girls Team B", CoachName = "Lucy Brown", Division = "U8" },
                    new Team { TeamName = "U10 Boys Team A", CoachName = "Michael Thompson", Division = "U10" },
                    new Team { TeamName = "U10 Boys Team B", CoachName = "Jason Rivera", Division = "U10" },
                    new Team { TeamName = "U10 Girls Team A", CoachName = "Sarah Parker", Division = "U10" },
                    new Team { TeamName = "U10 Girls Team B", CoachName = "Jessica Nguyen", Division = "U10" },
                    new Team { TeamName = "U12 Boys Team A", CoachName = "Robert Lee", Division = "U12" },
                    new Team { TeamName = "U12 Girls Team A", CoachName = "Linda Kim", Division = "U12" },
                    new Team { TeamName = "U12 Boys Team B", CoachName = "Chris Evans", Division = "U12" },
                    new Team { TeamName = "U12 Girls Team B", CoachName = "Emma Stone", Division = "U12" }
                };
                context.Teams.AddRange(teams);
                context.SaveChanges();

                var players = new[]
                {
                    //U8 Boys Team A
                    new Player { Name = "Liam Thompson", TeamId = teams[0].TeamId, Age = 6 },
                    new Player { Name = "Noah Wilson", TeamId = teams[0].TeamId, Age = 7 },
                    new Player { Name = "William Moore", TeamId = teams[0].TeamId, Age = 7 },
                    new Player { Name = "James Taylor", TeamId = teams[0].TeamId, Age = 7 },
                    new Player { Name = "Benjamin Anderson", TeamId = teams[0].TeamId, Age = 6 },
                    new Player { Name = "Lucas Thomas", TeamId = teams[0].TeamId, Age = 7 },
                    new Player { Name = "Mason Hernandez", TeamId = teams[0].TeamId, Age = 7 },
                    new Player { Name = "Ethan King", TeamId = teams[0].TeamId, Age = 7 },
                    new Player { Name = "Alexander Wright", TeamId = teams[0].TeamId, Age = 6 },
                    new Player { Name = "Henry Lopez", TeamId = teams[0].TeamId, Age = 7 },
                    //U8 Girls Team A
                    new Player { Name = "Mia Smith", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Ella Johnson", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Ava Williams", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Sophia Brown", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Isabella Jones", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Charlotte Garcia", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Amelia Martinez", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Evelyn Rodriguez", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Abigail Lee", TeamId = teams[1].TeamId, Age = 7 },
                    new Player { Name = "Harper Perez", TeamId = teams[1].TeamId, Age = 7 },
                    //U8 Boys Team B
                    new Player { Name = "Oliver Davis", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Jack Rivera", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Caleb Lewis", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Gavin Lee", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Logan Walker", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Carter Hall", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Jayden Young", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Mateo Allen", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Ryan King", TeamId = teams[2].TeamId, Age = 7 },
                    new Player { Name = "Nathan Wright", TeamId = teams[2].TeamId, Age = 7 },
                    //U8 Girls Team B
                    new Player { Name = "Grace Hill", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Chloe Scott", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Madison Green", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Daisy Adams", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Leah Nelson", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Zoe Carter", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Lily Mitchell", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Aubrey Roberts", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Yaretzi Robinson", TeamId = teams[3].TeamId, Age = 7 },
                    new Player { Name = "Zoey Clark", TeamId = teams[3].TeamId, Age = 7 },
                    // U10 Boys Team A Players
                    new Player { Name = "Ethan Martinez", TeamId = teams[4].TeamId, Age = 8 },
                    new Player { Name = "Noah Smith", TeamId = teams[4].TeamId, Age = 9 },
                    new Player { Name = "Liam Johnson", TeamId = teams[4].TeamId, Age = 9 },
                    new Player { Name = "Lucas Williams", TeamId = teams[4].TeamId, Age = 8 },
                    new Player { Name = "Mason Brown", TeamId = teams[4].TeamId, Age = 9 },
                    new Player { Name = "Jacob Jones", TeamId = teams[4].TeamId, Age = 9 },
                    new Player { Name = "Michael Garcia", TeamId = teams[4].TeamId, Age = 8 },
                    new Player { Name = "Alexander Davis", TeamId = teams[4].TeamId, Age = 9 },
                    new Player { Name = "Daniel Rodriguez", TeamId = teams[4].TeamId, Age = 9 },
                    new Player { Name = "Benjamin Wilson", TeamId = teams[4].TeamId, Age = 8 },

                    // U10 Boys Team B Players
                    new Player { Name = "Oliver Lee", TeamId = teams[5].TeamId, Age = 9 },
                    new Player { Name = "Samuel Anderson", TeamId = teams[5].TeamId, Age = 8 },
                    new Player { Name = "James Thomas", TeamId = teams[5].TeamId, Age = 9 },
                    new Player { Name = "Henry Jackson", TeamId = teams[5].TeamId, Age = 9 },
                    new Player { Name = "Logan White", TeamId = teams[5].TeamId, Age = 8 },
                    new Player { Name = "Aiden Harris", TeamId = teams[5].TeamId, Age = 9 },
                    new Player { Name = "Gabriel Clark", TeamId = teams[5].TeamId, Age = 9 },
                    new Player { Name = "Jack Lewis", TeamId = teams[5].TeamId, Age = 8 },
                    new Player { Name = "Elijah Walker", TeamId = teams[5].TeamId, Age = 9 },
                    new Player { Name = "Carter Allen", TeamId = teams[5].TeamId, Age = 9 },

                    // U10 Girls Team A Players
                    new Player { Name = "Emma Johnson", TeamId = teams[6].TeamId, Age = 9 },
                    new Player { Name = "Olivia Martinez", TeamId = teams[6].TeamId, Age = 8 },
                    new Player { Name = "Ava Smith", TeamId = teams[6].TeamId, Age = 9 },
                    new Player { Name = "Sophia Brown", TeamId = teams[6].TeamId, Age = 9 },
                    new Player { Name = "Isabella Garcia", TeamId = teams[6].TeamId, Age = 8 },
                    new Player { Name = "Mia Anderson", TeamId = teams[6].TeamId, Age = 9 },
                    new Player { Name = "Charlotte Jones", TeamId = teams[6].TeamId, Age = 9 },
                    new Player { Name = "Amelia Taylor", TeamId = teams[6].TeamId, Age = 9 },
                    new Player { Name = "Harper Moore", TeamId = teams[6].TeamId, Age = 9 },
                    new Player { Name = "Ella Jackson", TeamId = teams[6].TeamId, Age = 9 },

                    // U10 Girls Team B Players
                    new Player { Name = "Evelyn Lee", TeamId = teams[7].TeamId, Age = 8 },
                    new Player { Name = "Abigail Wilson", TeamId = teams[7].TeamId, Age = 9 },
                    new Player { Name = "Emily Young", TeamId = teams[7].TeamId, Age = 9 },
                    new Player { Name = "Elizabeth Hernandez", TeamId = teams[7].TeamId, Age = 9 },
                    new Player { Name = "Mila King", TeamId = teams[7].TeamId, Age = 9 },
                    new Player { Name = "Ella Scott", TeamId = teams[7].TeamId, Age = 9 },
                    new Player { Name = "Avery Wright", TeamId = teams[7].TeamId, Age = 8 },
                    new Player { Name = "Sofia Lopez", TeamId = teams[7].TeamId, Age = 9 },
                    new Player { Name = "Camila Hill", TeamId = teams[7].TeamId, Age = 8 },
                    new Player { Name = "Aria Green", TeamId = teams[7].TeamId, Age = 8 },

                    // U12 Boys Team A Players
                    new Player { Name = "Jacob Taylor", TeamId = teams[8].TeamId, Age = 10 },
                    new Player { Name = "Ethan Lee", TeamId = teams[8].TeamId, Age = 11 },
                    new Player { Name = "Logan Smith", TeamId = teams[8].TeamId, Age = 10 },
                    new Player { Name = "Lucas Brown", TeamId = teams[8].TeamId, Age = 11 },
                    new Player { Name = "Mason Davis", TeamId = teams[8].TeamId, Age = 10 },
                    new Player { Name = "Aiden Wilson", TeamId = teams[8].TeamId, Age = 11 },
                    new Player { Name = "Oliver Martin", TeamId = teams[8].TeamId, Age = 10 },
                    new Player { Name = "Carter Thompson", TeamId = teams[8].TeamId, Age = 11 },
                    new Player { Name = "Jayden White", TeamId = teams[8].TeamId, Age = 10 },
                    new Player { Name = "Dylan Garcia", TeamId = teams[8].TeamId, Age = 11 },
                    new Player { Name = "Leo Harris", TeamId = teams[8].TeamId, Age = 10 },
                    new Player { Name = "Owen Clark", TeamId = teams[8].TeamId, Age = 11 },

                    // U12 Girls Team A Players
                    new Player { Name = "Sophia Moore", TeamId = teams[9].TeamId, Age = 10 },
                    new Player { Name = "Isabella Young", TeamId = teams[9].TeamId, Age = 11 },
                    new Player { Name = "Mia Hernandez", TeamId = teams[9].TeamId, Age = 10 },
                    new Player { Name = "Amelia Walker", TeamId = teams[9].TeamId, Age = 11 },
                    new Player { Name = "Harper Hall", TeamId = teams[9].TeamId, Age = 10 },
                    new Player { Name = "Evelyn Allen", TeamId = teams[9].TeamId, Age = 11 },
                    new Player { Name = "Ava Wright", TeamId = teams[9].TeamId, Age = 10 },
                    new Player { Name = "Abigail King", TeamId = teams[9].TeamId, Age = 11 },
                    new Player { Name = "Emily Scott", TeamId = teams[9].TeamId, Age = 10 },
                    new Player { Name = "Madison Green", TeamId = teams[9].TeamId, Age = 11 },
                    new Player { Name = "Charlotte Adams", TeamId = teams[9].TeamId, Age = 10 },
                    new Player { Name = "Scarlett Nelson", TeamId = teams[9].TeamId, Age = 11 },

                    // New U12 Boys Team B players
                    new Player { Name = "Max Johnson", TeamId = teams[10].TeamId, Age = 11 },
                    new Player { Name = "Sam Lee", TeamId = teams[10].TeamId, Age = 10 },
                    new Player { Name = "Lucas Carter", TeamId = teams[10].TeamId, Age = 11 },
                    new Player { Name = "Jack Murphy", TeamId = teams[10].TeamId, Age = 10 },
                    new Player { Name = "Oscar King", TeamId = teams[10].TeamId, Age = 10 },
                    new Player { Name = "Leo Hill", TeamId = teams[10].TeamId, Age = 10 },
                    new Player { Name = "Finn Davis", TeamId = teams[10].TeamId, Age = 11 },
                    new Player { Name = "Henry Adams", TeamId = teams[10].TeamId, Age = 10 },
                    new Player { Name = "Charlie Brooks", TeamId = teams[10].TeamId, Age = 11 },
                    new Player { Name = "George White", TeamId = teams[10].TeamId, Age = 11 },
                    new Player { Name = "James Wright", TeamId = teams[10].TeamId, Age = 10 },

                    // New U12 Girls Team B players
                    new Player { Name = "Lily Thompson", TeamId = teams[11].TeamId, Age = 10 },
                    new Player { Name = "Grace Martinez", TeamId = teams[11].TeamId, Age = 11 },
                    new Player { Name = "Sophie Taylor", TeamId = teams[11].TeamId, Age = 10 },
                    new Player { Name = "Ruby Anderson", TeamId = teams[11].TeamId, Age = 10 },
                    new Player { Name = "Ella Smith", TeamId = teams[11].TeamId, Age = 11 },
                    new Player { Name = "Chloe Jones", TeamId = teams[11].TeamId, Age = 10 },
                    new Player { Name = "Daisy Brown", TeamId = teams[11].TeamId, Age = 10 },
                    new Player { Name = "Lucy Wilson", TeamId = teams[11].TeamId, Age = 11 },
                    new Player { Name = "Emma Moore", TeamId = teams[11].TeamId, Age = 10 },
                    new Player { Name = "Olivia Clark", TeamId = teams[11].TeamId, Age = 10 },
                    new Player { Name = "Ava Lewis", TeamId = teams[11].TeamId, Age = 11 },
                    new Player { Name = "Mia Nelson", TeamId = teams[11].TeamId, Age = 10 }
                };
                context.Players.AddRange(players);
                context.SaveChanges();

                // Seed initial matches
                // Randomly creating 30 matches ensuring matches are within the same division
                var random = new Random();
                var matches = Enumerable.Range(1, 50).Select(i =>
                {
                    var divisionTeams = teams.Where(t => t.Division == (i % 3 == 0 ? "U12" : (i % 2 == 0 ? "U10" : "U8"))).ToArray(); // Select teams based on division
                    var homeTeam = divisionTeams[random.Next(divisionTeams.Length)]; // Randomly select a home team
                    var awayTeam = divisionTeams.Where(t => t.TeamId != homeTeam.TeamId).ToArray()[random.Next(divisionTeams.Length - 1)]; // Randomly select a away team
                    return new Match
                    {
                        HomeTeamId = homeTeam.TeamId,
                        AwayTeamId = awayTeam.TeamId,
                        MatchTime = DateTime.Now.AddDays(random.Next(1, 100)) // Random match time in the future
                    };
                });
                context.Matches.AddRange(matches);
                context.SaveChanges();
            }
        }
    }
}