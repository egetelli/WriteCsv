using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WriteCsv.buttons
{
    internal class RoundedButton
    {
        //Create a new button
        Button btnRounded = new Button();

        //Set the button's text
        public string Text { get { return btnRounded.Text; } set { btnRounded.Text = value; } }

        //Set the button's background color to a light blue
        public Color BackColor { get { return btnRounded.BackColor; } set { btnRounded.BackColor = value; } }

        //Set the button's size
        public Size Size { get { return btnRounded.Size; } set { btnRounded.Size = value; } }

        //Set the button's location
        public Point Location { get { return btnRounded.Location; } set { btnRounded.Location = value; } }

        //Set the button's border radius
        public void SetBorderRadius(int radius)
        {
            btnRounded.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, btnRounded.Width, btnRounded.Height, radius, radius));
        }

        //Create a function to create a rounded rectangle region
        private static IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse)
        {
            IntPtr hRgn = IntPtr.Zero;
            hRgn = CreateRoundRectRgn(nLeftRect, nTopRect, nRightRect, nBottomRect, nWidthEllipse, nHeightEllipse);
            return hRgn;
        }
    }
}
