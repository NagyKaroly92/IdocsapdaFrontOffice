using BLL.Map;
using BLL.Model;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PlayerLogic
    {
        public static void SavePlayers(List<DTOPlayer> players)
        {
            using (var context = new AppDbContext())
            {
                context.Player.AddRange(Mapper.DTOPlayerListToPlayerListMapper(players));
                context.SaveChanges();
            }
        }

        public static List<DTOPlayer> GetPlayers(int gameId)
        {
            using (var context = new AppDbContext())
            {
                return context.Player.Where(_ => _.GameId == gameId).Select(_ => new DTOPlayer()
                {
                    Name = _.Name,
                    BirthDate = _.BirthDate,
                    BirthYear = _.BirthYear,
                    Email = _.Email
                }
                ).ToList();
            }
        }
    }
}
