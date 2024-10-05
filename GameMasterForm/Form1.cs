using BLL;
using BLL.Model;

namespace GameMasterForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.DataSource = GameLogic.GetGames();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.DataSource = PlayerLogic.GetPlayers(((DTOGame)comboBox1.SelectedItem).Id)
                    .Select(_ => new { _.Name, _.BirthYear, _.BirthDate, _.Email }).ToList();
            }
            catch (Exception)
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = null;
            this.comboBox1.DataSource = GameLogic.GetGames();
        }
    }
}
