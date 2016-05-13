using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack.Models.Enums
{
    public enum Color
    {
        Wild = 1 << 0,
        Red = 1 << 1,
        Blue = 1 << 2,
        Green = 1 << 3,
        Yellow = 1 << 4
    }
}
