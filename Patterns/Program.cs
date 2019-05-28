namespace Patterns
{
    using System;
    using System.IO;

    class Program
    {
        private static Tuple<string, string>[] filesNames =
            new Tuple<string, string>[] { new Tuple<string, string>(@"tekst.txt", @"wzorzec.txt.") };

        static void Main(string[] args)
        {
            string data = File.ReadAllText(filesNames[0].Item1);
            string pattern = File.ReadAllText(filesNames[0].Item2);
            PatternMatcher matcher = new PatternMatcher(data, pattern);
            foreach (int index in matcher.Indexes)
            {
                Console.WriteLine($"Founded match at: {index}");
            }
        }
    }
}