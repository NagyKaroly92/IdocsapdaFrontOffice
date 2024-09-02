using BLL.Map;
using DAL.DbSets;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class PlayerDetailsLogic
    {
        public static List<GamePlayerDetails2> GetDetails()
        {
            List<GamePlayerDetails2> returnValue = new List<GamePlayerDetails2>();
            using (var context = new AppDbContext())
            {
                returnValue = context.GamePlayerDetails2.ToList();
            }
            return returnValue;
        }
    }
}
