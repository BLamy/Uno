using Uno.Models;
using Uno.Services;
using Uno.Services.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Models.Enums;
using Uno.Views;
using Blackjack.Views;
using Uno.Services.Responses;

namespace Uno.ViewModels
{
    public enum Player
    {
        none,
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

        public object PlayerName { get; private set; }

        public int RemainingCards { get; private set; }
        #endregion

        DataService dataService;

        public GameBoardViewModel()
        {
            dataService = new DataService();
            NewGame();
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

        public void DrawCard()
        {
            this.activeHand().AddRange(this.RequestCards(1));
        }

        private void NewGame()
        {
            DeckId = dataService.NewDecks(1);
            DealInitialHands();
        }

        private void DealInitialHands()
        {
            PlayerHand = RequestCards(7);
            ComputerHand = RequestCards(7);
            lastCard = RequestCards(1)[0];
            while (lastCard.Color == Color.Wild)
            {
                lastCard = RequestCards(1)[0];
            }
        }

        private List<Card> RequestCards(int numberOfCards)
        {
            DrawRequest drawReq = new DrawRequest();
            drawReq.DeckID = DeckId;
            drawReq.NumberOfCards = numberOfCards;
            DrawResponse drawRes = dataService.Draw(drawReq);
            this.RemainingCards = drawRes.RemainingCards;
            return drawRes.Cards;
        }

        private List<Card> activeHand()
        {
            return (this.turn == Player.player) ? this.PlayerHand : this.ComputerHand;
        }

        private void nextTurn()
        {
            this.turn = (this.turn == Player.player) ? Player.computer : Player.player;
        }

        /// <summary>
        /// Win condition
        /// </summary>
        /// <returns></returns>
        public bool isGameover()
        {
            return (this.PlayerHand.Count == 0 || this.ComputerHand.Count == 0 || this.RemainingCards == 0 );
        }

        public Player winner()
        {
            if (this.PlayerHand.Count == 0)
                return Player.player;
            if (this.ComputerHand.Count == 0)
                return Player.computer;
            return Player.none;
        }

        private void PlayCard(Card card)
        {
            this.activeHand().Remove(card);
            this.lastCard = card;

            // Progress turns
            switch (card.Face)
            {
                case Face.Skip:
                    this.nextTurn();
                    this.nextTurn();
                    break;

                case Face.Draw2:
                    this.nextTurn();
                    this.activeHand().AddRange(this.RequestCards(2));
                    this.nextTurn();
                    break;

                case Face.Draw4:
                    this.nextTurn();
                    this.activeHand().AddRange(this.RequestCards(4));
                    this.nextTurn();
                    break;
                case Face.Wild:
                    break;

                default:
                    this.nextTurn();
                    break;
            }

        }

    }
}
