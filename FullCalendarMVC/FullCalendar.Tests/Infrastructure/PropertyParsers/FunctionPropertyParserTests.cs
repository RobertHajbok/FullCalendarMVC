using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class FunctionPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventLimitClick));
            FullCalendarParameters parameters = new FullCalendarParameters();
            FunctionPropertyParser parser = new FunctionPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotNull_PropertyIsAddedAsSerializedObject()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventLimitText));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                EventLimitText = "function() { alert(''); }"
            };
            FunctionPropertyParser parser = new FunctionPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-EventLimitText", @"{'function':'function() { alert(\u0027\u0027); }'}");
        }
    }
}