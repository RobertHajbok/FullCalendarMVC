using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FullCalendar.Infrastructure.PropertyParsers.Tests
{
    [TestFixture]
    public class BoolPropertyParserTests
    {
        [Test]
        public void AddPropertyToDictionary_ValueIsNull_PropertyIsNotAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.DisplayEventTime));
            FullCalendarParameters parameters = new FullCalendarParameters();
            BoolPropertyParser parser = new BoolPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().BeEmpty();
        }

        [Test]
        public void AddPropertyToDictionary_ValueIsNotNull_PropertyIsAdded()
        {
            PropertyInfo property = typeof(FullCalendarParameters).GetProperties().Single(x => x.Name == nameof(FullCalendarParameters.IsRTL));
            FullCalendarParameters parameters = new FullCalendarParameters();
            BoolPropertyParser parser = new BoolPropertyParser(property);
            Dictionary<string, string> target = new Dictionary<string, string>();
            parser.AddPropertyToDictionary(parameters, ref target);
            target.Should().Contain("data-fc-IsRTL", "false");
        }
    }
}