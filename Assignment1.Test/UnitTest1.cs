using Assignment1;
using System.Collections.Generic;
using Xunit;

namespace Assignment1.Test
{
    public class Class1Tests
    {
        private readonly StringSearcher _class1 = new StringSearcher();

        // 1. Normal case: single match
        [Fact]
        public void SingleMatch_ReturnsCorrectIndex()
        {
            string s1 = "hello world";
            string s2 = "world";
            List<int> expected = new List<int> { 6 };

            var actual = _class1.FindAllIndexes(s1, s2);

            Assert.Equal(expected, actual);
        }

        // 2. Multiple matches
        [Fact]
        public void MultipleMatches_ReturnsAllIndexes()
        {
            string s1 = "ababab";
            string s2 = "ab";
            List<int> expected = new List<int> { 0, 2, 4 };

            var actual = _class1.FindAllIndexes(s1, s2);

            Assert.Equal(expected, actual);
        }

        // 3. No match found
        [Fact]
        public void NoMatch_ReturnsEmptyList()
        {
            string s1 = "hello";
            string s2 = "xyz";

            var actual = _class1.FindAllIndexes(s1, s2);

            Assert.Empty(actual);
        }

        // 4. Empty substring (s2)
        [Fact]
        public void EmptySubstring_ReturnsEmptyList()
        {
            string s1 = "hello";
            string s2 = "";

            var actual = _class1.FindAllIndexes(s1, s2);

            Assert.Empty(actual);
        }

        // 5. Substring longer than main string
        [Fact]
        public void SubstringLongerThanMain_ReturnsEmptyList()
        {
            string s1 = "hi";
            string s2 = "hello";

            var actual = _class1.FindAllIndexes(s1, s2);

            Assert.Empty(actual);
        }

        // 6. Case sensitivity check
        [Fact]
        public void CaseSensitive_ReturnsExactMatchesOnly()
        {
            string s1 = "Hello hello";
            string s2 = "hello";
            List<int> expected = new List<int> { 6 };

            var actual = _class1.FindAllIndexes(s1, s2);

            Assert.Equal(expected, actual);
        }

        // 7. Null inputs - expect ArgumentNullException (Optional: if your method throws it)
        [Fact]
        public void NullMainString_ThrowsArgumentNullException()
        {
            string s1 = null;
            string s2 = "test";

            Assert.Throws<System.ArgumentNullException>(() => _class1.FindAllIndexes(s1, s2));
        }

        [Fact]
        public void NullSubstring_ThrowsArgumentNullException()
        {
            string s1 = "test";
            string s2 = null;

            Assert.Throws<System.ArgumentNullException>(() => _class1.FindAllIndexes(s1, s2));
        }
    }
}
