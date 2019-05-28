namespace Patterns
{
    using System.Collections.Generic;

    public interface IPatternAlgorithm
    {
        List<int> MatchPattern(string data, string pattern);
    }
}