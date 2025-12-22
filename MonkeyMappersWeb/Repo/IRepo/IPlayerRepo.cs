using MonkeyMappersWeb.Models;

namespace MonkeyMappersWeb.Repo.IRepo
{
    public interface IPlayerRepo
    {
        public Task<List<Player>> GetAllPlayers();
        public void AddPlayer(Player player);
        public Task ReadPlayersAsync();
    }
}
