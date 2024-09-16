namespace DAL.DbSets
{
    public class Game
    {
        public int Id { get; set; }
        public int Players { get; set; }
        public int RoomId { get; set; }
        public DateTime Time { get; set; }
        public int IsEnglish { get; set; }
    }
}
