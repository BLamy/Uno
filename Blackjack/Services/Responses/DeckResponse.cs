using System.Runtime.Serialization;

namespace Uno.Services.Responses
{
    [DataContract]
    public class DeckResponse
    {
        [DataMember(Name = "success")]
        public bool IsSuccess { get; set; }

        [DataMember(Name = "deck_id")]
        public string DeckID { get; set; }

        [DataMember(Name = "shuffled")]
        public bool IsShuffled { get; set; }

        [DataMember(Name = "remaining")]
        public int CardsRemaining { get; set; }
    }
}
