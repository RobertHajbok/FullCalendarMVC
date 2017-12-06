using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Script.Serialization;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class ArrayPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventOrder));
            FullCalendarParameters parameters = new FullCalendarParameters();
            ArrayPropertyParser parser = new ArrayPropertyParser(property, null);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotNull_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.EventOrder));
            FullCalendarParameters parameters = new FullCalendarParameters
            {
                EventOrder = new string[] { }
            };
            ArrayPropertyParser parser = new ArrayPropertyParser(property, new JavaScriptSerializer());
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-EventOrder", "[]");
        }
    }
}