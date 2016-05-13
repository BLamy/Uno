using Uno.Services.Request;
using Uno.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.Services
{
    public class DataService
    {
        private const string CARD_API = "http://deckofcardsapi.com/api";

        public string NewDecks(int numberOfDesks)
        {
            //Call Service...
            Uri serviceUri = new Uri($"{CARD_API}/deck/new/shuffle/?deck_count={numberOfDesks}");
            ServiceManager manager = new ServiceManager(serviceUri);
            var response = manager.CallService<DeckResponse>();
            return response.DeckID;
        }

        public DrawResponse Draw(DrawRequest drawReq)
        {
            Uri serviceUri = new Uri($"{CARD_API}/deck/{drawReq.DeckID}/draw/?count={drawReq.NumberOfCards}");
            ServiceManager manager = new ServiceManager(serviceUri);
            return manager.CallService<DrawResponse>();
        }
    }
}
