using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MonkeyMappersWeb.Data;
using MonkeyMappersWeb.Models;
using MonkeyMappersWeb.Services.IServices;

namespace MonkeyMappersWeb.Services
{
    public class SortService : ISortService
    {
        private DataContext _context;

        public SortService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> SortById()
        {
            return await _context.Players.OrderBy(p => p.Id).ToListAsync();
        }
    }
}
