namespace Patterns
{
    using System.Collections.Generic;

    public class KMPPatternSearch : IPatternAlgorithm
    {
        public List<int> MatchPattern(string data, string pattern)
        {
            List<int> indexes = new List<int>();

            // Preprocess the pattern (calculate lps[] array) 
            var lps = this.computeLPSArray(pattern);

            int i = 0; // index for txt[] 
            int j = 0; // index for pat[] 
            while (i < data.Length)
            {
                if (pattern[j] == data[i])
                {
                    j++;
                    i++;
                }

                if (j == pattern.Length)
                {
                    indexes.Add(i - j);
                    j = lps[j - 1];
                }

                // mismatch after j matches 
                else if (i < data.Length && pattern[j] != data[i])
                {
                    // Do not match lps[0..lps[j-1]] characters, 
                    // they will match anyway 
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }

            return indexes;
        }

        private int[] computeLPSArray(string pattern)
        {
            int[] lps = new int[pattern.Length];

            // length of the previous longest prefix suffix 
            int len = 0;

            lps[0] = 0; // lps[0] is always 0 

            // the loop calculates lps[i] for i = 1 to M-1 
            int i = 1;
            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    // (pat[i] != pat[len]) 
                    // This is tricky. Consider the example. 
                    // AAACAAAA and i = 7. The idea is similar 
                    // to search step. 
                    if (len != 0)
                    {
                        len = lps[len - 1];

                        // Also, note that we do not increment 
                        // i here 
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