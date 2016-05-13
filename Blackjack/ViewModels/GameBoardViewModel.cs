using Uno.Models;
using Uno.Services;
using Uno.Services.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.ViewModels
{
    public class GameBoardViewModel
    {
        #region Game State Props
        public int PlayerScore { get; set; }

        public int DealerScore { get; set; }

        public string DeckId { get; set; }

        public List<Card> PlayerHand { get; set; }

        public List<Card> DealerHand { get; set; }
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
            PlayerHand = Draw(2);
            DealerHand = Draw(2);
            CalcScores();
        }

        private List<Card> Draw(int numberOfCards)
        {
            DrawRequest drawReq = new DrawRequest();
            drawReq.DeckID = DeckId;
            drawReq.NumberOfCards = numberOfCards;
            var foo = dataService.Draw(drawReq);
            return foo.Cards;
        }

        public void Hit()
        {
            PlayerHand.AddRange(Draw(1));
            CalcScores();
        }

        public void DealerHit()
        {
            PlayerHand.AddRange(Draw(1));
            CalcScores();
        }

        public bool DealerWillDrawAgain()
        {
            return (DealerScore < 17);
        }

        private void CalcScores()
        {
            int pScore = 0;
            int dScore = 0;
            foreach( var card in PlayerHand)
            {
                pScore += card.CardValue;
            }
            PlayerScore = pScore;

            foreach (var card in DealerHand)
            {
                dScore += card.CardValue;
            }
            DealerScore = dScore;
        }
    }
}
