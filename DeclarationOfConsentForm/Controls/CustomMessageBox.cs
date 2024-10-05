using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeclarationOfConsentForm.Controls
{
    public partial class CustomMessageBox : Form
    {
        private System.Timers.Timer timer;

        public CustomMessageBox()
        {
            InitializeComponent();

            // Ablak méretének növelése
            this.Size = new Size(600, 300); // 3x nagyobb méret az alapértelmezetthez képest
            this.StartPosition = FormStartPosition.CenterScreen; // Középre igazítás

            // Betűtípus méretének növelése
            this.label1.Font = new Font(this.label1.Font.FontFamily, this.label1.Font.Size * 3, FontStyle.Regular); // 3x nagyobb betűméret
            this.okButton.Font = new Font(this.okButton.Font.FontFamily, this.okButton.Font.Size * 3, FontStyle.Regular);

            // Indítjuk a 2 perces időzítőt
            timer = new System.Timers.Timer(120000); // 120 000 ms = 2 perc
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false; // Az időzítő csak egyszer fusson le
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Az időzítő lejárt, bezárjuk a formot
            this.Invoke((MethodInvoker)delegate
            {
                this.DialogResult = DialogResult.OK; // Állítsuk be az eredményt, ha szükséges
                this.Close();
            });
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            // A felhasználó rákattintott az "OK" gombra
            timer.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public static DialogResult Show(string text, string caption)
        {
            using (var form = new CustomMessageBox())
            {
                form.Text = caption;
                form.label1.Text = text; // A form tartalmaz egy Label-t
                return form.ShowDialog();
            }
        }
    }
}