using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Soduku
{
    class Game
    {
        // 1: Random
        // 2: NO INTERS
        // 3: 
        public enum Levels { Easy, Medium, Hard }
        enum Difficulty {Easy = 85, Medium = 45, Hard = 35}

        int[,] Matrix;
        Cell[,] PlayerMatrix;

        public static Levels Level;

        Point Clicked;


        int[] CompleteNumbers;
        public Game()
        {
            Initialize();
        }
        public void FillTheBoard()
        {
            List<int>[] Rows, Colums, Square;
            Rows = new List<int>[9];
            Colums = new List<int>[9];
            Square = new List<int>[9];
            Random r = new Random();
            SomethingWentWrong:
            for(int i = 0;i < 9; i++)
            {
                Rows[i] = new List<int>();
                Colums[i] = new List<int>();
                Square[i] = new List<int>();
                Rows[i].AddRange(Enumerable.Range(1, 9).Take(9));
                Colums[i].AddRange(Enumerable.Range(1, 9).Take(9));
                Square[i].AddRange(Enumerable.Range(1, 9).Take(9)); 
            }
            
           
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // i => Rows, j => colum, GetSquareNumber => squareIndex
                    var squareIndex = GetSquareNumber(i, j);
                    var list = Rows[i].Intersect(Colums[j].Intersect(Square[squareIndex])).ToList();
                    if (list.Count <= 0)
                        goto SomethingWentWrong;
                    int x = list[r.Next(0, list.Count)];
                    Rows[i].Remove(x);
                    Colums[j].Remove(x);
                    Square[squareIndex].Remove(x);
                    Matrix[i, j] = x;
                }
            }
            PlayerBoard();
        }

        private void PlayerBoard()
        {
            Difficulty pro = (Level == Levels.Easy) ? Difficulty.Easy : (Level == Levels.Medium) ? Difficulty.Medium : Difficulty.Hard;
            Random r = new Random();
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if ((r.Next(0, 101) <= (int)pro))
                    {
                        PlayerMatrix[i, j] = new Cell(Matrix[i, j], false);
                        CompleteNumbers[Matrix[i, j] - 1]++;
                    }
        }

        private int GetSquareNumber(int i, int j) => (i / 3) * 3 + j / 3;

        public void OnClick(Point p) => Clicked = p;

        public void Draw(Graphics g)
        {
            Brush brush = Brushes.Black;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    string s = PlayerMatrix[i, j].Value.ToString();
                    FontStyle fontStyle;
                    if (PlayerMatrix[i, j].Value == 0)
                        s = "";
                    else if (PlayerMatrix[i, j].Value == PlayerMatrix[Clicked.X, Clicked.Y].Value)
                    {
                        g.FillRectangle((Clicked.X == i && Clicked.Y == j) ? Brushes.DarkGray : Brushes.LightGray, 50 * i, 50 * j, 50, 50);
                        if (CompleteNumbers[PlayerMatrix[i, j].Value - 1] != 9)
                            brush = Brushes.Blue;
                        else
                            brush = Brushes.Gold;
                    }
                    else if (CompleteNumbers[PlayerMatrix[i, j].Value - 1] == 9)
                        brush = Brushes.Gold;
                    else
                        brush = Brushes.Black;
                    fontStyle = (PlayerMatrix[i, j].Modify) ? FontStyle.Regular : FontStyle.Bold;
                    g.DrawString(s,
                        new Font("", 15,fontStyle), brush, new Point(20 + 50 * i, 20 + 50 * j));
                }
            }
        }

        public void Initialize()
        {
            Clicked = new Point(0, 0);
            Matrix = new int[9, 9];
            PlayerMatrix = new Cell[9, 9];
            CompleteNumbers = new int[9];
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    PlayerMatrix[i, j] = new Cell();
        }

        public void KeyDown(KeyEventArgs e)
        {
            int number = -1;

            if ((e.KeyCode >= Keys.D1 && e.KeyCode <= Keys.D9))
                number = e.KeyValue - (int)Keys.D0;

            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                number = e.KeyValue - (int)Keys.NumPad0;

            if (e.KeyCode == Keys.Back || PlayerMatrix[Clicked.X, Clicked.Y].Value == number)
                number = -5;

            if (number == -1)
                return;

            if (PlayerMatrix[Clicked.X, Clicked.Y].Modify)
            {

                if (number == -5)
                {
                    if (PlayerMatrix[Clicked.X, Clicked.Y].Value == Matrix[Clicked.X, Clicked.Y])
                        CompleteNumbers[PlayerMatrix[Clicked.X, Clicked.Y].Value - 1]--;
                }
                else if (Matrix[Clicked.X, Clicked.Y] == number)
                    CompleteNumbers[number - 1]++;


                PlayerMatrix[Clicked.X, Clicked.Y].Value = (number == -5) ? 0 : number;
            }
            
        }

        public bool CheckWin()
        {
            for (int i = 0; i < 9; i++)
                if (CompleteNumbers[i] != 9)
                    return false;
            return true;
        }

        private class Cell
        {
            public int Value;
            public bool Modify;
            public Cell(int value = 0, bool mod = true) => (Value, Modify) = (value, mod);
        }
    }
}
