using Microsoft.Extensions.Hosting;
using MonkeyMappersWeb.Models;

namespace MonkeyMappersWeb.Services.IServices
{
    public interface ISortService
    {
        Task<List<Player>> SortByPlayDate();
    }
}
