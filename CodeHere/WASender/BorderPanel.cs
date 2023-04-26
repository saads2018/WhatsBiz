using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace WASender
{
    public class BorderPanel:Panel
    {
        public Color BorderColor { get; set; }
        

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,this.ClientRectangle , this.BorderColor, ButtonBorderStyle.Solid);
            /*Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            SolidBrush brush = new SolidBrush(
                                this.BackColor
                            ) ;
            g.FillRoundedRectangle(brush, 10, 10, this.Width - 20, this.Height - 20, 10);*/
        }

    }
   
}
