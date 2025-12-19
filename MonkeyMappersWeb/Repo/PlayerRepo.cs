using Microsoft.EntityFrameworkCore;
using MonkeyMappersWeb.Data;
using MonkeyMappersWeb.Models;
using MonkeyMappersWeb.Repo.IRepo;

namespace MonkeyMappersWeb.Repositories
{
    public class PlayerRepo : IPlayerRepo
    {
        private DataContext _dataContext;
        public PlayerRepo(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await _dataContext.Players.ToListAsync();
        }

        // Additional methods for player data operations can be added here

    }
}
