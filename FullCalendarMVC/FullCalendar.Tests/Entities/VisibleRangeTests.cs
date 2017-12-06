using FluentAssertions;
using NUnit.Framework;
using System;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class VisibleRangeTests
    {
        [Test]
        public void AsSerializableObject_InitializedAsFunction_FunctionIsReturned()
        {
            string function = "function() { alert(''); }";
            VisibleRange visibleRange = new VisibleRange(function);
            object target = visibleRange.AsSerializableObject();
            target.Should().Be(function);
        }

        [Test]
        public void AsSerializableObject_DateRangeIsSet_ObjectIsSerialized()
        {
            DateTime start = DateTime.Today;
            DateTime end = DateTime.Today.AddDays(2);
            VisibleRange visibleRange = new VisibleRange(start, end);
            object target = visibleRange.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                start = start.ToString("yyyy-MM-dd"),
                end = end.ToString("yyyy-MM-dd")
            });
        }
    }
}