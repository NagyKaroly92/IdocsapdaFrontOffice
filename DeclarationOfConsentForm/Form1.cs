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
            this.label1.Text = "Kijelentem, hogy felel�ss�gem teljes tudat�ban l�pek be az Id�csapda j�t�k�ba. \nTiszt�ban vagyok a j�t�k c�lj�val �s szab�lyaival. Nem tudok r�la, hogy b�rmilyen nem�, \na j�t�kot �rint� eg�szs�g�gyi probl�m�val rendelkezn�k (pl. p�nikbetegs�g, klausztrof�bia stb), vagy ha ilyennel rendelkezem, arr�l el�re t�j�koztattam a j�t�k szervez�j�t. \nA sz�ks�ges balesetv�delmi el��r�sokat meghallgattam �s ennek tudat�ban veszek r�szt a j�t�kban. \nA j�t�k helysz�n�t, �s berendez�seit rendeltet�sszer�en haszn�lom, ha valamiben k�rt teszek, arra anyagi felel�ss�get v�llalok, �s a j�t�k v�g�n az okozott k�rt megfizetem. \nAz erre vonatkoz� t�j�koztat�t megkaptam. Az e-mail c�m megad�s v�laszthat�. K�l�nb�z� AKCI�KR�L, �j p�lya nyit�s�r�l stb. k�ld�nk �rtes�t�st.";
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
