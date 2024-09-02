using BLL.Map;
using BLL.Model;
using DAL;

namespace BLL
{
    public static class GameLogic
    {
        public static void SaveGame(DTOGame game)
        {
            using (var context = new AppDbContext())
            {
                context.Game.Add(Mapper.DTOGameToGameMapper(game));
                context.SaveChanges();
            }
        }

        public static int GetLastId()
        {
            int returnId;
            using (var context = new AppDbContext())
            {
                returnId = context.Game.Max(_ => _.Id);
            }
            return returnId;
        }
        public static List<DTOGame> GetGames()
        {
            List<DTOGame> returnValue = new List<DTOGame>();
            using (var context = new AppDbContext())
            {
                returnValue = context.Game.Select(_ => new DTOGame()
                {
                    PlayerNumber = _.Players,
                    RoomName = context.Room.FirstOrDefault(e => e.Id == _.RoomId).Name,
                    Time = _.Time,
                    Id = _.Id
                })
                    .OrderByDescending(_ => _.Id)
                    .ToList();
            }
            return returnValue;
        }

    }
}
