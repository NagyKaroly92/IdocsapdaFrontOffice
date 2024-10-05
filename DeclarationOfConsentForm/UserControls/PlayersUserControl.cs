using BLL;
using BLL.Model;
using DeclarationOfConsentForm.Controls;
using DeclarationOfConsentForm.Model;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Forms;

namespace DeclarationOfConsentForm.UserControls
{
    public partial class PlayersUserControl : UserControl
    {
        private int gameId;
        private int selectedItem = 0;
        private Font previousFont = null;

        private BindingList<DTOPlayer> Players = new BindingList<DTOPlayer>();

        public event EventHandler ButtonClicked;

        public PlayersUserControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        public PlayersUserControl(DTOGameControl game)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.gameId = game.GameId;

            this.listBox.DrawMode = DrawMode.OwnerDrawFixed; // Egyéni rajzolási mód bekapcsolása

            this.listBox.MeasureItem += listBox_MeasureItem; // Sor magasság mérése esemény
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged; // Regisztráljuk a SelectedIndexChanged eseményt

            if (RoomLogic.IsEnglish)
            {
                SetLabelsToEnglish();
                for (int i = 1; i <= game.PlayerNumbers; i++)
                {
                    this.listBox.Items.Add($"Player {i}");

                    this.Players.Add(
                        new DTOPlayer
                        {
                            GameId = game.GameId,
                            Accept1 = true,
                            Accept2 = true,
                            IsValid = false
                        });
                }

                //this.listView1.SelectedItems.Clear();
                //this.listView1.Items[selectedItem].Selected = true;

            }
            else
            {
                for (int i = 1; i <= game.PlayerNumbers; i++)
                {
                    this.listBox.Items.Add($"{i}. Játékos");

                    //this.listView1.Items.Add($"{i}. Játékos");
                    //this.listView1.Items[i - 1].BackColor = Color.Coral;

                    this.Players.Add(
                        new DTOPlayer
                        {
                            GameId = game.GameId,
                            IsValid = false
                        });
                }
            }

            if (RoomLogic.IsEnglish)
            {
                SetLabelsToEnglish();
            }
            UpdateListBoxHeight();
            listBox.SelectedItems.Add(listBox.Items[0]);
        }
        
        private void SavePlayerData(int index)
        {
            int a = 0;

            // Aktuális játékos adatainak mentése
            this.Players[index].Name = string.IsNullOrWhiteSpace(tb_Name.Text) || tb_Name.Text == tb_Name.PlaceholderText ? string.Empty : tb_Name.Text;
            this.Players[index].Email = String.Format("{0}@{1}", this.tb_Email1.Text, this.tb_Email2.Text);//string.IsNullOrWhiteSpace(tb_Email.Text) || tb_Email.Text == tb_Email.PlaceholderText ? string.Empty : tb_Email.Text;
            this.Players[index].BirthDate = string.IsNullOrWhiteSpace(tb_BirthDate.Text) || tb_BirthDate.Text == tb_BirthDate.PlaceholderText ? string.Empty : tb_BirthDate.Text;
            this.Players[index].BirthYear = string.IsNullOrWhiteSpace(tb_BirthYear.Text) || tb_BirthYear.Text == tb_BirthYear.PlaceholderText ? string.Empty : tb_BirthYear.Text;

            if (!string.IsNullOrEmpty(this.tb_ZipCode.Text) && int.TryParse(this.tb_ZipCode.Text, out a))
            {
                this.Players[index].ZipCode = int.Parse(this.tb_ZipCode.Text);
            }
            else
            {
                this.Players[index].ZipCode = null;
            }

            // Checkbox értékek mentése
            this.Players[index].Accept1 = this.checkBox1.Checked;
            this.Players[index].Accept2 = this.checkBox2.Checked;

            // Itt validáljuk a játékost, ha tényleges adatváltozás történt
            Validate(this.Players[index]);
        }

