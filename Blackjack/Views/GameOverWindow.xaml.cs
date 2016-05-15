using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Uno.ViewModels;
using Uno.Views;

namespace Blackjack.Views
{
    /// <summary>
    /// Interaction logic for GameOverWindow.xaml
    /// </summary>
    public partial class GameOverWindow : Window
    {
        public string PlayerName;

        public GameOverWindow(Player winner, string playerName)
        {
            InitializeComponent();
            this.PlayerName = playerName;
            this.setWinnerLabel(winner, PlayerName);
        }

        private void setWinnerLabel(Player winner, string playerName)
        {
            switch (winner)
            {
                case Player.player:
                    this.title.Text = $"{playerName} Wins!";
                    break;

                case Player.computer:
                    this.title.Text = "Computer Wins!";
                    break;

                default:
                    this.title.Text = "Draw";
                    break;
            }
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow(this.PlayerName);
            gameWindow.Show();
            this.Close();
        }
    }
}
