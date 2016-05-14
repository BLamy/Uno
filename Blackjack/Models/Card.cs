using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Uno.Models.Enums;
using Blackjack.Models.Enums;

namespace Uno.Models
{
    [DataContract]
    public class Card
    {
        public Face Face
        {
            get
            {
                switch(CardValueStr)
                {
                    case "KING":
                        return Face.Wild;

                    case "QUEEN":
                        return Face.Draw2;

                    case "JACK":
                        return Face.Skip;

                    case "ACE":
                        return Face.Draw4;

                    default:
                        return (Face)int.Parse(CardValueStr);
                }
            }
        }

        public Color Color
        {
            get
            {
                if (Face == Face.Wild)
                {
                    return Color.Wild;
                }
                switch (SuitValueStr)
                {
                    case "CLUBS":
                        return Color.Red;
                    case "DIAMONDS":
                        return Color.Blue;
                    case "HEARTS":
                        return Color.Yellow;
                    case "SPADES":
                        return Color.Green;
                    default:
                        return Color.Wild;
                }
            }
        }

        public static string ColorAsString(Color color)
        {
            return color.ToString().Substring(0, 1).ToLower();
        }

        public static string FaceAsString(Face face)
        {
            switch (face) {
                case Face.Wild:
                    return "";
                case Face.Skip:
                    return "s";
                case Face.Reverse:
                    return "r";
                case Face.Draw2:
                    return "d";
                case Face.Draw4:
                    return "4";
                default:
                    return (int)face + "";
            }
        }
        public string ImageLocation { get
            {
                
                return $"\\Assets\\{Card.ColorAsString(Color)}{Card.FaceAsString(Face)}.png";
            }
        }


        #region Members
        [DataMember(Name = "value")]
        public string CardValueStr { get; set; }

        [DataMember(Name = "suit")]
        public string SuitValueStr { get; set; }

        [DataMember(Name = "code")]
        public string codeValueStr { get; set; }
        #endregion
    }
}