        private void LoadPlayerData(int index)
        {
            // Mezők kiürítése
            this.tb_Name.Text = this.Players[index].Name ?? string.Empty;
            //this.tb_Email.Text = this.Players[index].Email ?? string.Empty;
            if (String.IsNullOrEmpty(this.Players[index].Email))
            {
                this.tb_Email1.Text = "";
                this.tb_Email2.Text = "";
            }
            else
            {
                this.tb_Email1.Text = this.Players[index].Email.Split('@')[0];
                this.tb_Email2.Text = this.Players[index].Email.Split('@')[1];
            }
            
            this.tb_BirthDate.Text = this.Players[index].BirthDate ?? string.Empty;
            this.tb_BirthYear.Text = this.Players[index].BirthYear ?? string.Empty;
            this.tb_ZipCode.Text = this.Players[index].ZipCode?.ToString() ?? string.Empty;

            this.checkBox1.Checked = this.Players[index].Accept1;
            this.checkBox2.Checked = this.Players[index].Accept2;

            // Placeholder frissítése
            this.tb_Name.UpdatePlaceholder();
            this.tb_Email.UpdatePlaceholder();
            this.tb_BirthYear.UpdatePlaceholder();
            this.tb_BirthDate.UpdatePlaceholder();
            this.tb_ZipCode.UpdatePlaceholder();

            // Csak akkor validálunk, ha szükséges, pl. ha a mezők tartalma módosul.
            // Itt az előző validálásokat alapértelmezetten elfogadjuk, és nem indítjuk újra a validálást.
            // Ha valóban változik valami, a SavePlayerData metódusban kell majd újra validálni.
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RoomLogic.IsEnglish)
            {
                OpenBrowserDialog("nyilatkozat_eng.html");
            }
            else
            {
                OpenBrowserDialog("nyilatkozat_hun.html");
            }
        }

        private void Validate(DTOPlayer player)
        {
            this.tb_Name.BackColor = Color.White;
            this.tb_Email.BackColor = Color.White;
            this.tb_ZipCode.BackColor = Color.White;
            this.tb_BirthYear.BackColor = Color.White;
            this.tb_BirthDate.BackColor = Color.White;

            player.IsValid = true;
            int a = 0;

            if (string.IsNullOrEmpty(player.Name) || player.Name == tb_Name.PlaceholderText || player.Name.Split(' ').Count() < 2)
            {
                this.tb_Name.BackColor = Color.PeachPuff;
                player.IsValid = false;
            }
            if (string.IsNullOrEmpty(player.Email) || (ContainsDiacritics(player.Email) || (player.Email == tb_Email.PlaceholderText || !player.Email.Contains('@') || !player.Email.Contains('.'))))
            {
                this.tb_Email.BackColor = Color.PeachPuff;
                this.tb_Email1.BackColor = Color.PeachPuff;
                this.tb_Email2.BackColor = Color.PeachPuff;

                if (!string.IsNullOrEmpty(player.Email) && player.Email != tb_Email.PlaceholderText)
                {
                    player.IsValid = false;
                }
            }
            if (string.IsNullOrEmpty(tb_BirthDate.Text) || tb_BirthDate.Text == tb_BirthDate.PlaceholderText || !(tb_BirthDate.Text.Length == 5 && tb_BirthDate.Text.Split('.')[0].Length == 2))
            {
                this.tb_BirthDate.BackColor = Color.PeachPuff;
                player.IsValid = false;
            }
            if (string.IsNullOrEmpty(player.BirthYear) || player.BirthYear == tb_BirthYear.PlaceholderText || player.BirthYear.Length != 4)
            {
                this.tb_BirthYear.BackColor = Color.PeachPuff;
                player.IsValid = false;
            }
            if (!player.Accept1)
            {
                player.IsValid = false;
            }
            if (!player.Accept2)
            {
                player.IsValid = false;
            }
            if (string.IsNullOrEmpty(tb_ZipCode.Text) || tb_ZipCode.Text == tb_ZipCode.PlaceholderText || !int.TryParse(tb_ZipCode.Text, out a))
            {
                this.tb_ZipCode.BackColor = Color.PeachPuff;
                player.IsValid = false;
            }

            if (player.IsValid)
            {
                //this.listView1.Items[selectedItem].BackColor = Color.LightGreen;
            }

            this.pictureBox2.Visible = true;
            this.label1.Visible = true;
            this.pictureBox1.Visible = false;
            foreach (var item in this.Players)
            {
                //TODO E-mail validáció üres stringre
                if (!item.IsValid)
                {
                    this.pictureBox2.Visible = false;
                    this.label1.Visible = false;
                    this.pictureBox1.Visible = true;
                }
            }
        }

        private void OpenBrowserDialog(string filePath)
        {
            // Új Form létrehozása
            Form browserForm = new Form();
            browserForm.Text = "Web Page Viewer";
            browserForm.Size = new Size(800, 600);
            browserForm.StartPosition = FormStartPosition.CenterScreen;
            browserForm.WindowState = FormWindowState.Maximized;
            browserForm.ControlBox = true;
            browserForm.MinimizeBox = false;
            browserForm.MaximizeBox = false;

            // WebBrowser vezérlő létrehozása
            WebBrowser webBrowser = new WebBrowser();
            webBrowser.Dock = DockStyle.Fill;

            // Lokális fájl elérési útjának megszerzése
            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);

            // A fájl elérési útjának megadása a WebBrowser számára
            webBrowser.Navigate($"file:///{fullPath}");

            // WebBrowser hozzáadása a Form-hoz
            browserForm.Controls.Add(webBrowser);

            // Megjeleníti az új formot
            browserForm.ShowDialog();
        }

        private bool ContainsDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return false;

            // Normalizáljuk a szöveget a Unicode Normalization Form D (NFD) formára
            string normalizedText = text.Normalize(NormalizationForm.FormD);

            // Regex, amely az ékezetes karakterekre keres
            string diacriticPattern = @"[\p{M}]";

            return Regex.IsMatch(normalizedText, diacriticPattern);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RoomLogic.IsEnglish)
            {
                Players
                .Where(_ => _.Email == "e.g.: example@example.com")
                .ToList()
                .ForEach(_ => _.Email = "");
                PlayerLogic.SavePlayers(Players
                                            .Where(_ => _.GameId > int.Parse(SettingsLogic.GetSetting("EnglishLastRow")))
                                            .OrderBy(_ => _.GameId)
                                            .ToList());

                // Indítjuk a 2 perces időzítőt
                System.Timers.Timer timer = new System.Timers.Timer(120000); // 120 000 ms = 2 perc
                timer.Elapsed += Timer_Elapsed;
                timer.AutoReset = false; // Az időzítő csak egyszer fusson le
                timer.Start();

                // Megjelenítjük a MessageBox-ot
                DialogResult result = CustomMessageBox.Show("Thank You!\nYour game master \nwill be coming soon!", "Save Success!");

                // Ha a felhasználó az "OK" gombra kattint, leállítjuk az időzítőt és meghívjuk a Method1 metódust
                if (result == DialogResult.OK)
                {
                    timer.Stop();
                    EventHandler();
                }
            }
            else
            {
                Players
                .Where(_ => _.Email == "pl.: pelda@example.com")
                .ToList()
                .ForEach(_ => _.Email = "");
                PlayerLogic.SavePlayers(Players
                                            .Where(_ => _.GameId > int.Parse(SettingsLogic.GetSetting("LastRow")))
                                            .OrderBy(_ => _.GameId)
                                            .ToList());

                // Indítjuk a 2 perces időzítőt
                System.Timers.Timer timer = new System.Timers.Timer(120000); // 120 000 ms = 2 perc
                timer.Elapsed += Timer_Elapsed;
                timer.AutoReset = false; // Az időzítő csak egyszer fusson le
                timer.Start();

                // Megjelenítjük a MessageBox-ot
                DialogResult result = CustomMessageBox.Show("Köszönjük!\nA játékmesteretek hamarosan \njelentkezik!", "Mentés kész!");

                // Ha a felhasználó az "OK" gombra kattint, leállítjuk az időzítőt és meghívjuk a Method1 metódust
                if (result == DialogResult.OK)
                {
                    timer.Stop();
                    EventHandler();
                }
            }

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Ha az időzítő lejár, meghívjuk a Method1 metódust a UI szálon
            this.Invoke(new Action(EventHandler));
        }
        private void EventHandler()
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //Validate(this.Players[listView1.SelectedItems[0].Index]);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //Validate(this.Players[listView1.SelectedItems[0].Index]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Adatok mentése
            SavePlayerData(selectedItem);

            // Frissítjük az aktuális játékos adatait
            this.Players[selectedItem].Name = this.tb_Name.Text;
            this.Players[selectedItem].Email = this.tb_Email.Text;
            this.Players[selectedItem].BirthDate = tb_BirthDate.Text;
            this.Players[selectedItem].BirthYear = tb_BirthYear.Text;

            if (!string.IsNullOrEmpty(this.tb_ZipCode.Text) && this.tb_ZipCode.Text != this.tb_ZipCode.PlaceholderText)
            {
                this.Players[selectedItem].ZipCode = int.Parse(this.tb_ZipCode.Text);
            }
            this.Players[selectedItem].Accept1 = this.checkBox1.Checked;
            this.Players[selectedItem].Accept2 = this.checkBox2.Checked;

            // Ellenőrizzük az összes játékost és frissítjük a színeket
            foreach (var player in Players)
            {
                Validate(player);  // Validálás
            }
            if (listBox.SelectedIndex < listBox.Items.Count-1)
            {
                listBox.SelectedIndex++;
            }
            listBox.Invalidate();
        }

        private void SetLabelsToEnglish()
        {
            l_Name.Text = "Name";
            l_Email.Text = "Email";
            l_BirthDate.Text = "Birth Date";
            l_BirthYear.Text = "Birth Year";
            l_ZipCode.Text = "ZIP Code";
            checkBox1.Text = "I accept terms and conditions.";
            checkBox2.Text = "I have received and acknowledged the ";
            linkLabel1.Text = "privacy notice.";

            tb_Name.Text = "";
            tb_Name.PlaceholderText = "e.g.: John Doe";
            tb_Name.UpdatePlaceholder();

            tb_Email.Text = "";
            tb_Email.PlaceholderText = "e.g.: example@example.com";
            tb_Email.UpdatePlaceholder();

            tb_BirthYear.Text = "";
            tb_BirthYear.PlaceholderText = "e.g.: 1995";
            tb_BirthYear.UpdatePlaceholder();

            tb_BirthDate.Text = "";
            tb_BirthDate.PlaceholderText = "e.g.: 10.25";
            tb_BirthDate.UpdatePlaceholder();

            tb_ZipCode.Text = "";
            tb_ZipCode.PlaceholderText = "e.g.: 1075";
            tb_ZipCode.UpdatePlaceholder();

            linkLabel1.Location = new Point(linkLabel1.Location.X + 165, linkLabel1.Location.Y);
        }

        // MeasureItem eseménykezelő a dinamikus sor magassághoz
        /*
        private void listBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Kiválasztjuk a betűméretet a kijelöltség alapján
            if (listBox.SelectedIndex == e.Index)
            {
                // Kijelölt elem esetén nagyobb betűméret
                using (Font selectedFont = new Font(listBox.Font.FontFamily, listBox.Font.Size + 6, FontStyle.Bold))
                {
                    e.ItemHeight = selectedFont.Height + 10; // Magasság a betűmérethez igazítva
                }
            }
            else
            {
                // Nem kijelölt elem normál magasság
                e.ItemHeight = listBox.Font.Height + 4; // Normál magasság
            }
        }*/

        private void listBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Kiválasztjuk a betűméretet a kijelöltség alapján
            if (listBox.SelectedIndex == e.Index)
            {
                // Kijelölt elem esetén nagyobb betűméret
                using (Font selectedFont = new Font(listBox.Font.FontFamily, listBox.Font.Size + 6, FontStyle.Bold))
                {
                    e.ItemHeight = selectedFont.Height + 10; // Magasság a betűmérethez igazítva
                }
            }
            else
            {
                // Nem kijelölt elem normál magasság
                e.ItemHeight = listBox.Font.Height + 4; // Normál magasság
            }
        }

        // DrawItem eseménykezelő az elemek egyedi megjelenítéséhez
        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Megkapjuk a játékos objektumot a listában lévő index alapján
            DTOPlayer player = Players[e.Index];

            // Háttér szín beállítása
            if (player.IsValid)
            {
                // Érvényes játékos - zöld háttér
                e.Graphics.FillRectangle(Brushes.LightGreen, e.Bounds);
            }
            else
            {
                // Nem érvényes játékos - piros háttér
                e.Graphics.FillRectangle(Brushes.Tomato, e.Bounds);
            }

            // Szöveg magasságának meghatározása
            SizeF textSize = e.Graphics.MeasureString(listBox.Items[e.Index].ToString(), e.Font);
            float textY = e.Bounds.Y + (e.Bounds.Height - textSize.Height) / 2; // Középre igazítás

            // Szöveg megjelenítése: ha ki van jelölve, nagyobb betűméret, különben normál
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                // Kijelölt elem nagyobb betűmérettel
                using (Font selectedFont = new Font(e.Font.FontFamily, e.Font.Size + 4, FontStyle.Bold))
                {
                    e.Graphics.DrawString(listBox.Items[e.Index].ToString(), selectedFont, Brushes.Black, e.Bounds.X, textY);
                }
            }
            else
            {
                // Nem kijelölt elem normál betűmérettel
                e.Graphics.DrawString(listBox.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds.X, textY);
            }

            // Keret rajzolása az elem köré
            e.DrawFocusRectangle();
        }
        
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex >= 0)  // Ellenőrizzük, hogy van-e kijelölt elem
            {
                // Először mentjük az aktuális játékos adatait
                SavePlayerData(selectedItem);

                // Beállítjuk az új kijelölt játékos indexét
                selectedItem = listBox.SelectedIndex;

                // Betöltjük az új játékos adatait a felületre
                LoadPlayerData(selectedItem);

                // NEM kell minden játékost újra validálni a váltás során.
                // Validálás csak akkor történik, amikor tényleges adatváltozás történik, pl. amikor a mezők értékét a felhasználó módosítja.
            }
        }
        private void UpdateListBoxHeight()
        {
            // Számoljuk meg, hány elem van a listában
            int itemCount = listBox.Items.Count;

            // Maximális magasság pixelben
            int maxHeight = 1110; // Ezt a számot állítsd be a kívánt maximális magasságra

            // Ha vannak elemek, számoljuk ki az elem magasságát
            if (itemCount > 0)
            {
                // Számoljuk ki a ListBox magasságát az elemek száma alapján
                int newHeight = (itemCount-2) * listBox.ItemHeight;

                // Ha az új magasság meghaladja a maximális magasságot, akkor korlátozzuk a maximális magasságra
                listBox.Height = Math.Min(newHeight, maxHeight);
            }
        }
    }
}
