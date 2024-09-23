using BLL;
using BLL.Model;
using DeclarationOfConsentForm.Controls;
using DeclarationOfConsentForm.Model;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;

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

            if (RoomLogic.IsEnglish)
            {
                SetLabelsToEnglish();
                for (int i = 1; i <= game.PlayerNumbers; i++)
                {
                    this.listView1.Items.Add($"Player {i}");
                    this.listView1.Items[i - 1].BackColor = Color.Coral;

                    this.Players.Add(
                        new DTOPlayer
                        {
                            GameId = game.GameId,
                            IsValid = false
                        });
                }
                
                this.listView1.SelectedItems.Clear();
                this.listView1.Items[selectedItem].Selected = true;
                
            }
            else
            {
                for (int i = 1; i <= game.PlayerNumbers; i++)
                {
                    this.listView1.Items.Add($"{i}. Játékos");
                    this.listView1.Items[i - 1].BackColor = Color.Coral;

                    this.Players.Add(
                        new DTOPlayer
                        {
                            GameId = game.GameId,
                            IsValid = false
                        });
                }
            }

            this.listView1.SelectedItems.Clear();
            this.listView1.Items[selectedItem].Selected = true;

            if (RoomLogic.IsEnglish)
            {
                SetLabelsToEnglish();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ellenőrizzük, hogy van-e kijelölt elem
            if (listView1.SelectedItems.Count > 0)
            {
                // Kijelölt elem
                ListViewItem selectedItem = listView1.SelectedItems[0];

                // Ha van előző kijelölt elem, állítsuk vissza az eredeti fontjára
                if (previousFont != null)
                {
                    // Keresd meg az előző kijelölt elemet és állítsd vissza
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (item.Font != previousFont) // Csak az előzőt állítsuk vissza
                        {
                            item.Font = previousFont;
                        }
                    }
                }

                // Megőrizzük az aktuális kijelölt elem fontját
                previousFont = selectedItem.Font;

                // Új betűméret +2 ponttal
                float newSize = previousFont.Size + 4;

                // Új font létrehozása a meglévő stílusokkal
                Font newFont = new Font(previousFont.FontFamily, newSize, previousFont.Style);

                // Kijelölt elem font beállítása
                selectedItem.Font = newFont;
            }

            if (this.listView1.SelectedItems.Count > 0)
            {
                // Aktuális játékos adatainak mentése
                SavePlayerData(selectedItem);

                // Új játékos adatok betöltése
                selectedItem = listView1.SelectedItems[0].Index;
                LoadPlayerData(selectedItem);
            }
        }

        private void SavePlayerData(int index)
        {
            int a = 0;

            // Aktuális játékos adatainak mentése
            this.Players[index].Name = string.IsNullOrWhiteSpace(tb_Name.Text) || tb_Name.Text == tb_Name.PlaceholderText ? string.Empty : tb_Name.Text;
            this.Players[index].Email = string.IsNullOrWhiteSpace(tb_Email.Text) || tb_Email.Text == tb_Email.PlaceholderText ? string.Empty : tb_Email.Text;
            this.Players[index].BirthDate = string.IsNullOrWhiteSpace(tb_BirthDate.Text) || tb_BirthDate.Text == tb_BirthDate.PlaceholderText ? string.Empty : tb_BirthDate.Text;
            this.Players[index].BirthYear = string.IsNullOrWhiteSpace(tb_BirthYear.Text) || tb_BirthYear.Text == tb_BirthYear.PlaceholderText ? string.Empty : tb_BirthYear.Text;

            if (!string.IsNullOrEmpty(this.tb_ZipCode.Text) && int.TryParse(this.tb_ZipCode.Text, out a) /* && tb_ZipCode.Text != tb_ZipCode.PlaceholderText*/)
            {
                this.Players[index].ZipCode = int.Parse(this.tb_ZipCode.Text);
            }
            else
            {
                this.Players[index].ZipCode = null;
            }
            this.Players[index].Accept1 = this.checkBox1.Checked;
            this.Players[index].Accept2 = this.checkBox2.Checked;
        }

        private void LoadPlayerData(int index)
        {
            // Mezők kiürítése
            this.tb_Name.Text = this.Players[index].Name ?? string.Empty;
            this.tb_Email.Text = this.Players[index].Email ?? string.Empty;
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

            Validate(this.Players[index]);
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

                if (player.Email != tb_Email.PlaceholderText)
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
                this.listView1.Items[selectedItem].BackColor = Color.LightGreen;
            }

            this.pictureBox2.Visible = true;
            this.pictureBox1.Visible = false;
            foreach (var item in this.Players)
            {
                //TODO E-mail validáció üres stringre
                if (!item.IsValid)
                {
                    this.pictureBox2.Visible = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (this.listView1.SelectedItems.Count > 0)
            {
                // Aktuális játékos adatainak frissítése
                this.Players[selectedItem].Name = this.tb_Name.Text;
                this.Players[selectedItem].Email = this.tb_Email.Text;
                this.Players[selectedItem].BirthDate = tb_BirthDate.Text;
                this.Players[selectedItem].BirthYear = tb_BirthYear.Text;
                if (!string.IsNullOrEmpty(this.tb_ZipCode.Text))
                {
                    this.Players[selectedItem].ZipCode = int.Parse(this.tb_ZipCode.Text);
                }
                this.Players[selectedItem].Accept1 = this.checkBox1.Checked;
                this.Players[selectedItem].Accept2 = this.checkBox2.Checked;

                // Frissítjük a validációt és a színt az aktuális játékosnál
                Validate(this.Players[selectedItem]);

                // Újrarajzoljuk az adott ListView elemet, hogy a színváltozás látható legyen
                this.listView1.Items[selectedItem].BackColor = this.Players[selectedItem].IsValid ? Color.LightGreen : Color.Coral;
                this.listView1.Items[selectedItem].EnsureVisible();

                // Ha van még további játékos, akkor váltsunk a következőre
                if (listView1.SelectedItems[0].Index < listView1.Items.Count - 1)
                {
                    listView1.SelectedItems.Clear();
                    listView1.Items[selectedItem + 1].Selected = true;
                }

                // Frissítjük a validációt és a színt a következő játékosnál is
                Validate(this.Players[listView1.SelectedItems[0].Index]);
            }
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
                DialogResult result = CustomMessageBox.Show("Thank You!\nYour game master will be coming soon!", "Save Success!");

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
                DialogResult result = CustomMessageBox.Show("Köszönjük!\nA játékmesteretek hamarosan jelentkezik!", "Mentés kész!");

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
            Validate(this.Players[listView1.SelectedItems[0].Index]);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Validate(this.Players[listView1.SelectedItems[0].Index]);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (this.listView1.SelectedItems.Count > 0)
            {
                // Aktuális játékos adatainak frissítése
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

                // Frissítjük a validációt és a színt az aktuális játékosnál
                Validate(this.Players[selectedItem]);

                // Újrarajzoljuk az adott ListView elemet, hogy a színváltozás látható legyen
                this.listView1.Items[selectedItem].BackColor = this.Players[selectedItem].IsValid ? Color.LightGreen : Color.Coral;
                this.listView1.Items[selectedItem].EnsureVisible();

                // Ha van még további játékos, akkor váltsunk a következőre
                if (listView1.SelectedItems[0].Index < listView1.Items.Count - 1)
                {
                    listView1.SelectedItems.Clear();
                    listView1.Items[selectedItem + 1].Selected = true;
                }

                // Frissítjük a validációt és a színt a következő játékosnál is
                Validate(this.Players[listView1.SelectedItems[0].Index]);
            }
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

            linkLabel1.Location = new Point(585, 317);
        }

    }
}
