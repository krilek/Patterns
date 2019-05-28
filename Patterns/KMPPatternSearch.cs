namespace Patterns
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class KMPPatternSearch : IPatternAlgorithm
    {
        public List<int> MatchPattern(string data, string pattern)
        {
            data = Regex.Replace(data, @"\s+", string.Empty);
            pattern = Regex.Replace(pattern, @"\s+", string.Empty);

            var indexes = new List<int>();

            var suffixTable = this.GenerateSuffixTable(pattern);

            int i = 0;
            int j = 0;
            while (i < data.Length)
            {
                if (pattern[j] == data[i])
                {
                    j++;
                    i++;
                }

                if (j == pattern.Length)
                {
                    // Found match
                    indexes.Add(i - j);
                    j = suffixTable[j - 1];
                }

                // j matches, and mismatch, skip according to table or increment i
                else if (i < data.Length && pattern[j] != data[i])
                {
                    // Skip chars based on suffix table
                    if (j != 0)
                    {
                        j = suffixTable[j - 1];
                    }
                    else
                    {
                        i = i + 1;
                    }
                }
            }

            return indexes;
        }

        private int[] GenerateSuffixTable(string pattern)
        {
            var lps = new int[pattern.Length];
            var record = 0;
            lps[0] = 0;

            var i = 1;
            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[record])
                {
                    record++;
                    lps[i] = record;
                    i++;
                }
                else
                {
                    if (record != 0)
                    {
                        record = lps[record - 1];
                    }
                    else
                    {
                        // if (len == 0) 
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
    }
}