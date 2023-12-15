using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023.Days
{
    internal class Day7
    {
        public Day7()
        {
            string[] lines = File.ReadAllLines("Input.txt");
            List<CamelCardHand> sortedHands = new();

            foreach (string line in lines)
            {
                var split = line.Split(' ');
                var hand = new CamelCardHand(split[0], int.Parse(split[1]));
                hand.CalculateHandType();
                sortedHands.Add(hand);
            }

            sortedHands.Sort();

            int winnings = 0;

            for (int i = 0; i < sortedHands.Count; i++)
            {
                int rank = sortedHands.Count - i;
                winnings += sortedHands[i].bid * rank;
            }

            Console.WriteLine(winnings);
        }
    }
}
