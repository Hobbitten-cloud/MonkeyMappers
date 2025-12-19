using MonkeyMappersWeb.Models;

namespace MonkeyMappersWeb.Repo.IRepo
{
    public interface IPlayerRepo
    {
        public Task<List<Player>> GetAllPlayers();
    }
}
