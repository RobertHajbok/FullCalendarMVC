using FluentAssertions;
using NUnit.Framework;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pixel_UnitSetAsPixels_ValueAndTypeAreCorrectlySet()
        {
            Unit unit = Unit.Pixel(32);
            unit.Value.Should().Be("32");
            unit.Type.Should().Be(UnitType.Pixel);
        }

        [Test]
        public void Pixel_UnitSetAsFunction_ValueAndTypeAreCorrectlySet()
        {
            string function = "function() { alert(''); }";
            Unit unit = Unit.Function(function);
            unit.Value.Should().Be(function);
            unit.Type.Should().Be(UnitType.Function);
        }

        [Test]
        public void Pixel_UnitSetAsAuto_ValueAndTypeAreCorrectlySet()
        {
            Unit unit = Unit.Auto();
            unit.Value.Should().BeNull();
            unit.Type.Should().Be(UnitType.Auto);
        }

        [Test]
        public void Pixel_UnitSetAsParent_ValueAndTypeAreCorrectlySet()
        {
            Unit unit = Unit.Parent();
            unit.Value.Should().BeNull();
            unit.Type.Should().Be(UnitType.Parent);
        }
    }
}