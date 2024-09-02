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
            this.comboBox1.Items.AddRange(RoomLogic.GetRoomNames().ToArray());
            for (int i = 2; i <= 12; i++)
            {
                this.comboBox2.Items.Add(i);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameLogic.SaveGame(new BLL.Model.DTOGame() { PlayerNumber = int.Parse(this.comboBox2.Text), RoomName = this.comboBox1.Text, Time = this.dateTimePicker1.Value });
            ButtonClicked?.Invoke(new DTOGameControl() { GameId = GameLogic.GetLastId(), PlayerNumbers = int.Parse(this.comboBox2.Text) }, EventArgs.Empty);
        }
    }
}
