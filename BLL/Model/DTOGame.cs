namespace BLL.Model
{
    public class DTOGame
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public DateTime Time { get; set; }
        public int PlayerNumber { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Time, RoomName);
        }
    }
}
