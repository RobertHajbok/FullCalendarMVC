using FluentAssertions;
using NUnit.Framework;
using System.Drawing;

namespace FullCalendar.Extensions.Tests
{
    [TestFixture]
    public class ColorExtensionsTests
    {
        [Test]
        public void ToHexString_ColorIsSet_HexStringIsReturned()
        {
            Color darkRed = Color.DarkRed;
            darkRed.ToHexString().Should().Be("#8B0000");

            Color argbColor = Color.FromArgb(132, 185, 79);
            argbColor.ToHexString().Should().Be("#84B94F");
        }
    }
}