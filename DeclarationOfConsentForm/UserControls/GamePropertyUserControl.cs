using BLL;
using DeclarationOfConsentForm.Model;

namespace DeclarationOfConsentForm.UserControls
{
    public partial class GamePropertyUserControl : UserControl
    {
        public event EventHandler ButtonClicked;
        public GamePropertyUserControl()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void GamePropertyUserControl_Load(object sender, EventArgs e)
        {
            BLL.RoomLogic.IsEnglishChanged += OnIsEnglishChanged;
            this.comboBox1.Items.AddRange(RoomLogic.GetRoomNames().ToArray());
            for (int i = 2; i <= 12; i++)
            {
                this.comboBox2.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameLogic.SaveGame(new BLL.Model.DTOGame() { PlayerNumber = int.Parse(this.comboBox2.Text), RoomName = this.comboBox1.Text, Time = this.dateTimePicker1.Value });
            ButtonClicked?.Invoke(new DTOGameControl() { GameId = GameLogic.GetLastId(), PlayerNumbers = int.Parse(this.comboBox2.Text), IsEnglish = RoomLogic.IsEnglish }, EventArgs.Empty);
        }
        private void OnIsEnglishChanged(object sender, bool isEnglish)
        {
            if (isEnglish)
            {
                this.label2.Text = "Escape room";
                this.label3.Text = "Game start";
                this.label4.Text = "Number of players";
                this.comboBox1.Items.Clear();
                this.comboBox1.Items.AddRange(RoomLogic.GetRoomNames().ToArray());
            }
            else
            {
                this.label2.Text = "Pálya kiválasztása";
                this.label3.Text = "Időpont";
                this.label4.Text = "Létszám";
                this.comboBox1.Items.Clear();
                this.comboBox1.Items.AddRange(RoomLogic.GetRoomNames().ToArray());
            }
        }
        private void label1_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;
            string text = lbl.Text;
            Font font = lbl.Font;

            // Először fekete színnel rajzoljuk a körvonalat, kicsit eltolva a szöveget.
            for (int dx = -2; dx <= 2; dx++)
            {
                for (int dy = -2; dy <= 2; dy++)
                {
                    if (dx == 0 && dy == 0) continue; // A középső (eredeti helyzet) kihagyása
                    e.Graphics.DrawString(text, font, Brushes.Black, lbl.ClientRectangle.X + dx, lbl.ClientRectangle.Y + dy);
                }
            }

            // Ezután rajzoljuk meg a szöveget fehér színnel.
            e.Graphics.DrawString(text, font, Brushes.White, lbl.ClientRectangle.X, lbl.ClientRectangle.Y);
        }
    }
}
