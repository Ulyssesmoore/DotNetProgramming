using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"..\..\resource\lorem_ipsum.txt";
            var words = GetWords(path, s => s.StartsWith("a")).ToList();
            var arrayWords = words.ToArray<string>();
            Array.Sort(arrayWords, (x, y) => x.Length == y.Length ? 0 : x.Length < y.Length ? -1 : x.Length > y.Length ? 1 : 0);
            foreach (var word in arrayWords)
            {
                Console.WriteLine(word + "; ");
            }
            Console.ReadKey();
        }

        private static IEnumerable<String> GetWords(string path, Func<string, bool> Expression)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line)) continue;
                var rgx = new Regex("[^a-zA-Z0-9 -]");
                var words = rgx.Replace(line, "").Trim().Split(' '); ;
                foreach(var word in words)
                {
                    if(Expression(word))
                    {
                        yield return word;
                    }
                }
            }
        }
    }
}
