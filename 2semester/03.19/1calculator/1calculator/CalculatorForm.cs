using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void OnButtonClick(char ch)
        {
            if (ch < '0' || ch > '9')
                if (this.textBox.Text.Length == 0)
                    return;
                else if (this.textBox.Text.Length == 1)
                {
                    OnButtonSignClick(ch);
                    return;
                }

            if (this.textBox.Text.Length >= 2)
                if (ch < '0' || ch > '9')
                {
                    OnButtonSignClick(ch);
                    return;
                }
                else
                {
                    if (this.textBox.Text[this.textBox.Text.Length - 1] == '=')
                        calculator.Clean();
                    this.textBox.Text = null;
                }
            this.textBox.Text += ch;
        }

        private void OnButtonSignClick(char ch)
        {
            if (this.textBox.Text.Length < 2
                || (this.textBox.Text.Length >= 2 
                && this.textBox.Text[this.textBox.Text.Length - 1] >= '0' 
                && this.textBox.Text[this.textBox.Text.Length - 1] <= '9'))
                
                this.calculator.Add(Convert.ToInt32(this.textBox.Text));
            this.calculator.Add(ch);
            this.textBox.Text = this.calculator.Print();
        }

        private void InitializeMyGroupBox()
        {
            int numberButton = 15;
            System.Windows.Forms.Button[] buttons = new System.Windows.Forms.Button[numberButton];
            for (int i = 0; i < numberButton; i++)
            {
                buttons[i] = new System.Windows.Forms.Button();
                buttons[i].Name = i.ToString();
                buttons[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
                buttons[i].Dock = System.Windows.Forms.DockStyle.Fill;
                this.tableLayoutPanelWithButtons.Controls.Add(buttons[i], i % 5, i / 5);
            }
            buttons[2].Text = "9";
            buttons[1].Text = "8";
            buttons[0].Text = "7";
            buttons[7].Text = "6";
            buttons[6].Text = "5";
            buttons[5].Text = "4";
            buttons[12].Text = "3";
            buttons[11].Text = "2";
            buttons[10].Text = "1";
            buttons[13].Text = "0";
            buttons[3].Text = "/";
            buttons[4].Text = "*";
            buttons[8].Text = "-";
            buttons[9].Text = "+";
            buttons[14].Text = "=";

            for (int i = 0; i < numberButton; i++)
            {
                int j = i;
                buttons[j].Click += ((object sender, EventArgs e)
                    => this.OnButtonClick(buttons[j].Text[0]));
            }
        }
    }
}
