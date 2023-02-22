using HeadPointTestTask;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    internal class AnagramGroupingTests
    {
        [Test]
        public void GroupsAnagrams()
        {
            var anagrams = new[] { "ток", "рост", "кот", "торс", "кто", "фывап", "рок" };
            var expectedAnagramGroups = new[] {
                new[] { "ток", "кот", "кто" },
                new[] { "рост", "торс" },
                new[] { "фывап" },
                new[] { "рок" }
            };

            var actualAnagramGroups = AnagramGrouping.GroupAnagrams(anagrams);

            Assert.IsTrue(AnagramGroupsAreEqual(expectedAnagramGroups, actualAnagramGroups));
        }

        [Test]
        public void CaseInsensitive()
        {
            var anagrams = new[] { "ток", "Рост", "кот", "торс", "Кто", "фывап", "рок" };
            var expectedAnagramGroups = new[] {
                new[] { "ток", "кот", "Кто" },
                new[] { "Рост", "торс" },
                new[] { "фывап" },
                new[] { "рок" }
            };

            var actualAnagramGroups = AnagramGrouping.GroupAnagrams(anagrams);

            Assert.IsTrue(AnagramGroupsAreEqual(expectedAnagramGroups, actualAnagramGroups));
        }

        [Test]
        public void EmptySequenceIsEmptyResult()
        {
            var emptyAnagrams = new string[0];

            var actualAnagramGroups = AnagramGrouping.GroupAnagrams(emptyAnagrams);

            Assert.IsEmpty(actualAnagramGroups);
        }

        private static bool AnagramGroupsAreEqual(string[][] first, string[][] second)
        {
            if (first.Length != second.Length)
                return false;

            return Enumerable
                .Range(0, first.Length)
                .All(i => first[i].SequenceEqual(second[i]));
        }
    }
}
