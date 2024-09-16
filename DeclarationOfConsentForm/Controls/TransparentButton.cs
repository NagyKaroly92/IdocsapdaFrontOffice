using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclarationOfConsentForm.Controls
{
    public class TransparentButton : Button
    {
        public TransparentButton()
        {
            // Eltávolítjuk a gomb alapvető festését
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;  // A form háttere átlátszó lesz
            this.SetStyle(ControlStyles.Opaque, true);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Ha van kép, kirajzoljuk
            if (this.Image != null)
            {
                pevent.Graphics.DrawImage(this.Image, new Rectangle(0, 0, this.Width, this.Height));
            }
        }

        // A háttér megrajzolásának letiltása
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Nem hívunk meg semmit, így a háttér nem lesz megrajzolva
        }
    }
}
