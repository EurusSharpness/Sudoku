using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Soduku
{
    class MainMenu
    {
        public enum MenuPages { MenuPage, HelpPage, LevelPage, GamePage }
        Button Start, Help, Back, Easy, Medium, Hard;

        public static MenuPages page = MenuPages.MenuPage;

        Control.ControlCollection controlCollection;

        private string instructions = "You must place numbers from 1 to 9 in the empty cells,\nthere shouldn't be numbers intersecting.\nTo remove a number you can press the same number or\nhit BackSpace.";
        public MainMenu(Control.ControlCollection controlCollection)
        {
            this.controlCollection = controlCollection;
            Start = new Button();
            Help = new Button();
            Back = new Button();
            Easy = new Button();
            Medium = new Button();
            Hard = new Button();

            BuildButtons();
        }

        public MenuPages getPage()
        {
            return page;
        }

        private void BuildButtons()
        {
            // START BUTTON:

            // Set Button
            Start.Text = "Start";
            Start.Location = new Point(250, 230);
            Start.Font = new Font("ALGERIAN", 24, FontStyle.Italic | FontStyle.Bold);
            Start.BackColor = Color.Transparent;
            Start.ForeColor = Color.Blue;
            Start.FlatStyle = FlatStyle.Flat;
            Start.AutoSize = true;
            Start.FlatAppearance.BorderSize = 0;

            // Make it transparent
            Start.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Start.FlatAppearance.MouseDownBackColor = Color.Transparent;
            // Add it to controls
            controlCollection.Add(Start);

            // Add functionality
            Start.MouseEnter += (s, e) => { Start.ForeColor = Color.Red; };
            Start.MouseLeave += (s, e) => { Start.ForeColor = Color.Blue; };
            Start.MouseClick += (s, e) => { page = MenuPages.LevelPage; };

            // -----------------------------------------------------------

            // Help Button:

            Help.Text = "Help";
            Help.Location = new Point(250, 275);
            Help.Font = new Font("ALGERIAN", 24, FontStyle.Italic | FontStyle.Bold);
            Help.BackColor = Color.Transparent;
            Help.ForeColor = Color.Blue;
            Help.AutoSize = true;
            Help.FlatStyle = FlatStyle.Flat;
            Help.FlatAppearance.BorderSize = 0;
            Help.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Help.FlatAppearance.MouseDownBackColor = Color.Transparent;
            controlCollection.Add(Help);
            Help.MouseEnter += (s, e) => { Help.ForeColor = Color.Red; };
            Help.MouseLeave += (s, e) => { Help.ForeColor = Color.Blue; };
            Help.MouseClick += (s, e) => { page = MenuPages.HelpPage; };

            // -----------------------------------------------------------

            // Back Button:

            Back.Text = "<="; // EHMAZING ARROW
            Back.Location = new Point(0, 0);
            Back.Font = new Font("ALGERIAN", 50, FontStyle.Italic | FontStyle.Bold);
            Back.BackColor = Color.Transparent;
            Back.ForeColor = Color.Blue;
            Back.AutoSize = true;
            Back.FlatStyle = FlatStyle.Flat;
            Back.FlatAppearance.BorderSize = 0;
            Back.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Back.FlatAppearance.MouseDownBackColor = Color.Transparent;
            controlCollection.Add(Back);
            Back.MouseEnter += (s, e) => { Back.ForeColor = Color.Red; };
            Back.MouseLeave += (s, e) => { Back.ForeColor = Color.Blue; };
            Back.MouseClick += (s, e) => { page = MenuPages.MenuPage; };


            // Level Buttons
            Easy.Text = "Easy"; // EHMAZING ARROW
            Easy.Location = new Point(200, 150);
            Easy.Font = new Font("ALGERIAN", 35, FontStyle.Italic | FontStyle.Bold);
            Easy.BackColor = Color.Transparent;
            Easy.ForeColor = Color.Blue;
            Easy.AutoSize = true;
            Easy.FlatStyle = FlatStyle.Flat;
            Easy.FlatAppearance.BorderSize = 0;
            Easy.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Easy.FlatAppearance.MouseDownBackColor = Color.Transparent;
            controlCollection.Add(Easy);
            Easy.MouseEnter += (s, e) => { Easy.ForeColor = Color.Red; };
            Easy.MouseLeave += (s, e) => { Easy.ForeColor = Color.Blue; };
            Easy.MouseClick += (s, e) => { page = MenuPages.GamePage; Game.Level = Game.Levels.Easy; };

            Medium.Text = "Medium"; // EHMAZING ARROW
            Medium.Location = new Point(200, 200);
            Medium.Font = new Font("ALGERIAN", 35, FontStyle.Italic | FontStyle.Bold);
            Medium.BackColor = Color.Transparent;
            Medium.ForeColor = Color.Blue;
            Medium.AutoSize = true;
            Medium.FlatStyle = FlatStyle.Flat;
            Medium.FlatAppearance.BorderSize = 0;
            Medium.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Medium.FlatAppearance.MouseDownBackColor = Color.Transparent;
            controlCollection.Add(Medium);
            Medium.MouseEnter += (s, e) => { Medium.ForeColor = Color.Red; };
            Medium.MouseLeave += (s, e) => { Medium.ForeColor = Color.Blue; };
            Medium.MouseClick += (s, e) => { page = MenuPages.GamePage; Game.Level = Game.Levels.Medium; };

            Hard.Text = "Hard"; // EHMAZING ARROW
            Hard.Location = new Point(200, 250);
            Hard.Font = new Font("ALGERIAN", 35, FontStyle.Italic | FontStyle.Bold);
            Hard.BackColor = Color.Transparent;
            Hard.ForeColor = Color.Blue;
            Hard.AutoSize = true;
            Hard.FlatStyle = FlatStyle.Flat;
            Hard.FlatAppearance.BorderSize = 0;
            Hard.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Hard.FlatAppearance.MouseDownBackColor = Color.Transparent;
            controlCollection.Add(Hard);
            Hard.MouseEnter += (s, e) => { Hard.ForeColor = Color.Red; };
            Hard.MouseLeave += (s, e) => { Hard.ForeColor = Color.Blue; };
            Hard.MouseClick += (s, e) => { page = MenuPages.GamePage; Game.Level = Game.Levels.Hard; };



            Easy.KeyPress += (s, e) => { e.Handled = false; };
            Hard.KeyPress += (s, e) => { e.Handled = false; };
            Medium.KeyPress += (s, e) => { e.Handled = false; };
            Start.KeyPress += (s, e) => { e.Handled = false; };
            Back.KeyPress += (s, e) => { e.Handled = false; };
            Help.KeyPress += (s, e) => { e.Handled = false; };
        }

        public void Draw(Graphics g)
        {
            if (page != MenuPages.GamePage)
            {
                if(!Back.Enabled)
                    Back.Enabled = Start.Enabled = Help.Enabled = Easy.Enabled = Medium.Enabled = Hard.Enabled = true;
            }
            if (page == MenuPages.MenuPage)
            {
                Start.Visible = Help.Visible = true;
                Back.Visible = Easy.Visible = Medium.Visible = Hard.Visible = false;
            }
            if (page == MenuPages.HelpPage)
            {
                Start.Visible = Help.Visible = Easy.Visible = Medium.Visible = Hard.Visible = false;
                Back.Visible = true;
                g.FillRectangle(Brushes.Cyan, 0, 0, 550, 550);
                g.DrawString(instructions, new Font("", 16), Brushes.Red, 0, 200);

            }
            if (page == MenuPages.LevelPage)
            {
                Start.Visible = Help.Visible = false;
                Back.Visible = Easy.Visible = Medium.Visible = Hard.Visible = true;
            }
            if (page == MenuPages.GamePage)
            {
                Start.Visible = Help.Visible = false;
                Back.Visible = Easy.Visible = Medium.Visible = Hard.Visible = false;
                Back.Enabled = Start.Enabled = Help.Enabled = Easy.Enabled = Medium.Enabled = Hard.Enabled = false;
            }
        }

    }
}
