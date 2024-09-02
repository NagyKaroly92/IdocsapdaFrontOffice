using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbSets
{
    public class Player
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public string BirthYear { get; set; }
        public string Email { get; set; }
        public int ZipCode { get; set; }
    }
}
