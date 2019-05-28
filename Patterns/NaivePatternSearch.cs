namespace Patterns
{
    using System.Collections.Generic;

    public class NaivePatternSearch : IPatternAlgorithm
    {
        public List<int> MatchPattern(string data, string pattern)
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < data.Length - pattern.Length; i++)
            {
                int j;
                for (j = 0; j < pattern.Length; j++)
                {
                    if (data[i + j] != pattern[j])
                    {
                        break;
                    }
                }

                if (j == pattern.Length)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }
    }
}