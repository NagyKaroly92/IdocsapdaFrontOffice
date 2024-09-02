using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Model
{
    public class DTOPlayer
    {
        public int? GameId { get; set; }
        public string? Name { get; set; }
        public string? BirthYear { get; set; }
        public string? BirthDate { get; set; }
        public string? Email { get; set; }
        public int? ZipCode { get; set; }
        public bool Accept1 { get; set; }
        public bool Accept2 { get; set; }
        public bool IsValid { get; set; }
    }
}
