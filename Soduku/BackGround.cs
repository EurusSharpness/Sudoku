using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Soduku
{
    class BackGround
    {
        int width = 50, height = 50;
        public BackGround()
        {

        }
        public void Draw(Graphics g)
        {
            for(int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    g.DrawRectangle(new Pen(Brushes.Black),
                        new Rectangle(new Point(width * i, j * height), new Size(width, height)));
                }
            }

            g.DrawLine(new Pen(Brushes.Black, 2.5F), new Point(150, 0), new Point(150, 50 * 9));
            g.DrawLine(new Pen(Brushes.Black, 2.5F), new Point(300, 0), new Point(300, 50 * 9));
            g.DrawLine(new Pen(Brushes.Black, 2.5F), new Point(0, 150), new Point(50 * 9, 150));
            g.DrawLine(new Pen(Brushes.Black, 2.5F), new Point(0, 300), new Point(50 * 9, 300));

        }
    }
}
