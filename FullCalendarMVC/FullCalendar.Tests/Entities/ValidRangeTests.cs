using FluentAssertions;
using NUnit.Framework;
using System;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class ValidRangeTests
    {
        [Test]
        public void AsSerializableObject_InitializedAsFunction_FunctionIsReturned()
        {
            string function = "function() { alert(''); }";
            ValidRange validRange = new ValidRange(function);
            object target = validRange.AsSerializableObject();
            target.Should().Be(function);
        }

        [Test]
        public void AsSerializableObject_DateRangeIsSet_ObjectIsSerialized()
        {
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(2);
            ValidRange validRange = new ValidRange(start, end);
            object target = validRange.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                start = start.ToString("yyyy-MM-dd"),
                end = end.ToString("yyyy-MM-dd")
            });
        }

        [Test]
        public void AsSerializableObject_OnlyEndDateIsSet_ObjectIsSerialized()
        {
            DateTime end = DateTime.Today.AddDays(2);
            ValidRange validRange = new ValidRange(end);
            object target = validRange.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                start = validRange.Start,
                end = end.ToString("yyyy-MM-dd")
            });
        }
    }
}