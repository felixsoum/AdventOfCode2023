namespace AoC2023.Days
{
    internal class Day8
    {
        public Day8()
        {
            string[] lines = File.ReadAllLines("Input.txt");

            string steps = lines[0];
            int stepIndex = 0;
            int stepCount = 0;
            Dictionary<string, Tuple<string, string>> nodes = new();

            for (int i = 2; i < lines.Length; i++)
            {
                string key = lines[i].Substring(0, 3);
                string left = lines[i].Substring(7, 3);
                string right = lines[i].Substring(12, 3);
                nodes.Add(key, new Tuple<string, string>(left, right));
            }

            string currentKey = "AAA";
            while (currentKey != "ZZZ")
            {
                stepCount++;
                var node = nodes[currentKey];

                stepIndex %= steps.Length;

                if (steps[stepIndex++] == 'L')
                {
                    currentKey = nodes[currentKey].Item1;
                }
                else
                {
                    currentKey = nodes[currentKey].Item2;
                }
            }

            Console.WriteLine(stepCount);
        }
    }
}
