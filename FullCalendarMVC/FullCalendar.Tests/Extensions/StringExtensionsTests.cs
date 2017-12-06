using FluentAssertions;
using NUnit.Framework;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void FirstCharToLower_StringIsPassed_FirstCharIsTransformed()
        {
            string target = "Test";
            target.FirstCharToLower().Should().Be("test");
        }

        [Test]
        public void FirstCharToLower_StringIsNullOrEmpty_StringIsReturned()
        {
            string target = null;
            target.FirstCharToLower().Should().Be(null);

            target = "";
            target.FirstCharToLower().Should().Be("");
        }

        [Test]
        public void ToSingleQuotes_StringContainsQuotes_StringIsTransformed()
        {
            string target = "abc\"test''\"|";
            target.ToSingleQuotes().Should().Be(@"abc'test\'\''|");
        }

        [Test]
        public void ToSingleQuotes_StringIsNullOrEmpty_StringIsReturned()
        {
            string target = null;
            target.ToSingleQuotes().Should().Be(null);

            target = "";
            target.ToSingleQuotes().Should().Be("");
        }
    }
}