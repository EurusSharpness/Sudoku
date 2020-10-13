﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Soduku
{
    class MainClass
    {
        BackGround bg;
        Point Clicked;
        Game game;
        MainMenu mainMenu;
        bool playing = false;
        public MainClass(Control.ControlCollection controlCollection)
        {
            Clicked = new Point(0, 0);
            bg = new BackGround();
            game = new Game();
            mainMenu = new MainMenu(controlCollection);
        }
        public void Click(Point p)
        {
            if (p.X > 50 * 9 || p.Y > 50 * 9 || p.X < 0 || p.Y < 0)
                return;
            Clicked.X = (p.X / 50 > 8) ? 8 : p.X / 50;
            Clicked.Y = (p.Y / 50 > 8) ? 8 : p.Y / 50;
            game.OnClick(Clicked);
        }
        public void dd(KeyEventArgs e)
        {
            game.KeyDown(e);
        }

        public void Draw(Graphics g)
        {
            mainMenu.Draw(g);
            if (mainMenu.getPage() < MainMenu.MenuPages.GamePage)
            {
                playing = false;
            }
            else
            {
                if (!playing)
                {
                    game.FillTheBoard();
                    playing = true;
                }
                g.FillRectangle(Brushes.LightGray, 50 * Clicked.X, 50 * Clicked.Y, 50, 50);
                game.Draw(g);
                bg.Draw(g);
            }
        }
    }
}
