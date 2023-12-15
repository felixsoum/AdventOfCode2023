namespace AoC2023.Days
{
    internal class AlmanacMap
    {
        public long destinationNum;
        public long sourceNum;
        public long range;

        public AlmanacMap(long destinationNum, long sourceNum, long range)
        {
            this.destinationNum = destinationNum;
            this.sourceNum = sourceNum;
            this.range = range;
        }

        public long? Map(long input)
        {
            if (input >= sourceNum && input < sourceNum + range)
            {
                long delta = input - sourceNum;
                return destinationNum + delta;
            }
            return null;
        }

        public override string ToString()
        {
            return $"d: {destinationNum}, s: {sourceNum}, r: {range}";
        }
    }
}
