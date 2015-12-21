using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    class CardList
    {

        Card[] ArrayCards = new Card[52];

        public CardList()
        {
            ArrayCards[0] = new Card { Suit = Suit.HEARTH, Value = 2 };
            ArrayCards[1] = new Card { Suit = Suit.HEARTH, Value = 3 };
            ArrayCards[2] = new Card { Suit = Suit.HEARTH, Value = 4 };
            ArrayCards[3] = new Card { Suit = Suit.HEARTH, Value = 5 };
            ArrayCards[4] = new Card { Suit = Suit.HEARTH, Value = 6 };
            ArrayCards[5] = new Card { Suit = Suit.HEARTH, Value = 7 };
            ArrayCards[6] = new Card { Suit = Suit.HEARTH, Value = 8 };
            ArrayCards[7] = new Card { Suit = Suit.HEARTH, Value = 9 };
            ArrayCards[8] = new Card { Suit = Suit.HEARTH, Value = 10 };
            ArrayCards[9] = new Card { Suit = Suit.HEARTH, Value = 11 };
            ArrayCards[10] = new Card { Suit = Suit.HEARTH, Value = 12 };
            ArrayCards[11] = new Card { Suit = Suit.HEARTH, Value = 13 };
            ArrayCards[12] = new Card { Suit = Suit.HEARTH, Value = 14 };

            ArrayCards[13] = new Card { Suit = Suit.DIAMOND, Value = 2 };
            ArrayCards[14] = new Card { Suit = Suit.DIAMOND, Value = 3 };
            ArrayCards[15] = new Card { Suit = Suit.DIAMOND, Value = 4 };
            ArrayCards[16] = new Card { Suit = Suit.DIAMOND, Value = 5 };
            ArrayCards[17] = new Card { Suit = Suit.DIAMOND, Value = 6 };
            ArrayCards[18] = new Card { Suit = Suit.DIAMOND, Value = 7 };
            ArrayCards[19] = new Card { Suit = Suit.DIAMOND, Value = 8 };
            ArrayCards[20] = new Card { Suit = Suit.DIAMOND, Value = 9 };
            ArrayCards[21] = new Card { Suit = Suit.DIAMOND, Value = 10 };
            ArrayCards[22] = new Card { Suit = Suit.DIAMOND, Value = 11 };
            ArrayCards[23] = new Card { Suit = Suit.DIAMOND, Value = 12 };
            ArrayCards[24] = new Card { Suit = Suit.DIAMOND, Value = 13 };
            ArrayCards[25] = new Card { Suit = Suit.DIAMOND, Value = 14 };

            ArrayCards[26] = new Card { Suit = Suit.CLUB, Value = 2 };
            ArrayCards[27] = new Card { Suit = Suit.CLUB, Value = 3 };
            ArrayCards[28] = new Card { Suit = Suit.CLUB, Value = 4 };
            ArrayCards[29] = new Card { Suit = Suit.CLUB, Value = 5 };
            ArrayCards[30] = new Card { Suit = Suit.CLUB, Value = 6 };
            ArrayCards[31] = new Card { Suit = Suit.CLUB, Value = 7 };
            ArrayCards[32] = new Card { Suit = Suit.CLUB, Value = 8 };
            ArrayCards[33] = new Card { Suit = Suit.CLUB, Value = 9 };
            ArrayCards[34] = new Card { Suit = Suit.CLUB, Value = 10 };
            ArrayCards[35] = new Card { Suit = Suit.CLUB, Value = 11 };
            ArrayCards[36] = new Card { Suit = Suit.CLUB, Value = 12 };
            ArrayCards[37] = new Card { Suit = Suit.CLUB, Value = 13 };
            ArrayCards[38] = new Card { Suit = Suit.CLUB, Value = 14 };

            ArrayCards[39] = new Card { Suit = Suit.SPADE, Value = 2 };
            ArrayCards[40] = new Card { Suit = Suit.SPADE, Value = 3 };
            ArrayCards[41] = new Card { Suit = Suit.SPADE, Value = 4 };
            ArrayCards[42] = new Card { Suit = Suit.SPADE, Value = 5 };
            ArrayCards[43] = new Card { Suit = Suit.SPADE, Value = 6 };
            ArrayCards[44] = new Card { Suit = Suit.SPADE, Value = 7 };
            ArrayCards[45] = new Card { Suit = Suit.SPADE, Value = 8 };
            ArrayCards[46] = new Card { Suit = Suit.SPADE, Value = 9 };
            ArrayCards[47] = new Card { Suit = Suit.SPADE, Value = 10 };
            ArrayCards[48] = new Card { Suit = Suit.SPADE, Value = 11 };
            ArrayCards[49] = new Card { Suit = Suit.SPADE, Value = 12 };
            ArrayCards[50] = new Card { Suit = Suit.SPADE, Value = 13 };
            ArrayCards[51] = new Card { Suit = Suit.SPADE, Value = 14 };
        }

        public int GetValue(int index)
        {
            return ArrayCards[index].Value;

        }

        public Suit GetSuit(int index)
        {
            return ArrayCards[index].Suit;
        }
    }
}
