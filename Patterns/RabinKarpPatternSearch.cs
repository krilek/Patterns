namespace Patterns
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class RabinKarpPatternSearch : IPatternAlgorithm
    {
        private int d;

        private int q;

        public RabinKarpPatternSearch(int primeNumber, int numberOfCharacters)
        {
            this.q = primeNumber;
            this.d = numberOfCharacters;
        }

        public List<int> MatchPattern(string data, string pattern)
        {
            data = Regex.Replace(data, @"\s+", string.Empty);
            pattern = Regex.Replace(pattern, @"\s+", string.Empty);
            List<int> indexes = new List<int>();
            int p = 0;
            int t = 0;
            int h = 1;

            for (int i = 0; i < pattern.Length - 1; i++)
            {
                h = h * this.d % this.q;
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                p = (this.d * p + pattern[i]) % this.q;
                t = (this.d * t + data[i]) % this.q;
            }

            for (int i = 0; i <= data.Length - pattern.Length; i++)
            {
                // Hashes are equal so check letters
                if (p == t)
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

                // Re calc hash for moved pattern to right
                if (i < data.Length - pattern.Length)
                {
                    int t1 = t - data[i] * h;
                    t = (this.d * t1 + data[i + pattern.Length]) % this.q;

                    if (t < 0)
                    {
                        t += this.q;
                    }
                }
            }

            return indexes;
        }
    }
}