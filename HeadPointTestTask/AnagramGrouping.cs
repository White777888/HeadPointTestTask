using System.Collections.Generic;
using System.Linq;

namespace HeadPointTestTask
{
    public static class AnagramGrouping
    {
        public static string[][] GroupAnagrams(IEnumerable<string> anargrams)
        {
            return anargrams
                .GroupBy(OrderedAnagramInLowercase)
                .Select(group => group.ToArray())
                .ToArray();
        }

        private static string OrderedAnagramInLowercase(string anagram) =>
            string.Concat(anagram.ToLower().OrderBy(ch => ch));
    }
}
