using FluentAssertions;
using FullCalendar.Extensions;
using FullCalendar.Serialization.SerializableObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class EventCollectionTests
    {
        [Test]
        public void AsSerializableObject_InitializedAsJsonFeed_UrlIsReturned()
        {
            string url = "http://www.google.co.uk";
            EventCollection eventCollection = new EventCollection(url, EventCollectionType.JsonFeed);
            object target = eventCollection.AsSerializableObject();
            target.Should().Be(url);
        }

        [Test]
        public void AsSerializableObject_InitializedAsFunction_FunctionIsReturned()
        {
            string function = "function() { alert(''); }";
            EventCollection eventCollection = new EventCollection(function, EventCollectionType.Function);
            object target = eventCollection.AsSerializableObject();
            target.Should().Be(function);
        }

        [Test]
        public void AsSerializableObject_InitializedAsGoogleCalendarFeed_GoogleCalendarIdObjectIsReturned()
        {
            string googleCalendarId = "abcd1234@group.calendar.google.com";
            EventCollection eventCollection = new EventCollection(googleCalendarId, EventCollectionType.GoogleCalendarFeed);
            object target = eventCollection.AsSerializableObject();
            target.ShouldBeEquivalentTo(new
            {
                googleCalendarId = googleCalendarId
            });
        }

        [Test]
        public void AsSerializableObject_InitializedAsEmptyArray_NullIsReturned()
        {
            EventCollection eventCollection = new EventCollection(new List<Event>());
            object target = eventCollection.AsSerializableObject();
            target.Should().BeNull();
        }

        [Test]
        public void AsSerializableObject_InitializedAsArray_ListOfSerializableEventIsReturned()
        {
            EventCollection eventCollection = new EventCollection(new List<Event> { new Event() });
            object target = eventCollection.AsSerializableObject();
            target.Should().BeAssignableTo<IEnumerable<SerializableEvent>>();
        }

        [Test]
        public void SerializableEventArray_InitializedAsArray_ObjectIsSerialized()
        {
            DateTime start = DateTime.Now;
            EventCollection eventCollection = new EventCollection(new List<Event>
            {
                new Event
                {
                    Id = 1,
                    AllDay = false,
                    End = start.AddHours(1),
                    Url = "https://www.google.co.uk/",
                    ClassName = "test-class",
                    Constraint = new EventConstraint(new BusinessHour
                    {
                        Dow = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday },
                        Start = TimeSpan.FromHours(10),
                        End = TimeSpan.FromHours(15)
                    }),
                    Color = Color.DarkRed,
                    AdditionalFields = new Dictionary<string, string>
                    {
                        { "description", "this is the description" },
                        { "other", "this is another additional field" }
                    },
                    Title = "Title",
                    Start = start,
                    GoogleCalendarId = "abcd1234@group.calendar.google.com"
                }
            });
            IEnumerable<SerializableEvent> target = eventCollection.SerializableEventArray();
            target.ShouldBeEquivalentTo(new List<SerializableEvent>
            {
                new SerializableEvent
                {
                    id = 1,
                    title = "Title",
                    allDay = false,
                    start = start.ToString("s"),
                    end = start.AddHours(1).ToString("s"),
                    url = "https://www.google.co.uk/",
                    className = "test-class",
                    editable = false,
                    startEditable = true,
                    durationEditable = true,
                    rendering = null,
                    overlap = true,
                    constraint = new SerializableBusinessHour
                    {
                        dow = new List<DayOfWeek> { DayOfWeek.Thursday, DayOfWeek.Friday },
                        start = "10:00",
                        end = "15:00"
                    },
                    color = Color.DarkRed.ToHexString(),
                    backgroundColor = null,
                    borderColor = null,
                    textColor = null,
                    googleCalendarId = "abcd1234@group.calendar.google.com",
                    additionalFields = new Dictionary<string, string>
                    {
                        { "description", "this is the description" },
                        { "other", "this is another additional field" }
                    }
                }
            });
        }
    }
}