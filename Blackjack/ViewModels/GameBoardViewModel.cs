using Uno.Models;
using Uno.Services;
using Uno.Services.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Models.Enums;

namespace Uno.ViewModels
{
    public enum Player
    {
        player,
        computer
    }

    public class GameBoardViewModel
    {
        #region Game State Props
        public string DeckId { get; set; }

        public List<Card> PlayerHand { get; set; }

        public List<Card> ComputerHand { get; set; }

        public Card lastCard { get; set; }

        public int numberOfPlayers { get; set; } = 2;

        public Player turn { get; set; } = Player.player;
        #endregion

        DataService dataService;

        public GameBoardViewModel()
        {
            dataService = new DataService();
            NewGame();
        }

        private void NewGame()
        {
            DeckId = dataService.NewDecks(1);
            DealInitialHands();
        }

        private void DealInitialHands()
        {
            PlayerHand = Draw(7);
            ComputerHand = Draw(7);
            lastCard = Draw(1)[0];
            while (lastCard.Color == Color.Wild)
            {
                lastCard = Draw(1)[0];
            }
        }

        private List<Card> Draw(int numberOfCards)
        {
            DrawRequest drawReq = new DrawRequest();
            drawReq.DeckID = DeckId;
            drawReq.NumberOfCards = numberOfCards;
            return dataService.Draw(drawReq).Cards;
        }

        private List<Card> activeHand()
        {
            return (this.turn == Player.player) ? this.PlayerHand : this.ComputerHand;
        }

        private void PlayCard(Card card)
        {
            this.activeHand().Remove(card);
            this.lastCard = card;
            turn = (turn == Player.player) ? Player.computer : Player.player;
        }

        public bool tryPlay(Card card)
        {
            // Sanity check to make sure the card is even in the hand. 
            bool isInHand = this.activeHand().FindIndex(item => item == card) != -1;
            if (!isInHand)
                return false;

            // Wild cards can always be played. Any color can be played after a wild card.
            bool isWild = card.Color == Color.Wild || this.lastCard.Color == Color.Wild;
            // Otherwise you can only play a card if it is the same color or face.
            bool isSameColor = card.Color == this.lastCard.Color;
            bool isSameNumber = card.Face == this.lastCard.Face;

            if (isWild || isSameColor || isSameNumber)
            {
                this.PlayCard(card);
                return true;
            }

            return false;
        }
    }
}
