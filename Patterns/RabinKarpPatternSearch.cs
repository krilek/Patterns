namespace Patterns
{
    using System.Collections.Generic;

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
            List<int> indexes = new List<int>();
            int p = 0; // hash value for pattern  
            int t = 0; // hash value for txt  
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
                // Check the hash values of current window of text  
                // and pattern. If the hash values match then only  
                // check for characters on by one  
                if (p == t)
                {
                    /* Check for characters one by one */
                    int j;
                    for (j = 0; j < pattern.Length; j++)
                    {
                        if (data[i + j] != pattern[j])
                        {
                            break;
                        }
                    }

                    // if p == t and pat[0...pattern.Length-1] = txt[i, i+1, ...i+pattern.Length-1]  
                    if (j == pattern.Length)
                    {
                        indexes.Add(i);
                    }
                }

                // Calculate hash value for next window of text: Remove  
                // leading digit, add trailing digit  
                if (i < data.Length - pattern.Length)
                {
                    t = (this.d * (t - data[i] * h) + data[i + pattern.Length]) % this.q;

                    // We might get negative value of t, converting it  
                    // to positive  
                    if (t < 0)
                        t = (t + this.q);
                }
            }

            return indexes;
        }

        // private 
    }
}