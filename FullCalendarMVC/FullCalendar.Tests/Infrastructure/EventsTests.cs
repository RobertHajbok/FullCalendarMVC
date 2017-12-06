using FullCalendar;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace FullCalendar.Tests
{
    [TestFixture]
    public class EventsTests
    {
        [Test]
        public void AsJsonFeed_EventsInitializedAsJsonFeed_ShouldSetParametersCorrectly()
        {
            string url = "http://www.google.co.uk";
            EventCollection target = Events.AsJsonFeed(url);
            target.Events.Should().BeNull();
            target.Function.Should().BeNull();
            target.GoogleCalendarId.Should().BeNull();
            target.Url.Should().Be(url);
            target.Type.Should().Be(EventCollectionType.JsonFeed);
        }

        [Test]
        public void AsArray_EventsInitializedAsArray_ShouldSetParametersCorrectly()
        {
            IEnumerable<Event> events = new List<Event> { new Event() };
            EventCollection target = Events.AsArray(events);
            target.Url.Should().BeNull();
            target.Function.Should().BeNull();
            target.GoogleCalendarId.Should().BeNull();
            target.Events.ShouldBeEquivalentTo(events);
            target.Type.Should().Be(EventCollectionType.Array);
        }

        [Test]
        public void AsFunction_EventsInitializedAsFunction_ShouldSetParametersCorrectly()
        {
            string function = "function() { alert(''); }";
            EventCollection target = Events.AsFunction(function);
            target.Url.Should().BeNull();
            target.GoogleCalendarId.Should().BeNull();
            target.Events.Should().BeNull();
            target.Function.Should().Be(function);
            target.Type.Should().Be(EventCollectionType.Function);
        }

        [Test]
        public void AsGoogleCalendarFeed_EventsInitializedAsGoogleCalendarFeed_ShouldSetParametersCorrectly()
        {
            string googleCalendarId = "abcd1234@group.calendar.google.com";
            EventCollection target = Events.AsGoogleCalendarFeed(googleCalendarId);
            target.Url.Should().BeNull();
            target.Events.Should().BeNull();
            target.Function.Should().BeNull();
            target.GoogleCalendarId.Should().Be(googleCalendarId);
            target.Type.Should().Be(EventCollectionType.GoogleCalendarFeed);
        }
    }
}