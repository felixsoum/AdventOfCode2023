namespace AoC2023.Days
{
    internal class Day5
    {
        public Day5()
        {
            string[] lines = File.ReadAllLines("Input.txt");

            var seeds = lines[0].Split(' ');
            List<AlmanacMap>[] maps = new List<AlmanacMap>[7];
            int mapIndex = 0;

            for (int i = 0; i < maps.Length; i++)
            {
                maps[i] = new List<AlmanacMap>();
            }

            bool isNumberLine = true;
            for (int i = 0; i < lines.Length; i++)
            {
                if (i < 3)
                {
                    continue;
                }

                if (isNumberLine)
                {
                    if (lines[i].Length > 0)
                    {
                        var split = lines[i].Split(' ');
                        long d = long.Parse(split[0]);
                        long s = long.Parse(split[1]);
                        long r = long.Parse(split[2]);

                        maps[mapIndex].Add(new AlmanacMap(d, s, r));
                    }
                    else
                    {
                        isNumberLine = false;
                        mapIndex++;
                        continue;
                    }
                }
                else
                {
                    isNumberLine = true;
                    continue;
                }


            }

            long? smallestLocation = null;

            for (int i = 1; i < seeds.Length; i++)
            {
                long input = long.Parse(seeds[i]);
                for (int j = 0; j < maps.Length; j++)
                {

                    for (int k = 0; k < maps[j].Count; k++)
                    {
                        var result = maps[j][k].Map(input);
                        if (result.HasValue)
                        {
                            input = result.Value;
                            break;
                        }
                    }
                }

                if (!smallestLocation.HasValue || smallestLocation.Value > input)
                {
                    smallestLocation = input;
                }
            }

            Console.WriteLine(smallestLocation.Value);
        }

        void Part2()
        {
            string[] lines = File.ReadAllLines("Input.txt");

            var seeds = lines[0].Split(' ');
            List<AlmanacMap>[] maps = new List<AlmanacMap>[7];
            int mapIndex = 0;

            for (int i = 0; i < maps.Length; i++)
            {
                maps[i] = new List<AlmanacMap>();
            }

            bool isNumberLine = true;
            for (int i = 0; i < lines.Length; i++)
            {
                if (i < 3)
                {
                    continue;
                }

                if (isNumberLine)
                {
                    if (lines[i].Length > 0)
                    {
                        var split = lines[i].Split(' ');
                        long d = long.Parse(split[0]);
                        long s = long.Parse(split[1]);
                        long r = long.Parse(split[2]);

                        maps[mapIndex].Add(new AlmanacMap(d, s, r));
                    }
                    else
                    {
                        isNumberLine = false;
                        mapIndex++;
                        continue;
                    }
                }
                else
                {
                    isNumberLine = true;
                    continue;
                }
            }

            long? smallestLocation = null;

            for (int i = 1; i < seeds.Length; i += 2)
            {
                long startInput = long.Parse(seeds[i]);
                long range = long.Parse((seeds[i + 1]));
                for (int r = 0; r < range; r++)
                {
                    long input = startInput + r;
                    for (int j = 0; j < maps.Length; j++)
                    {

                        for (int k = 0; k < maps[j].Count; k++)
                        {
                            var result = maps[j][k].Map(input);
                            if (result.HasValue)
                            {
                                input = result.Value;
                                break;
                            }
                        }
                    }

                    if (!smallestLocation.HasValue || smallestLocation.Value > input)
                    {
                        smallestLocation = input;
                    }
                }
            }

            Console.WriteLine(smallestLocation.Value);
        }
    }
}
