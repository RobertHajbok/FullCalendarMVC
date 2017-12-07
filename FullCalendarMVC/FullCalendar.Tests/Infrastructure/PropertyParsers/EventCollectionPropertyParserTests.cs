using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class EventCollectionPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Events));
            FullCalendarParameters parameters = new FullCalendarParameters();
            EventCollectionPropertyParser parser = new EventCollectionPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsInitializedAsNullArray_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Events));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Events = Events.AsArray(null)
            };
            EventCollectionPropertyParser parser = new EventCollectionPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsInitializedAsEmptyArray_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Events));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Events = Events.AsArray(new List<Event>())
            };
            EventCollectionPropertyParser parser = new EventCollectionPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsInitializedAsNonEmptyArray_PropertyIsAddedAsSerializedObject()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Events));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Events = Events.AsArray(new List<Event>
                {
                    new Event()
                })
            };
            EventCollectionPropertyParser parser = new EventCollectionPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-Events", "[{'id':0,'title':null,'allDay':null,'start':null,'end':null,'url':null,'className':null,'editable':false,'startEditable':true,'durationEditable':true,'rendering':null,'overlap':true,'constraint':null,'color':null,'backgroundColor':null,'borderColor':null,'textColor':null,'googleCalendarId':null,'additionalFields':null}]");
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsInitializedAsJsonFeed_UrlPropertyIsAdded()
        {
            string url = "/Home/GetData";
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Events));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Events = Events.AsJsonFeed(url)
            };
            EventCollectionPropertyParser parser = new EventCollectionPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-Events", url);
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsInitializedAsFunction_FunctionPropertyIsAdded()
        {
            string function = "function() { alert(''); }";
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Events));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Events = Events.AsFunction(function)
            };
            EventCollectionPropertyParser parser = new EventCollectionPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-Events", function);
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsInitializedAsGoogleCalendarFeed_GoogleCalendarPropertyIsSerialized()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.Events));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                Events = Events.AsGoogleCalendarFeed("abcd1234@group.calendar.google.com")
            };
            EventCollectionPropertyParser parser = new EventCollectionPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-Events", "{'googleCalendarId':'abcd1234@group.calendar.google.com'}");
        }
    }
}