using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MonkeyMappersWeb.Data;
using MonkeyMappersWeb.Models;
using MonkeyMappersWeb.Repo.IRepo;
using System;
using System.Data;

namespace MonkeyMappersWeb.Repositories
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly string _connectionString;
        private DataContext _dataContext;
        public PlayerRepo(DataContext context)
        {
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = config.GetConnectionString("MyDBConnection");

            _dataContext = context;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await _dataContext.Players.ToListAsync();
        }

        public void AddPlayer(Player player)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Players (Name, SteamId)" + "VALUES(@Name, @SteamId)" + "SELECT @@IDENTITY", con))
                {
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = player.Name;
                    cmd.Parameters.Add("@SteamId", SqlDbType.NVarChar).Value = player.SteamId;

                    player.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public async Task ReadPlayersAsync()
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();

                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string url = "https://github.com/NiDE-gg/ZE-Configs/tree/master/cstrike/scripts/vscripts/ze_monkey_mappers2/playerstats/player.txt";
                        string content = await client.GetStringAsync(url);

                        using (StringReader sr = new StringReader(content))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                string[] parts = line.Split(';');
                                if (parts.Length == 2)
                                {
                                    Player player = new Player
                                    {
                                        Name = parts[0].Trim(),
                                        SteamId = parts[1].Trim()
                                    };

                                    AddPlayer(player);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

    }
}
