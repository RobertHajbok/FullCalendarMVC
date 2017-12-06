using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class EventConstraintTests
    {
        [Test]
        public void AsSerializableObject_InitializedAsEventId_FunctionIsReturned()
        {
            string eventId = "1";
            EventConstraint eventConstraint = new EventConstraint(eventId);
            object target = eventConstraint.AsSerializableObject();
            target.Should().Be(eventId);
        }

        [Test]
        public void AsSerializableObject_InitializedAsBusinessHour_ObjectIsSerialized()
        {
            EventConstraint eventConstraint = new EventConstraint(new BusinessHour
            {
                Dow = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday },
                Start = TimeSpan.FromHours(10),
                End = TimeSpan.FromHours(15)
            });
            object target = eventConstraint.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                dow = eventConstraint.BusinessHours.Dow,
                start = "10:00",
                end = "15:00"
            });
        }
    }
}