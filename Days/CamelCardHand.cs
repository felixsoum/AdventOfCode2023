public enum HandType
{
    FiveOfAKind,
    FourOfAKind,
    FullHouse,
    Triple,
    DoublePair,
    SinglePair,
    HighCard
}

namespace AoC2023.Days
{
    internal class CamelCardHand : IComparable<CamelCardHand>
    {
        public string hand;
        public int bid;
        public HandType? handType = null;

        public CamelCardHand(string hand, int bid)
        {
            this.hand = hand;
            this.bid = bid;
        }

        public int CompareTo(CamelCardHand? other)
        {
            if (handType < other.handType)
            {
                return -1;
            }
            else if (handType > other.handType)
            {
                return 1;
            }
            else
            {
                for (int i = 0; i < hand.Length; i++)
                {
                    if (hand[i] != other.hand[i])
                    {
                        return GetCardCost(hand[i]).CompareTo(GetCardCost(other.hand[i]));
                    }
                }
                return 0;
            }
        }

        public void CalculateHandType()
        {
            var occurences = new Dictionary<char, int>();
            foreach (char card in hand)
            {
                if (occurences.ContainsKey(card))
                {
                    occurences[card]++;
                }
                else
                {
                    occurences.Add(card, 1);
                }
            }

            char mostOccurrentCard = '?';
            int highestOccurence = -1;

            foreach (var occurence in occurences)
            {
                if (occurence.Value > highestOccurence)
                {
                    highestOccurence = occurence.Value;
                    mostOccurrentCard = occurence.Key;
                }
            }

            if (highestOccurence == 5)
            {
                handType = HandType.FiveOfAKind;
                return;
            }

            if (highestOccurence == 4)
            {
                handType = HandType.FourOfAKind;
                return;
            }

            if (highestOccurence == 3)
            {
                string rest = hand.Replace(mostOccurrentCard + "", "");
                if (rest[0] == rest[1])
                {
                    handType = HandType.FullHouse;
                }
                else
                {
                    handType = HandType.Triple;
                }
                return;
            }

            if (highestOccurence == 2)
            {
                string rest = hand.Replace(mostOccurrentCard + "", "");
                if (rest[0] != rest[1]
                    && rest[0] != rest[2]
                    && rest[1] != rest[2])
                {
                    handType = HandType.SinglePair;
                }
                else
                {
                    handType = HandType.DoublePair;
                }
                return;
            }

            handType = HandType.HighCard;
        }

        public int GetCardCost(int card)
        {
            return card switch
            {
                'K' => 1,
                'Q' => 2,
                'J' => 3,
                'T' => 4,
                '9' => 5,
                '8' => 6,
                '7' => 7,
                '6' => 8,
                '5' => 9,
                '4' => 10,
                '3' => 11,
                '2' => 12,
                _ => 0,
            };
        }
    }
}
