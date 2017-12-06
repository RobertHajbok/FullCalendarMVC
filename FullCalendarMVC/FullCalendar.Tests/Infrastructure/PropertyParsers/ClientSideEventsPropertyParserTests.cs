using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class ClientSideEventsPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ClientSideEvents));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ClientSideEvents = null
            };
            ClientSideEventsPropertyParser parser = new ClientSideEventsPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotNull_NonEmptyPropertiesAreAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ClientSideEvents));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ClientSideEvents = new ClientSideEvents
                {
                    DayClick = "function() { alert(''); }",
                    Drop = null
                }
            };
            ClientSideEventsPropertyParser parser = new ClientSideEventsPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-DayClick", @"{'function':'function() { alert(\u0027\u0027); }'}");
            target.Should().NotContainKey("data-fc-Drop");
        }
    }
}