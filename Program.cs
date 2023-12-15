using AoC2023.Days;

string[] lines = File.ReadAllLines("Input.txt");

long sum = 0;
foreach (var line in lines)
{
    List<List<long>> sequences = new();
    sequences.Add(line.Split(' ').Select(x => long.Parse(x)).ToList());
    bool allZero = true;
    do
    {
        allZero = true;
        for (int i = 0; i < sequences[^1].Count; i++)
        {
            if (sequences[^1][i] != 0)
            {
                allZero = false;
                break;
            }
        }

        if (allZero)
        {
            break;
        }

        var nextSequence = Util.Process(sequences[^1]);
        sequences.Add(nextSequence);
    }
    while (!allZero);

    sequences[^1].Add(0);
    for (int i = sequences.Count - 2; i >= 0; i--)
    {
        sequences[i].Add(sequences[i + 1][^1] + sequences[i][^1]);
    }

    sum += sequences[0][^1];
    Console.WriteLine(sequences[0][^1]);
}

Console.WriteLine(sum);