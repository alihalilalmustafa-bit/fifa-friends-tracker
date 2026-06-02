namespace myprojectbahaa.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public DateTime Date { get; set; }
        public Player? Player1 { get; set; }
        public Player? Player2 { get; set; }
    }
}