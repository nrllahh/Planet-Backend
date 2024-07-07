using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Planet.Application.Services.Cryptography;
using Planet.Persistence.Contexts;

namespace Planet.Persistence.Seeding
{
    public static class SeedingExtensions
    {
        public static async Task SeedAsync(this IApplicationBuilder builder, IConfiguration configuration)
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<PlanetContext>();
            var cryptographyService = serviceScope.ServiceProvider.GetRequiredService<ICryptographyService>();

            var users = UserStore.GetUsers(cryptographyService);
            var boards = BoardStore.GetBoards();

            var lists = boards.SelectMany(b => b.Lists);
            var members = boards.SelectMany(b => b.Members);
            var labels = boards.SelectMany(b => b.Labels);
            var listGroups = lists.GroupBy(l => l.BoardId).ToList();
            var memberGroups = members.GroupBy(m => m.BoardId).ToList();
            var labelGroups = labels.GroupBy(l => l.BoardId).ToList();

            var cards = CardStore.GetCards(memberGroups, listGroups, labelGroups);

            if (!context.Users.Any())
            {
                await context.Users.AddRangeAsync(users);
            }
            if (!context.Boards.Any())
            {
                await context.Boards.AddRangeAsync(boards);
            }
            if (!context.Cards.Any())
            {
                await context.Cards.AddRangeAsync(cards);
            }

            await context.SaveChangesAsync();
        }
    }
}
