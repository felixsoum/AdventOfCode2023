using System.Text.RegularExpressions;

namespace AoC2023.Days
{
    internal class Day6
    {
        public Day6()
        {
            string[] lines = File.ReadAllLines("Input.txt");

            Regex rx = new Regex(@"\d+");

            MatchCollection timeMatches = rx.Matches(lines[0]);
            MatchCollection distanceMatches = rx.Matches(lines[1]);

            var timeList = timeMatches.Select(x => int.Parse(x.Groups[0].Value)).ToList();
            var distanceList = distanceMatches.Select(x => int.Parse(x.Groups[0].Value)).ToList();

            int result = 1;

            for (int i = 0; i < timeList.Count; i++)
            {
                int winningWays = 0;
                for (int t = 1; t < timeList[i]; t++)
                {
                    int timeToMove = timeList[i] - t;
                    int distance = t * timeToMove;
                    if (distance > distanceList[i])
                    {
                        winningWays++;
                    }
                }
                result *= winningWays;
            }

            Console.WriteLine(result);
        }

        public void Part2()
        {

            string[] lines = File.ReadAllLines("Input.txt");

            lines[0] = lines[0].Replace(" ", "");
            lines[1] = lines[1].Replace(" ", "");

            long time = long.Parse(lines[0].Split(':')[1]);
            long record = long.Parse(lines[1].Split(':')[1]);

            long result = 1;

            {
                int winningWays = 0;
                for (int t = 1; t < time; t++)
                {
                    long timeToMove = time - t;
                    long distance = t * timeToMove;
                    if (distance > record)
                    {
                        winningWays++;
                    }
                }
                result *= winningWays;
            }

            Console.WriteLine(result);
        }
    }
}
