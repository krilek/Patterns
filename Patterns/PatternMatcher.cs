namespace Patterns
{
    using System;
    using System.Collections.Generic;

    public class PatternMatcher
    {
        public PatternMatcher(string data, string pattern)
        {
            this.SearchAlgorithm = new NaivePatternSearch();
            this.Data = data;
            this.Pattern = pattern;
        }
        
        public string Data { get; set; }

        public List<int> Indexes => this.SearchAlgorithm.MatchPattern(this.Data, this.Pattern);

        public string Pattern { get; set; }

        public IPatternAlgorithm SearchAlgorithm { get; set; }
    }
}