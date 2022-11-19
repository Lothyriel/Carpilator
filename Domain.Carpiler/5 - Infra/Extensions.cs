using Domain.Carpiler.Semantic;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Carpiler.Infra
{
    public static class Extensions
    {
        public static string FormatUnidentified(char token, string sourceCode, int characterdsLeft)
        {
            int indexFound = sourceCode.Length - characterdsLeft - 1;
            int line = 0;
            foreach (var l in sourceCode.Split('\n'))
            {
                line++;

                if (indexFound < l.Length)
                    break;

                indexFound -= l.Length;
            }
            return $"The token {token} at line {line} pos {indexFound} was not identified as part of the language";
        }

        public static string FormatUnclosed(char token, string sourceCode, int characterdsLeft)
        {
            int indexFound = sourceCode.Length - characterdsLeft - 1;
            int line = 0;
            foreach (var l in sourceCode.Split('\n'))
            {
                line++;

                if (indexFound < l.Length)
                    break;

                indexFound -= l.Length;
            }

            return $"The token {token} at line {line} pos {indexFound} was not closed properly";
        }

        public static bool TryAdd<Key, Value>(this Dictionary<Key, Value> dict, Key key, Value value)
        {
            if (dict.ContainsKey(key))
            {
                return false;
            }

            dict.Add(key, value);
            return true;
        }

        public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> itens, int count)
        {
            return itens.Take(itens.Count() - count);
        }
    }
}