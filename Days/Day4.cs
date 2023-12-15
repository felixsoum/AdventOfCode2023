using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023.Days
{
    internal class Day4
    {
        public Day4()
        {
            string[] lines = File.ReadAllLines("Input.txt");

            int totalScore = 0;
            foreach (var line in lines)
            {
                string[] split1 = line.Split('|');
                string[] leftSplit = split1[0].Split(' ');
                var winningNumbers = new List<int>();
                int myNumberCount = 0;

                for (int i = 2; i < leftSplit.Length - 1; i++)
                {
                    int n = 0;
                    int.TryParse(leftSplit[i], out n);
                    winningNumbers.Add(n);
                }

                string[] rightSplit = split1[1].Split(' ');
                for (int j = 1; j < rightSplit.Length; j++)
                {
                    int n = 0;
                    if (int.TryParse(rightSplit[j], out n))
                    {
                        if (winningNumbers.Contains(n))
                        {
                            myNumberCount++;
                        }
                    }
                }

                if (myNumberCount > 0)
                {
                    int score = (int)Math.Pow(2, myNumberCount - 1);
                    totalScore += score;
                }
            }

            Console.WriteLine(totalScore);

        }
    }
}
