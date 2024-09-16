using DAL;
using DAL.DbSets;

namespace BLL
{
    public static class RoomLogic
    {
        // Privát mező az IsEnglish számára
        private static bool _isEnglish = false;

        // Esemény, amely akkor fut le, ha az IsEnglish értéke megváltozik
        public static event EventHandler<bool> IsEnglishChanged;

        // Publikus tulajdonság, amihez hozzáfér a külső kód
        public static bool IsEnglish
        {
            get => _isEnglish;
            set
            {
                if (_isEnglish != value)
                {
                    _isEnglish = value;
                    OnIsEnglishChanged(_isEnglish); // Az esemény meghívása, ha változik az érték
                }
            }
        }

        // Esemény meghívása, amikor az IsEnglish változik
        private static void OnIsEnglishChanged(bool newValue)
        {
            IsEnglishChanged?.Invoke(null, newValue); // null, mert statikus osztályban vagyunk
        }

        public static List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();
            using (var context = new AppDbContext())
            {
                rooms = context.Room.ToList();
            }

            return rooms;
        }

        public static List<string> GetRoomNames()
        {
            List<string> rooms = new List<string>();
            using (var context = new AppDbContext())
            {
                rooms = context.Room.Where(_ => _.IsEnglish == (IsEnglish ? 1 : 0)).Select(_ => _.Name).ToList();
            }

            return rooms;
        }
    }
}
