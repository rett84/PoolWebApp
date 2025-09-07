using Microsoft.AspNetCore.Mvc;

using PoolApp.Domain.Entities;

namespace PoolApp.Application.Interfaces
{
    public interface IGamesRepo
    {
        IQueryable<GamesGroups> GetAllGames();
        IQueryable<UsersGuessGroups> GetAllUsersGuess();
        Task UpdateGamesResultsAsync(GamesGroups game);
        Task UpdateUsersGuessAsync(UsersGuessGroups usersGuess, int UserID);
    }
}
