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

namespace Uno.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        public string PlayerName { get; set; }

        public GameBoardViewModel GameBoardVM { get; set; }

        const int CARD_WIDTH = 113;
        const int CARD_HEIGHT = 157;

        Image FaceDownImage;

        public GameWindow(String playerName)
        {
            this.PlayerName = playerName;
            InitializeComponent();
            CreateNewGame();
        }

        private void CreateNewGame()
        {
            this.PlayerTextBlock.Text = $"Player: {this.PlayerName}";
            this.GameBoardVM = new GameBoardViewModel();
        }

        private void UpdatePlayerField()
        {
            ClearPlayField(PlayerField);
            foreach (var card in GameBoardVM.PlayerHand)
            {
                Image CardImage = new Image();
                CardImage.Height = CARD_HEIGHT;
                CardImage.Width = CARD_WIDTH;
                CardImage.Source = new BitmapImage(new Uri(card.ImageLocation));
                PlayerField.Children.Add(CardImage);
            }
            UpdatePlayerScore();
        }

        private void UpdatePlayerScore()
        {
            PlayerScoreTextBlock.Text = GameBoardVM.PlayerScore.ToString();
        }

        private void ClearPlayField(StackPanel field)
        {
            field.Children.RemoveRange(0, field.Children.Count);
        }

        private void ShowInitialDealerCards()
        {
            FaceDownImage = new Image();
            FaceDownImage.Height = CARD_HEIGHT;
            FaceDownImage.Width = CARD_WIDTH;
            FaceDownImage.Source = new BitmapImage(new Uri("/Assets/CardBack.png", UriKind.Relative));
            DealerField.Children.Add(FaceDownImage);

            Image CardImage = new Image();
            CardImage.Height = CARD_HEIGHT;
            CardImage.Width = CARD_WIDTH;
            CardImage.Source = new BitmapImage(new Uri(GameBoardVM.DealerHand[1].ImageLocation));
            DealerField.Children.Add(CardImage);
        }

        private void HitButton_Click(object sender, RoutedEventArgs e)
        {
            GameBoardVM.Hit();
            UpdatePlayerField();
            UpdatePlayerScore();
        }

        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            FaceDownImage.Source = new BitmapImage(new Uri(GameBoardVM.DealerHand[0].ImageLocation));
            PlayerDealerHand();
        }
        private void PlayerDealerHand()
        {
        }
    }
}
