namespace Patterns
{
    using System;
    using System.Diagnostics;
    using System.IO;

    class Program
    {
        private static readonly Tuple<string, string>[] FilesNames =
            {
                new Tuple<string, string>(@"tekst.txt", @"wzorzec.txt."),
                new Tuple<string, string>(@"tekst1.txt", @"wzorzec1.txt.")
            };

        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("../../..");
            for (int file = 0; file < 2; file++)
            {
                Console.WriteLine($"Files: Data: {FilesNames[file].Item1}, Pattern: {FilesNames[file].Item2}");
                string data = File.ReadAllText(FilesNames[file].Item1);
                string pattern = File.ReadAllText(FilesNames[file].Item2);
                PatternMatcher matcher = new PatternMatcher(data, pattern);

                var stopwatch1 = Stopwatch.StartNew();
                var naiveResult = matcher.Indexes;
                stopwatch1.Stop();

                matcher.SearchAlgorithm = new RabinKarpPatternSearch(101, 256);
                var stopwatch2 = Stopwatch.StartNew();
                var rabinResult = matcher.Indexes;
                stopwatch2.Stop();

                matcher.SearchAlgorithm = new KMPPatternSearch();
                var stopwatch3 = Stopwatch.StartNew();
                var kmpResult = matcher.Indexes;
                stopwatch3.Stop();

                if (naiveResult.Count == rabinResult.Count && naiveResult.Count == kmpResult.Count)
                {
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine($"Founded {naiveResult.Count} occurrences of pattern in provided data.");
                    Console.WriteLine(new string('-', 10));
                    Console.WriteLine(
                        $"Naive algorithm:{stopwatch1.ElapsedMilliseconds}\nRabin Karp algorithm:{stopwatch2.ElapsedMilliseconds}\nKMP algorithm:{stopwatch3.ElapsedMilliseconds}");
                    Console.WriteLine(new string('-', 10));

                    // Algorithms work
                    foreach (int index in kmpResult)
                    {
                        Console.WriteLine($"Founded match at: {index}");
                    }

                    Console.WriteLine(new string('-', 10));
                }
                else
                {
                    Console.WriteLine($"Failed, some algorithm returned different amount of occurrences");
                }

                Console.ReadKey();
            }

            Console.ReadKey();
        }
    }
}