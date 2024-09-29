using BLL;
using DeclarationOfConsentForm.Model;
using DeclarationOfConsentForm.UserControls;

namespace DeclarationOfConsentForm
{
    public partial class Form1 : Form
    {
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
            //this.label1.Text = "Kijelentem, hogy felel�ss�gem teljes tudat�ban l�pek be az Id�csapda j�t�k�ba. \nTiszt�ban vagyok a j�t�k c�lj�val �s szab�lyaival. Nem tudok r�la, hogy b�rmilyen nem�, \na j�t�kot �rint� eg�szs�g�gyi probl�m�val rendelkezn�k (pl. p�nikbetegs�g, klausztrof�bia stb), vagy ha ilyennel rendelkezem, arr�l el�re t�j�koztattam a j�t�k szervez�j�t. \nA sz�ks�ges balesetv�delmi el��r�sokat meghallgattam �s ennek tudat�ban veszek r�szt a j�t�kban. \nA j�t�k helysz�n�t, �s berendez�seit rendeltet�sszer�en haszn�lom, ha valamiben k�rt teszek, arra anyagi felel�ss�get v�llalok, �s a j�t�k v�g�n az okozott k�rt megfizetem. \nAz erre vonatkoz� t�j�koztat�t megkaptam. Az e-mail c�m megad�s v�laszthat�. K�l�nb�z� AKCI�KR�L, �j p�lya nyit�s�r�l stb. k�ld�nk �rtes�t�st.";
            this.label1.Text = "Kijelentem, hogy felel�ss�gem teljes tudat�ban l�pek be az Id�csapda j�t�k�ba. Tiszt�ban vagyok a j�t�k c�lj�val �s szab�lyaival. Nem tudok r�la, hogy b�rmilyen nem�, a j�t�kot �rint� eg�szs�g�gyi probl�m�val rendelkezn�k (pl. p�nikbetegs�g, klausztrof�bia stb), vagy ha ilyennel rendelkezem, arr�l el�re t�j�koztattam a j�t�k szervez�j�t. A sz�ks�ges balesetv�delmi el��r�sokat meghallgattam �s ennek tudat�ban veszek r�szt a j�t�kban. A j�t�k helysz�n�t, �s berendez�seit rendeltet�sszer�en haszn�lom, ha valamiben k�rt teszek, arra anyagi felel�ss�get v�llalok, �s a j�t�k v�g�n az okozott k�rt megfizetem. Az erre vonatkoz� t�j�koztat�t megkaptam. Az e-mail c�m megad�s v�laszthat�. K�l�nb�z� AKCI�KR�L, �j p�lya nyit�s�r�l stb. k�ld�nk �rtes�t�st.";
            BLL.RoomLogic.IsEnglishChanged += OnIsEnglishChanged;
            a.ButtonClicked += GamePropertyUserControlClosed;
            b.ButtonClicked += PlayerUserControlClosed;
            this.groupBox1.Controls.Add(a);
        }

        private void GamePropertyUserControlClosed(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = false;
            this.pictureBox2.Visible = false;
            this.groupBox1.Controls.Clear();
            PlayersUserControl b = new PlayersUserControl(((DTOGameControl)sender));
            b.ButtonClicked += PlayerUserControlClosed;
            this.groupBox1.Controls.Add(b);
        }
        private void PlayerUserControlClosed(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            this.pictureBox2.Visible = true;
            this.groupBox1.Controls.Clear();
            GamePropertyUserControl a = new GamePropertyUserControl();
            a.ButtonClicked += GamePropertyUserControlClosed;
            this.groupBox1.Controls.Add(a);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            RoomLogic.IsEnglish = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RoomLogic.IsEnglish = true;
        }
        private void OnIsEnglishChanged(object sender, bool isEnglish)
        {
            if (RoomLogic.IsEnglish)
            {
                //this.label1.Text = "I hereby declare that I participate in the game �Timetrap� with full responsibility. I am aware of the purpose and rules of the game. \nI am not aware of any kind of health issues that might affect the game (eg. panic disorder, claustrophobia etc.), \nor if I have such issues, the game organizer was informed about them in advance. \nI have heard, understood and will fully abide by the Terms and Conditions while participating in the game. \nI hold full responsibility for my actions and I will use the equipment as intended, or in case I cause any damage to the equipment I will pay for them at the end of the game. \nI have been informed of the Terms and Conditions of the game �Timetrap�.\nI hereby acknowledge that i have read and accept the privacy policy. The e-mail adress is optional.";
                this.label1.Text = "I hereby declare that I participate in the game �Timetrap� with full responsibility. I am aware of the purpose and rules of the game. I am not aware of any kind of health issues that might affect the game (eg. panic disorder, claustrophobia etc.), or if I have such issues, the game organizer was informed about them in advance. I have heard, understood and will fully abide by the Terms and Conditions while participating in the game. I hold full responsibility for my actions and I will use the equipment as intended, or in case I cause any damage to the equipment I will pay for them at the end of the game. I have been informed of the Terms and Conditions of the game �Timetrap�. I hereby acknowledge that i have read and accept the privacy policy. The e-mail adress is optional.";
            }
            else
            {
                //this.label1.Text = "Kijelentem, hogy felel�ss�gem teljes tudat�ban l�pek be az Id�csapda j�t�k�ba. \nTiszt�ban vagyok a j�t�k c�lj�val �s szab�lyaival. Nem tudok r�la, hogy b�rmilyen nem�, \na j�t�kot �rint� eg�szs�g�gyi probl�m�val rendelkezn�k (pl. p�nikbetegs�g, klausztrof�bia stb), vagy ha ilyennel rendelkezem, arr�l el�re t�j�koztattam a j�t�k szervez�j�t. \nA sz�ks�ges balesetv�delmi el��r�sokat meghallgattam �s ennek tudat�ban veszek r�szt a j�t�kban. \nA j�t�k helysz�n�t, �s berendez�seit rendeltet�sszer�en haszn�lom, ha valamiben k�rt teszek, arra anyagi felel�ss�get v�llalok, �s a j�t�k v�g�n az okozott k�rt megfizetem. \nAz erre vonatkoz� t�j�koztat�t megkaptam. Az e-mail c�m megad�s v�laszthat�. K�l�nb�z� AKCI�KR�L, �j p�lya nyit�s�r�l stb. k�ld�nk �rtes�t�st.";
                this.label1.Text = "Kijelentem, hogy felel�ss�gem teljes tudat�ban l�pek be az Id�csapda j�t�k�ba. Tiszt�ban vagyok a j�t�k c�lj�val �s szab�lyaival. Nem tudok r�la, hogy b�rmilyen nem�, a j�t�kot �rint� eg�szs�g�gyi probl�m�val rendelkezn�k (pl. p�nikbetegs�g, klausztrof�bia stb), vagy ha ilyennel rendelkezem, arr�l el�re t�j�koztattam a j�t�k szervez�j�t. A sz�ks�ges balesetv�delmi el��r�sokat meghallgattam �s ennek tudat�ban veszek r�szt a j�t�kban. A j�t�k helysz�n�t, �s berendez�seit rendeltet�sszer�en haszn�lom, ha valamiben k�rt teszek, arra anyagi felel�ss�get v�llalok, �s a j�t�k v�g�n az okozott k�rt megfizetem. Az erre vonatkoz� t�j�koztat�t megkaptam. Az e-mail c�m megad�s v�laszthat�. K�l�nb�z� AKCI�KR�L, �j p�lya nyit�s�r�l stb. k�ld�nk �rtes�t�st.";
            }
        }
    }
}
