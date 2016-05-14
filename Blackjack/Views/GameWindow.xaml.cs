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
            UpdatePlayerField();
            UpdateComputerField();
            
        }
        
        private void UpdateHandForPlayer(StackPanel field, List<Card> hand)
        {
            ClearPlayField(field);
            foreach (var card in hand)
            {
                Image CardImage = new Image();
                CardImage.Height = CARD_HEIGHT;
                CardImage.Width = CARD_WIDTH;
                CardImage.Source = new BitmapImage(new Uri(card.ImageLocation, UriKind.Relative));
                field.Children.Add(CardImage);
            }
        }

        private void UpdatePlayerField()
        {
            UpdateHandForPlayer(PlayerField, GameBoardVM.PlayerHand);
        }

        private void UpdateComputerField()
        {
            UpdateHandForPlayer(ComputerField, GameBoardVM.ComputerHand);
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
    }
}
