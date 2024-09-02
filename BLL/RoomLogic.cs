using DAL;
using DAL.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class RoomLogic
    {
        public static List<Room> GetRooms()
        {
            List<Room> rooms = new List<Room>();
            using (var context = new AppDbContext())
            {
                // Adatok lekérdezése és DTO-ba való átalakítása
                 rooms = context.Room
                    .ToList();

            }

            return rooms;
        }
        public static List<string> GetRoomNames()
        {
            List<string> rooms = new List<string>();
            using (var context = new AppDbContext())
            {
                rooms = context.Room.Select(_ => _.Name)
                   .ToList();
            }

            return rooms;
        }
    }
}
