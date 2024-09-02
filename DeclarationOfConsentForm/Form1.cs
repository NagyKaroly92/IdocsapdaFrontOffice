using BLL;
using DeclarationOfConsentForm.Model;
using DeclarationOfConsentForm.UserControls;

namespace DeclarationOfConsentForm
{
    public partial class Form1 : Form
    {
        private bool isGameProperty;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GamePropertyUserControl a = new GamePropertyUserControl();
            PlayersUserControl b = new PlayersUserControl();
            this.label1.Text = "Kijelentem, hogy felelõsségem teljes tudatában lépek be az Idõcsapda játékába. \nTisztában vagyok a játék céljával és szabályaival. Nem tudok róla, hogy bármilyen nemû, \na játékot érintõ egészségügyi problémával rendelkeznék (pl. pánikbetegség, klausztrofóbia stb), vagy ha ilyennel rendelkezem, arról elõre tájékoztattam a játék szervezõjét. \nA szükséges balesetvédelmi elõírásokat meghallgattam és ennek tudatában veszek részt a játékban. \nA játék helyszínét, és berendezéseit rendeltetésszerûen használom, ha valamiben kárt teszek, arra anyagi felelõsséget vállalok, és a játék végén az okozott kárt megfizetem. \nAz erre vonatkozó tájékoztatót megkaptam. Az e-mail cím megadás választható. Különbözõ AKCIÓKRÓL, új pálya nyitásáról stb. küldünk értesítést.";
            a.ButtonClicked += GamePropertyUserControlClosed;
            b.ButtonClicked += PlayerUserControlClosed;
            this.groupBox1.Controls.Add(a);
        }

        private void GamePropertyUserControlClosed(object sender, EventArgs e)
        {
            this.groupBox1.Controls.Clear();
            PlayersUserControl b = new PlayersUserControl(((DTOGameControl)sender));
            b.ButtonClicked += PlayerUserControlClosed;
            this.groupBox1.Controls.Add(b);
        }
        private void PlayerUserControlClosed(object sender, EventArgs e)
        {
            this.groupBox1.Controls.Clear();
            GamePropertyUserControl a = new GamePropertyUserControl();
            a.ButtonClicked += GamePropertyUserControlClosed;
            this.groupBox1.Controls.Add(a);
        }
    }
}
