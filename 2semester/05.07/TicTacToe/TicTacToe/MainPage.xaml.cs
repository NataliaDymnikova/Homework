using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeGame();
        }

        /// <summary>
        /// Initialize game. Change "X" or "O". 
        /// </summary>
        private void InitializeGame()
        {
            Label label = new Label();
            label.Content = "Change:";
            label.FontSize = 20;
            label.Margin = new Thickness(0, 0, 0, 0);
            label.HorizontalAlignment = HorizontalAlignment.Left;
            label.VerticalAlignment = VerticalAlignment.Top;
            this.LayoutRoot.Children.Add(label);
            
            RadioButton[] whatYou = new RadioButton[2];
            whatYou[0] = new RadioButton();
            whatYou[1] = new RadioButton();
            whatYou[0].Content = "O";
            whatYou[1].Content = "X";
            whatYou[0].FontSize = whatYou[1].FontSize = 20;
            whatYou[0].Margin = new Thickness(10, 30, 0, 0);
            whatYou[1].Margin = new Thickness(50, 30, 0, 0);
            whatYou[0].IsChecked = true;
            whatYou[1].IsChecked = false;
            this.LayoutRoot.Children.Add(whatYou[0]);
            this.LayoutRoot.Children.Add(whatYou[1]);

            Button buttonOk = new Button();
            buttonOk.Content = "OK";
            buttonOk.Margin = new Thickness(0, 80, 0, 0);
            buttonOk.FontSize = 18;
            buttonOk.Width = 40;
            buttonOk.Height = 40;
            buttonOk.HorizontalAlignment = HorizontalAlignment.Left;
            buttonOk.VerticalAlignment = VerticalAlignment.Top;
            buttonOk.Click += new RoutedEventHandler(
                    (object sender, RoutedEventArgs e) => OnButtonOkClick((bool)whatYou[0].IsChecked));
            this.LayoutRoot.Children.Add(buttonOk);
        }

        /// <summary>
        /// Button "Ok" Click. Start game.
        /// </summary>
        /// <param name="isManToe"> Is Man play "O". </param>
        private void OnButtonOkClick(bool isManToe)
        {
            if (isManToe)
                computer = new ComputerGo(false);
            else
                computer = new ComputerGo(true);
            this.LayoutRoot.Children.Clear();
            InitializeButtons();
        }

        /// <summary>
        /// Initialize button for tic-tac-toe.
        /// </summary>
        private void InitializeButtons()
        {
            buttonsBool = new bool[9];
            buttons = new Button[9];
            for (int i = 0; i < 9; i++)
            {
                buttons[i] = new Button();
                buttons[i].HorizontalAlignment = HorizontalAlignment.Left;
                buttons[i].VerticalAlignment = VerticalAlignment.Top;
                buttons[i].Width = 200;
                buttons[i].Height = 200;
                buttons[i].Margin = new Thickness((i % 3) * 200, (i / 3) * 200, 0, 0);
                buttons[i].FontSize = 40;
                int j = i;
                buttons[i].Click += new RoutedEventHandler(
                    (object sender, RoutedEventArgs e) => OnButtonClick(j));
                this.LayoutRoot.Children.Add(buttons[i]);
            }
            isToe = !computer.IsCompToe;
            if (computer.IsCompToe)
                buttons[computer.Add(buttonsBool)].Content = computer.IsCompToe ? "O" : "X";
        }

        /// <summary>
        /// Button click in game.
        /// </summary>
        /// <param name="number"> Number button, which clicked. </param>
        private void OnButtonClick(int number)
        {
            if (buttons[number].Content != null)
            {
                if (!buttons[number].Content.ToString().Equals("O")
                    && !buttons[number].Content.ToString().Equals("X"))
                {
                    this.LayoutRoot.Children.Clear();
                    InitializeGame();
                }
                return;
            }
           
            buttonsBool[number] = true;
            if (isToe)
                buttons[number].Content = "O";
            else
                buttons[number].Content = "X";
           
            if (IsWin())
            {
                for (int i = 0; i < 9; i++)
                    buttons[i].Content = "YOU WIN!!!";
                return;
            }

            buttons[computer.Add(buttonsBool)].Content = computer.IsCompToe ? "O" : "X"; 
            if (IsWin())
            {
                for (int i = 0; i < 9; i++)
                    buttons[i].Content = "you lose";
            }
            for (int i = 0; i < 9; i++)
                if (!buttonsBool[i])
                    return;
            for (int i = 0; i < 9; i++)
                buttons[i].Content = "end.";
        }

        /// <summary>
        /// Fuction 
        /// </summary>
        /// <returns> Is win or not. </returns>
        private bool IsWin()
        {
            for (int i = 0; i < 3; i ++)
            {
                if (IsEqual(buttons[i * 3].Content, buttons[i * 3 + 1].Content,
                            buttons[i * 3 + 2].Content))
                    return true;
                
                if (IsEqual(buttons[i % 3].Content, buttons[i % 3 + 3].Content,
                            buttons[i % 3 + 6].Content))
                    return true;
            }
            if (IsEqual(buttons[0].Content, buttons[4].Content, buttons[8].Content))
                return true;

            if (IsEqual(buttons[2].Content, buttons[4].Content, buttons[6].Content))
                return true;

            return false;
        }

        // Return is first, second and third are equal and not null.
        private bool IsEqual(object first, object second, object third)
        {
            if (first == null || second == null || third == null)
                return false;
            if (first.ToString() == second.ToString()
                && first.ToString() == third.ToString())
                return true;
            return false;
        }

        // Buttons for game.
        private Button[] buttons;
        
        // Is man play "O".
        private bool isToe;

        // Player - computer.
        private ComputerGo computer;

        // Is Button not empty.
        private bool[] buttonsBool;
    }
}
