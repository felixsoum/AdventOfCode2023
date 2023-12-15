class Day3
{
    public Day3()
    {
        var lines = File.ReadAllLines("Input.txt");

        int colNum = lines[0].Length;
        int rowNum = lines.Length;

        int sumOfParts = 0;

        var checkArray = new bool[colNum, rowNum];
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                char c = lines[i][j];
                bool isSymbol = !(c >= '0' && c <= '9' || c == '.');

                if (isSymbol)
                {
                    for (int x = -1; x < 2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            if (x + j >= 0
                                && x + j < colNum
                                && y + i >= 0
                                && y + i < rowNum)
                            {
                                checkArray[x + j, y + i] = true;
                            }
                        }
                    }
                }
            }
        }

        for (int i = 0; i < lines.Length; i++)
        {
            bool isCurrentlyNumbering = false;
            int numberValue = -1;
            bool isCurrentNumberAdjacentToSymbol = false;

            for (int j = 0; j < lines[i].Length; j++)
            {
                char c = lines[i][j];
                bool isNumber = c >= '0' && c <= '9';

                if (!isCurrentlyNumbering)
                {
                    if (isNumber)
                    {
                        isCurrentlyNumbering = true;
                        numberValue = c - '0';
                        isCurrentNumberAdjacentToSymbol |= checkArray[j, i];
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    if (isNumber)
                    {
                        numberValue *= 10;
                        numberValue += c - '0';
                        isCurrentNumberAdjacentToSymbol |= checkArray[j, i];
                    }

                    if (!isNumber || j == colNum - 1)
                    {
                        isCurrentlyNumbering = false;
                        if (isCurrentNumberAdjacentToSymbol)
                        {
                            sumOfParts += numberValue;
                        }
                        isCurrentNumberAdjacentToSymbol = false;
                        numberValue = -1;
                    }
                }
            }
        }

        Console.WriteLine(sumOfParts);

    }
}