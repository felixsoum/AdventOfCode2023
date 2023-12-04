namespace AoC2023.Days
{
    internal class Day2
    {
        public Day2()
        {
            var lines = File.ReadAllLines("Input.txt");
            int IDSUM = 0;

            foreach (var line in lines)
            {
                var split1 = line.Split(':');
                var split2 = split1[1].Split(";");

                bool isValid = true;
                foreach (var line2 in split2)
                {
                    int red = 0;
                    int blue = 0;
                    int green = 0;

                    var split3 = line2.Split(",");

                    foreach (var word in split3)
                    {
                        var split4 = word.Split(" ");
                        char lastChar = split4[2][^1];
                        switch (lastChar)
                        {
                            case 'd':
                                int.TryParse(split4[1], out red);
                                break;
                            case 'e':
                                int.TryParse(split4[1], out blue);
                                break;
                            case 'n':
                                int.TryParse(split4[1], out green);
                                break;
                        }
                    }

                    if (red > 12 || green > 13 || blue > 14)
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    var game = split1[0].Split(" ");
                    int id = 0;
                    int.TryParse(game[1], out id);
                    IDSUM += id;
                }

            }

            Console.WriteLine(IDSUM);
        }
    }
}
