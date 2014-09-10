using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Initialize 9 button to XO.
        private void InitializeButtons()
        {
            buttons = new System.Windows.Forms.Button[9];
            for (int i = 0; i < 9; i++)
            {
                this.buttons[i] = new System.Windows.Forms.Button();
                this.buttons[i].Location = new System.Drawing.Point(137, 72);
                this.buttons[i].Name = "button" + i.ToString();
                this.buttons[i].Size = new System.Drawing.Size(75, 23);
                this.buttons[i].TabIndex = 0;
                this.buttons[i].Text = null;
                this.buttons[i].UseVisualStyleBackColor = true;
                this.buttons[i].Dock = System.Windows.Forms.DockStyle.Fill;
                int j = i;
                this.buttons[i].Click += new System.EventHandler(
                    (object sender, EventArgs e) => OnButtonClick(j));
                this.tableLayoutPanel1.Controls.Add(this.buttons[i], i / 3, i % 3);
            }
        }

        // If button is click.
        private void OnButtonClick(int numberButton)
        {
            if (buttons[numberButton].Text != "" 
                || (buttons[4].Text != "X" && buttons[4].Text != "O" && buttons[4].Text != ""))
                return;
            if (isPreviousIsX)
                buttons[numberButton].Text = "O";
            else
                buttons[numberButton].Text = "X";
            isPreviousIsX = !isPreviousIsX;

            if (IsWin())
                if (isPreviousIsX)
                    buttons[4].Text = "X - win!!!";
                else
                    buttons[4].Text = "O - win!!!";
            
        }

        // If someone win - return true.
        private bool IsWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (buttons[3 * i].Text == buttons[3 * i + 1].Text
                    && buttons[3 * i].Text == buttons[3 * i + 2].Text
                    && buttons[3 * i].Text != "")
                    return true;
                if (buttons[i].Text == buttons[i + 3].Text
                    && buttons[i].Text == buttons[i + 6].Text
                    && buttons[i].Text != "")
                    return true;
            }
            if (buttons[0].Text == buttons[4].Text
                && buttons[0].Text == buttons[8].Text
                && buttons[0].Text != "")
                return true;
            if (buttons[2].Text == buttons[4].Text
                && buttons[2].Text == buttons[6].Text
                && buttons[2].Text != "")
                return true;
            return false;
        }
    }
}
