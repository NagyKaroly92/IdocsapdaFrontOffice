namespace DAL.DbSets
{
    public class GamePlayerDetails2
    {
        private DateTime _gameStartTime;

        // Játék részletei
        public DateTime TimeStamp { get; set; } // SQL DATETIME -> string
        public string RoomName { get; set; }
        public string GameStartTime
        {
            get => _gameStartTime.ToString("HH:mm");
            set
            {
                // Konvertálás DateTime típusra
                _gameStartTime = DateTime.ParseExact(value, "HH:mm", null);
            }
        } // SQL TIME (formatted) -> string
        public int TeamSize { get; set; } // SQL INT -> int

        // Játékos 1 adatai
        public string Email1 { get; set; }
        public string Name1 { get; set; }
        public string BirthDate1 { get; set; } // SQL VARCHAR -> string (hónap / nap)
        public string BirthYear1 { get; set; }
        public string ZipCode1 { get; set; } // SQL INT -> int

        // Játékos 2 adatai
        public string Email2 { get; set; }
        public string Name2 { get; set; }
        public string BirthDate2 { get; set; } // SQL VARCHAR -> string (hónap / nap)
        public string BirthYear2 { get; set; }
        public string ZipCode2 { get; set; } // SQL INT -> int

        // Játékos 3 adatai
        public string Email3 { get; set; }
        public string Name3 { get; set; }
        public string BirthDate3 { get; set; } // SQL VARCHAR -> string (hónap / nap)
        public string BirthYear3 { get; set; }
        public string ZipCode3 { get; set; } // SQL INT -> int

        // Játékos 4 adatai
        public string Email4 { get; set; }
        public string Name4 { get; set; }
        public string BirthDate4 { get; set; } // SQL VARCHAR -> string (hónap / nap)
        public string BirthYear4 { get; set; }
        public string ZipCode4 { get; set; } // SQL INT -> int

        // Játékos 5 adatai
        public string Email5 { get; set; }
        public string Name5 { get; set; }
        public string BirthDate5 { get; set; } // SQL VARCHAR -> string (hónap / nap)
        public string BirthYear5 { get; set; }
        public string ZipCode5 { get; set; } // SQL INT -> int

        // Játékos 6 adatai
        public string Email6 { get; set; }
        public string Name6 { get; set; }
        public string BirthDate6 { get; set; } // SQL VARCHAR -> string (hónap / nap)
        public string BirthYear6 { get; set; }
        public string ZipCode6 { get; set; } // SQL INT -> int

        // Játékos 7 adatai
        public string Email7 { get; set; }
        public string Name7 { get; set; }
        public string BirthDate7 { get; set; } // SQL VARCHAR -> string (hónap / nap)
        public string BirthYear7 { get; set; }
        public string ZipCode7 { get; set; } // SQL INT -> int

        // Játékos 8 adatai
        public string Email8 { get; set; }
        public string Name8 { get; set; }
        public string BirthDate8 { get; set; } // SQL VARCHAR -> string (hónap / nap)
        public string BirthYear8 { get; set; }
        public string ZipCode8 { get; set; } // SQL INT -> int

        // Játékszabályzat és adatvédelem
        public string Consent1 { get; set; }
        public string Consent2 { get; set; }
        public string Consent3 { get; set; }
        public string Consent4 { get; set; }
        public string Consent5 { get; set; }
        public string Consent6 { get; set; }
        public string Consent7 { get; set; }
        public string Consent8 { get; set; }
    }

}

