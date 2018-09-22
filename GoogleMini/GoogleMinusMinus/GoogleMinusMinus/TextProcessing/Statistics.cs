namespace GoogleMini.TextProcessing
{    
    public struct Statistics
    {
        public int TotalWordsIndexed { get; private set; }
        public int TotalUniqueWordsIndexed { get; private set; }
        public string LongestWordIndexed { get; private set; }
        public string ShortestWordIndexed { get; private set; }
        public string MostFrequentWordIndexed { get; private set; }
        public string LeastFrequentWordIndexed { get; private set; }

        public Statistics(int totalWordsIndexed, int totalUniqueWordsIndexed, string longestWordIndexed, string shortestWordIndexed, string mostFrequentWordIndexed, string leastFrequentWordIndexed)
        {
            TotalWordsIndexed = totalWordsIndexed;
            TotalUniqueWordsIndexed = totalUniqueWordsIndexed;
            LongestWordIndexed = longestWordIndexed;
            ShortestWordIndexed = shortestWordIndexed;
            MostFrequentWordIndexed = mostFrequentWordIndexed;
            LeastFrequentWordIndexed = leastFrequentWordIndexed;
        }        
    }
}
