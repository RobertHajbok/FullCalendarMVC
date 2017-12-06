using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class SelectConstraintTests
    {
        [Test]
        public void AsSerializableObject_InitializedAsEventId_FunctionIsReturned()
        {
            string eventId = "1";
            SelectConstraint selectConstraint = new SelectConstraint(eventId);
            object target = selectConstraint.AsSerializableObject();
            target.Should().Be(eventId);
        }

        [Test]
        public void AsSerializableObject_InitializedAsBusinessHour_ObjectIsSerialized()
        {
            SelectConstraint selectConstraint = new SelectConstraint(new BusinessHour
            {
                Dow = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday },
                Start = TimeSpan.FromHours(10),
                End = TimeSpan.FromHours(15)
            });
            object target = selectConstraint.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                dow = selectConstraint.BusinessHours.Dow,
                start = "10:00",
                end = "15:00"
            });
        }
    }
}