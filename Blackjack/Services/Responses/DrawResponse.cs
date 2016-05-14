using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Uno.Models;

namespace Uno.Services.Responses
{
    [DataContract]
    public class DrawResponse
    {
        [DataMember(Name = "remaining")]
        public int RemainingCards { get; set; }

        [DataMember(Name = "cards")]
        public List<Card> Cards { get; set; }

    }
}
