using BLL.Model;
using DAL;
using DAL.DbSets;

namespace BLL.Map
{
    public static class Mapper
    {
        public static Game DTOGameToGameMapper(DTOGame game)
        {
            Game returnValue = new Game();
            using (var context = new AppDbContext())
            {
                returnValue = new Game()
                {
                    RoomId = context.Room.FirstOrDefault(_ => _.Name == game.RoomName).Id,
                    Time = game.Time,
                    Players = game.PlayerNumber
                };
            }
            return returnValue;
        }

        public static Player DTOPlayerToPlayerMapper(DTOPlayer dtoPlayer)
        {
            if (dtoPlayer == null)
                throw new ArgumentNullException(nameof(dtoPlayer));

            // Player objektum létrehozása és a tulajdonságok feltöltése a DTO alapján
            var player = new Player
            {
                GameId = dtoPlayer.GameId ?? 0, // Ha a GameId null, akkor 0-ra állítjuk
                Name = dtoPlayer.Name ?? string.Empty, // Ha a Name null, akkor üres string
                BirthDate = dtoPlayer.BirthDate ?? string.Empty, // Ha a BirthDate null, akkor üres string
                BirthYear = dtoPlayer.BirthYear ?? string.Empty, // Ha a BirthYear null, akkor üres string
                Email = dtoPlayer.Email ?? string.Empty, // Ha az Email null, akkor üres string
                ZipCode = dtoPlayer.ZipCode ?? 0 // Ha a ZipCode null, akkor 0-ra állítjuk
            };

            return player;
        }

        public static List<Player> DTOPlayerListToPlayerListMapper(List<DTOPlayer> players)
            => players.Select(_ => DTOPlayerToPlayerMapper(_)).ToList();
    }
}
