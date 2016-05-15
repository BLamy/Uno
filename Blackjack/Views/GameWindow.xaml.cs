using Uno.ViewModels;
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
using Uno.Models;
using Blackjack.Views;

namespace Uno.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        /// <summary>
        /// The name of the player passed in the constructor
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public GameBoardViewModel GameBoardVM { get; set; }

        const int CARD_WIDTH = 113;

        const int CARD_HEIGHT = 157;

        public GameWindow(String playerName)
        {
            this.PlayerName = playerName;
            InitializeComponent();
            CreateNewGame();
        }

        private void CreateNewGame()
        {
            //this.PlayerTextBlock.Text = $"Player: {this.PlayerName}";
            this.GameBoardVM = new GameBoardViewModel();
            this.render();
        }

        private void render()
        {
            this.checkGameOver();
            this.UpdatePlayerField();
            this.UpdateComputerField();
            this.UpdateTurnArrow();
            this.UpdateLastCard();
        }

        private void checkGameOver()
        {
            if (this.GameBoardVM.isGameover() && this.IsActive)
            {
                GameOverWindow gameoverWindow = new GameOverWindow(this.GameBoardVM.winner(), this.PlayerName);
                gameoverWindow.Show();
                this.Close();
            }
        }

        private void UpdateTurnArrow()
        {
            if (this.GameBoardVM.turn == Player.computer)
            {
                this.ComputerTurnArrow.Visibility = Visibility.Visible;
                this.playerTurnArrow.Visibility = Visibility.Hidden;
            }
            else
            {
                this.ComputerTurnArrow.Visibility = Visibility.Hidden;
                this.playerTurnArrow.Visibility = Visibility.Visible;
            }
        }

        private void UpdateLastCard()
        {
            String lastCardLocation = this.GameBoardVM.lastCard.ImageLocation;
            this.PlayPile.Source = new BitmapImage(new Uri(lastCardLocation, UriKind.Relative));
        }

        private void HandlePlayerCardClick(object sender, EventArgs e)
        {
            if (this.GameBoardVM.turn != Player.player)
                return;

            Button button = (Button)sender;
            Card card = (Card)button.Tag;
            GameBoardVM.tryPlay(card, () => this.Dispatcher.Invoke((Action)(() => render())));
        }

        private void HandleComputerCardClick(object sender, EventArgs e)
        {
            if (this.GameBoardVM.turn != Player.computer)
                return;

            Button button = (Button)sender;
            Card card = (Card)button.Tag;
            ;

            GameBoardVM.tryPlay(card, () => this.Dispatcher.Invoke((Action)(() => render())));
        }

        private void UpdateHandForPlayer(StackPanel field, List<Card> hand, Action<object, EventArgs> cb)
        {
            ClearPlayField(field);
            for (int i = 0; i < hand.Count; i++)
            {
                Card card = hand[i];
                Button button = new Button
                {
                    Tag = card,
                    Width = CARD_WIDTH,
                    Height = CARD_HEIGHT,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(0),
                    Background = Brushes.Transparent,
                    Content = new Image
                    {
                        Source = new BitmapImage(new Uri(card.ImageLocation, UriKind.Relative)),
                        VerticalAlignment = VerticalAlignment.Center
                    }
                };
                
                button.Click += cb.Invoke;
                field.Children.Add(button);
            }
        }

        private void UpdatePlayerField()
        {
            UpdateHandForPlayer(PlayerField, GameBoardVM.PlayerHand, HandlePlayerCardClick);
        }

        private void UpdateComputerField()
        {
            UpdateHandForPlayer(ComputerField, GameBoardVM.ComputerHand, HandleComputerCardClick);
        }

        private void ClearPlayField(StackPanel field)
        {
            field.Children.RemoveRange(0, field.Children.Count);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Console.Write(GameBoardVM.PlayerHand);
            Console.Write(GameBoardVM.ComputerHand);
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {
            this.GameBoardVM.DrawCard();
            this.checkGameOver();
            if (this.GameBoardVM.turn == Player.player)
            {
                UpdatePlayerField();
            }
            else
            {
                UpdateComputerField();
            }
        }
    }
}
