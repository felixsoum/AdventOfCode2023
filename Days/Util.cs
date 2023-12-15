namespace AoC2023.Days
{
    internal class Util
    {
        public static List<long> Process(List<long> list)
        {
            List<long> result = new();

            for (int i = 0; i < list.Count - 1; i++)
            {
                result.Add(list[i + 1] - list[i]);
            }
            return result;
        }
    }
}
