
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PoolApp.Application.Interfaces;
using PoolApp.Domain.Entities;

namespace PoolApp.Infrastructure.Data
{
    public class GamesRepo : IGamesRepo
    {
        private readonly AppDbContext _context;

        public GamesRepo(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<GamesGroups> GetAllGames()
        {
            return _context.Games.AsQueryable();
        }


        public Task UpdateGamesResultsAsync(GamesGroups game)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUsersGuessAsync(UsersGuessGroups usersGuess, int UserID)
        {
            // Check if a guess already exists for this match and user
            var existingGuess = await _context.UsersGuess
                .FirstOrDefaultAsync(c => c.MatchID == usersGuess.MatchID && c.UserID == UserID);

            if (existingGuess != null)
            {
                // Update existing guess
                existingGuess.HomeScore = usersGuess.HomeScore?? 0;
                existingGuess.AwayScore = usersGuess.AwayScore?? 0;
                // EF Core tracks changes automatically
            }
            else
            {
                // No existing guess, insert new
                usersGuess.UserID = UserID;
                usersGuess.HomeScore  = usersGuess.HomeScore ?? 0;
                usersGuess.AwayScore = usersGuess.AwayScore ?? 0;
                await _context.UsersGuess.AddAsync(usersGuess);
            }

            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
    
}
