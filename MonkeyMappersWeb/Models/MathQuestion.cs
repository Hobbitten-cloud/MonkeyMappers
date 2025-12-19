namespace MonkeyMappersWeb.Models
{
    public class MathQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }


        // Foreign keys
        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
