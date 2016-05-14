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
        public string DeckId { get; set; }

        public List<Card> PlayerHand { get; set; }

        public List<Card> ComputerHand { get; set; }
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
        }

        private List<Card> Draw(int numberOfCards)
        {
            DrawRequest drawReq = new DrawRequest();
            drawReq.DeckID = DeckId;
            drawReq.NumberOfCards = numberOfCards;
            return dataService.Draw(drawReq).Cards;
        }
    }
}
