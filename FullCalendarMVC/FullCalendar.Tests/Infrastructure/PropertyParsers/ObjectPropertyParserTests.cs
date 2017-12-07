using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class ObjectPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventLimit));
            FullCalendarParameters parameters = new FullCalendarParameters();
            ObjectPropertyParser parser = new ObjectPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotISerializableObject_PropertyIsAddedAsString()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.ButtonIcons));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                ButtonIcons = new
                {
                    prev = "left-single-arrow"
                }
            };
            ObjectPropertyParser parser = new ObjectPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-ButtonIcons", "{ prev = left-single-arrow }");
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsISerializableObject_PropertyIsAddedAsSerializedObject()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DateIncrement));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                DateIncrement = new Duration
                {
                    Days = 4
                }
            };
            ObjectPropertyParser parser = new ObjectPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-DateIncrement", "{'days':4,'weeks':0,'months':0}");
        }
    }
}