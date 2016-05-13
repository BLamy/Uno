using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Uno.Models.Enums;

namespace Uno.Models
{
    [DataContract]
    public class Card
    {
        private int cardValue;
        public int CardValue {
            get {
                int cardNumericValue;
                if (CardValueStr.Equals("KING") ||
                    CardValueStr.Equals("Queen") ||
                    CardValueStr.Equals("Jack")) {
                    cardNumericValue = 10;
                } 
                else if (CardValueStr.Equals("ACE"))
                {
                    cardNumericValue = 11;
                }
                else
                {
                    cardNumericValue = int.Parse(CardValueStr);
                }
                return cardNumericValue;
            }
            set {
                cardValue = value;
            }
        }

        public Suit CardSuit {
            get {
                Suit suit;
                switch (SuitValueStr)
                {
                    case "CLUBS":
                        suit = Suit.Clubs;
                        break;
                    case "DIAMONDS":
                        suit = Suit.Diamonds;
                        break;
                    case "HEARTS":
                        suit = Suit.Hearts;
                        break;
                    case "Spades":
                        suit = Suit.Spades;
                        break;
                    default:
                        suit = Suit.Spades;
                        break;
                }
                return suit;
            }
            set {

            }
        }


        #region Members
        [DataMember(Name = "image")]
        public string ImageLocation { get; set; }

        [DataMember(Name = "value")]
        public string CardValueStr { get; set; }

        [DataMember(Name = "suit")]
        public string SuitValueStr { get; set; }

        [DataMember(Name = "code")]
        public string codeValueStr { get; set; }
        #endregion
    }
}
