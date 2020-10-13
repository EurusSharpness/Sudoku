using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soduku
{
    public partial class Form1 : Form
    {
        MainClass Main;
        public Form1()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Main.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Main = new MainClass(Controls);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ClientSize = new Size(50 * 9 + 100, 50 * 9 + 100);
        }

        private void Invalidate_t_Tick(object sender, EventArgs e) => Invalidate();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Main.Click(e.Location);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Main.dd(e);
            e.SuppressKeyPress = true;
        }
    }
}
