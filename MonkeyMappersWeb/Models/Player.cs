namespace MonkeyMappersWeb.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SteamId { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
