using FluentAssertions;
using NUnit.Framework;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class DurationTests
    {
        [Test]
        public void AsSerializableObject_DurationIsBuilded_ObjectIsCorrectlySerialized()
        {
            Duration duration = new Duration
            {
                Days = 1,
                Months = 2
            };
            object target = duration.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                days = 1,
                months = 2,
                weeks = duration.Weeks
            });
        }
    }
}