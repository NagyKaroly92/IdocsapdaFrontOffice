using BLL;

namespace testapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = PlayerDetailsLogic.GetEnglishDetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerDetailsLogic.UploadEnglishGames();
        }
    }
}
