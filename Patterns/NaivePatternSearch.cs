namespace Patterns
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class NaivePatternSearch : IPatternAlgorithm
    {
        List<char> charactersToSkip = new List<char>();

        public List<int> MatchPattern(string data, string pattern)
        {
            data = Regex.Replace(data, @"\s+", string.Empty);
            pattern = Regex.Replace(pattern, @"\s+", string.Empty);
            List<int> indexes = new List<int>();
            for (int i = 0; i < data.Length - pattern.Length; i++)
            {
                int j;
                for (j = 0; j < pattern.Length; j++)
                {
                    // if(this.charactersToSkip.Contains(pattern[j])) continue;
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